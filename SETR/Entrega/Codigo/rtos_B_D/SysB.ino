#include "SysB.h"
#include "SysD.h"

void TaskTempControl(void *pvParameters){
  (void) pvParameters;
  
  Serial.println("Temp Control Task");
  vTaskDelay(10/portTICK_PERIOD_MS);
  
  float temp;
  for(;;){
    temp = temp_control();
    lcd_update(temp);
//    Delay for readability and stability
    delay(1000);
  }
}

float temp_control(){
  float temp;
  temp = dht.readTemperature();
  
  if (isnan(temp)) { // If it fails to read DHT
    Serial.println("Failed to read from DHT sensor!");
    delay(500);
    return 0;
  }
  
//  Temperature Control
  if(temp > MAX && fan_state == LOW){
    Serial.println("Temperature is to high. Cooling Down.");
    digitalWrite(FAN, HIGH);
    fan_state = HIGH;
  }
  else if(temp < MIN && fan_state == HIGH){
    Serial.println("Temperature stabilized.");
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
  lcd.clear();  // Clear LCD Screen

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
}
