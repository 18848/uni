#include "SysB.h"

void TaskTempControl(void *pvParameters){
  Serial.println(F("Temp Control Task"));
  delay(10);
  while(alarm_state == LOW){
    float temp = temp_control();
    vTaskDelay(100/portTICK_PERIOD_MS);
    lcd_update(temp);
    vTaskDelay(100/portTICK_PERIOD_MS);   
  }
}

float temp_control(){
  float temp = dht.readTemperature();
  
//  Serial.print(F("DHT: "));
//  Serial.println(temp);

  if (isnan(temp)) {
    Serial.println(F("Failed to read from DHT sensor!"));
    delay(500);
    return 0;
  }
  
//  Temperature Control
  if(temp > MAX){
    if(fan_state == LOW){
      Serial.println(F("Temperature is to high. Cooling Down."));
    }
    digitalWrite(FAN, HIGH);
    fan_state = HIGH;
  }
  else if(temp < MIN && fan_state == HIGH){
    Serial.println(F("Temperature stabilized."));
    digitalWrite(FAN, LOW);
    fan_state = LOW;
  }
//  LED Indicators
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

//  Print Fan State
  if(fan_state == HIGH){
    lcd.print("Fan ON");
  }
  else if(fan_state == LOW){
    lcd.print("Fan OFF");
  }
//  Definition of the 'degree' character
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
//  Print Temperature
  lcd.setCursor(0, 1);
  lcd.print("Temp: ");
  lcd.print(temp);
  lcd.write(byte(0));
  lcd.print("C");
  
//  Delay for Stability
  delay(1000);
}
