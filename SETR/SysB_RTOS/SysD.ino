#include "SysD.h"
#include "SysB.h"

void ISRAlarmOn(){
  Serial.println(F("Alarm On"));
  delay(10);
  alarm_state = HIGH;
//  vTaskSuspend(HandleTempControl);
//  vTaskNotifyGiveFromISR(HandleBuzzer, NULL);
//  delay(10);
//  vTaskNotifyGiveFromISR(HandleBlink, NULL);
//  vTaskNotifyGiveFromISR(HandleTempControl, NULL);
}

void ISRAlarmOff(){
  Serial.println(F("Alarm Off"));
  delay(10);
  alarm_off();
//  delay(100);
}

void alarm_off(){
  alarm_state = LOW;
  noTone(BUZZER);
  digitalWrite(LED, LOW); 
//  vTaskResume(HandleTempControl);
}

void TaskBlink(void *pvParameters){
  Serial.println(F("Blink Task"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    Serial.println(F("blink"));
    while(alarm_state == HIGH){
      digitalWrite(LED, HIGH);
      vTaskDelay(100/portTICK_PERIOD_MS);
//      delay(100);
      digitalWrite(LED, LOW);
      vTaskDelay(100/portTICK_PERIOD_MS);
//      delay(100);
    }
  }
}

void TaskBuzzer(void *pvParameters){
  Serial.println(F("Buzzer Task"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    while(alarm_state == HIGH){
      for(int x = 0; x < 180; x++){
        sinVal = (sin(x*(3.1412/180)));
        toneVal = 1000 + (int(sinVal*2000));
        tone(BUZZER, toneVal);
        delay(1);
      }
//      vTaskDelay(100/portTICK_PERIOD_MS);
//      vTaskResume(HandleTempControl);
    }
  }
}
