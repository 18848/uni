#include "SysD.h"
//#include "SysB.h"

void ISRAlarmOn(){
  BaseType_t xHigherPriorityTaskWoken = pdFALSE;
  Serial.println(F("Alarm On"));
  alarm_state = HIGH;
  vTaskNotifyGiveFromISR(HandleBuzzer, &xHigherPriorityTaskWoken);
//  vTaskNotifyGiveFromISR(HandleBlink, &xHigherPriorityTaskWoken);
}

void ISRAlarmOff(){
  Serial.println(F("Alarm Off"));
  alarm_state = LOW;
}


void TaskBlink(void *pvParameters){
  Serial.println(F("Blink Task"));
  delay(10);
  for(;;){
    ulTaskNotifyTake(pdTRUE, portMAX_DELAY);
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
  vTaskDelay(10/portTICK_PERIOD_MS);
  
  // Timer Vars
  int t0 = millis();
  int t1;
  volatile byte s = LOW; // LED state

  // Alarm Sound
  float sinVal;
  int toneVal;
  int x;
  for(;;){
    ulTaskNotifyTake(pdTRUE, portMAX_DELAY);
    
    while(alarm_state == HIGH){
      for(x = 0; x < 180; x++){
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
    noTone(BUZZER);
    digitalWrite(LED, LOW); 
//    vTaskDelay(100/portTICK_PERIOD_MS);
  }
}
