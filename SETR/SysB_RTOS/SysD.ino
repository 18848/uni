#include "SysD.h"
#include "SysB.h"

void ISRAlarmOn(){
  Serial.println(F("Alarm On"));
  delay(10);
  alarm_state = HIGH;
//  vTaskNotifyGiveFromISR(HandleBlink, NULL);
  delay(10);
  vTaskNotifyGiveFromISR(HandleBuzzer, NULL);
}

void ISRAlarmOff(){
  Serial.println(F("Alarm Off"));
  delay(10);
  alarm_state = LOW;
  delay(100);
  noTone(BUZZER);
  digitalWrite(LED, LOW); 
}

void TaskBlink(void *pvParameters){
  Serial.println(F("Blink Task"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    Serial.println(F("blink"));
    while(alarm_state == HIGH){
      digitalWrite(LED, HIGH);
      vTaskDelay(100/portTICK_PERIOD_MS);
      digitalWrite(LED, LOW);
      vTaskDelay(100/portTICK_PERIOD_MS);
    }
  }
}

void TaskBuzzer(void *pvParameters){
  Serial.println(F("Buzzer Task"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    // Timer Vars
    int t0 = millis();
    int t1;
    volatile byte s = HIGH; // LED state
    digitalWrite(LED, s);

    // Alarm Sound
    float sinVal;
    int toneVal;
    
    while(alarm_state == HIGH){
      for(int x = 0; x < 180; x++){
        t1 = millis();
        if(t1 - t0 > 100){
          s = !s;
          digitalWrite(LED, s);
          t0 = t1;
        }
        sinVal = (sin(x*(3.1412/180)));
        toneVal = 1000 + (int(sinVal*2000));
        tone(BUZZER, toneVal);
        delay(1);
      }
    }
  }
}
