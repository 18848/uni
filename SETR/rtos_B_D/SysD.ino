#include "SysD.h"
//#include "SysB.h"

void ISRAlarmOn(){
  BaseType_t xHigherPriorityTaskWoken = pdFALSE;
  if(alarm_state == LOW){
    Serial.println("Alarm On");
    alarm_state = HIGH;
//    Call Task
    vTaskNotifyGiveFromISR(HandleBuzzer, &xHigherPriorityTaskWoken);
//    vTaskNotifyGiveFromISR(HandleBlink, &xHigherPriorityTaskWoken);
  }
}

void ISRAlarmOff(){
  if(alarm_state == HIGH){
    Serial.println("Alarm Off");
    alarm_state = LOW; 
  }
}


void TaskBlink(void *pvParameters){
  Serial.println(F("Blink Task"));
  delay(10);
  for(;;){
//    Wait For Call
    ulTaskNotifyTake(pdTRUE, portMAX_DELAY);

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
  
  for(;;){
//    Wait For Call
    ulTaskNotifyTake(pdTRUE, portMAX_DELAY);
//    Alarm On
    while(alarm_state == HIGH){
      for(int x = 0; x < 180; x++){
//        Intermitent LED (Using Timer)
        t1 = millis();
        if(t1 - t0 > 100){
          s = !s;
          digitalWrite(LED, s);
          t0 = t1;
        }
//        Buzzer
        sinVal = (sin(x*(3.1412/180)));
        toneVal = 1000 + (int(sinVal*2000));
        tone(BUZZER, toneVal);
        delay(1);
      }
    }
/*
 * Only way out of while loop is the ISRAlarmOff function
 * it sets alarm_state to LOW
 * the only way to call ISRAlarmOff is with a BUTTON press
*/
//    Alarm Off
    noTone(BUZZER);
    digitalWrite(LED, LOW); 
  }
}
