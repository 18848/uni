#include "SysB.h"

void ISRTempControl(){
  Serial.println(F("Temp Control"));
  delay(10);
}

void TaskTempControl(void *pvParameters){
  Serial.println(F("Temp Control Task"));
  delay(10);
  while(1){
    float temp = temp_control();
    delay(100);
//    vTaskDelay(300/portTICK_PERIOD_MS);
    lcd_update(temp);
    delay(100);
//    vTaskDelay(300/portTICK_PERIOD_MS);   
  }
}


float readTemp(){
    
  int total = 0;
  int values[SAMPLE];

  for(int i = 0; i < SAMPLE; i++){
    values[i] = analogRead(THERMISTOR);
    
//    Serial.print("Resistor: ");
//    Serial.println(values[i]);
    delay(100);
  }
  
  for(int i = 0; i < SAMPLE; i++){
    total += values[i];
  }
  
//  float avg = float(total) / float(SAMPLE);
  float avg = float(analogRead(THERMISTOR));
  avg = (1023 / avg) - 1;
  avg = RESISTOR / avg;

  Serial.print("Resistor: ");
  Serial.println(avg);

  float steinhart;
  steinhart = avg / THERMNOM;     // (R/Ro)
  steinhart = log(steinhart);                  // ln(R/Ro)
  steinhart /= BETA;                   // 1/B * ln(R/Ro)
  steinhart += 1.0 / (TEMPNOM + 273.15); // + (1/To)
  steinhart = 1.0 / steinhart;                 // Invert
  steinhart -= 273.15;    
  
  return steinhart;
}

float temp_control(){
  delay(500);
  float temp;
//  temp = dht.readTemperature();
//  Serial.print(F("DHT: "));
//  Serial.println(temp);
  temp = readTemp();
  Serial.print(F("THERM: "));
  Serial.println(temp);
//  Serial.println(F("after"));
  if (isnan(temp)) {
    Serial.println(F("Failed to read from DHT sensor!"));
    return 0;
  }
  if(temp > 25){
    Serial.println(F("Temperature is to high. Cooling Down."));
    digitalWrite(FAN, HIGH);
    fan_state = HIGH;
  }
  else if(temp < 20 && fan_state == HIGH){
    Serial.println(F("Temperature stabilized."));
    digitalWrite(FAN, LOW);
    fan_state = LOW;
  }
  if(fan_state == LOW){
    digitalWrite(GLED, HIGH);
    digitalWrite(RLED, LOW);
  }
  else if(fan_state == HIGH){
    digitalWrite(GLED, LOW);
    digitalWrite(RLED, HIGH);
  }
  return temp;
}

void lcd_update(float temp){
//  Serial.println(F("lcd"));
  lcd.clear();
  if(fan_state == HIGH){
    lcd.print("Fan ON");
  }
  else if(fan_state == LOW){
    lcd.print("Fan OFF");
  }
  byte degree[8] = {
  B11100,
  B10100,
  B11100,
  B00000,
  B00000,
  B00000,
  B00000,
  };
  lcd.createChar(0, degree);
  lcd.setCursor(0, 1);
  lcd.print("Temp: ");
  lcd.print(temp);
  lcd.write(byte(0));
  lcd.print("C");
//  vTaskDelay(100/portTICK_PERIOD_MS);
  delay(1000);
}
