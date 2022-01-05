/**
 * System D - Security System on Free_RTOS
 */
#include<Arduino_FreeRTOS.h>
//#include<FreeRTOSConfig.h>


#define LED A0
#define BUZZER A1
#define BUTTON 3
#define SENSOR 2

volatile byte state = LOW;

float sinVal;
int toneVal;
int motionDetected;

int x = 0;

void TaskBlink(void *pvParameters);
TaskHandle_t xTaskBlink = NULL;
void TaskBuzzer(void *pvParameters);
TaskHandle_t xTaskBuzzer = NULL;
void TaskAlarmOn(void *pvParameters);
//TaskHandle_t xTaskAlarmOn = NULL;
void TaskAlarmOff(void *pvParameters);
//TaskHandle_t xTaskAlarmOff = NULL;

void setup() {
  Serial.begin(19200);

  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT);
  
  attachInterrupt(digitalPinToInterrupt(BUTTON), TaskAlarmOff, RISING);
  attachInterrupt(digitalPinToInterrupt(SENSOR), TaskAlarmOn, RISING);
  
  xTaskCreate(TaskBuzzer, "Sound Buzzer/Alarm", 100, NULL, 2, &xTaskBlink);
  xTaskCreate(TaskBlink, "Blink LED", 100, NULL, 2, &xTaskBuzzer);
  Serial.println(F("Start"));
  vTaskStartScheduler();
}

void loop(){}

void TaskAlarmOn(void *pvParameters){
  Serial.println(F("On"));
  delay(10);
  state = HIGH;
  vTaskNotifyGiveFromISR(xTaskBuzzer, NULL);
  vTaskNotifyGiveFromISR(xTaskBlink, NULL);
}
void alarm_off();

void TaskAlarmOff(void *pvParameters){
  Serial.println(F("Off"));
  delay(10);
//  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
  alarm_off();
  delay(100);
//  }
}

void alarm_off(){
  state = LOW;
  noTone(BUZZER);
  digitalWrite(LED, LOW); 
}

void TaskBlink(void *pvParameters){
  Serial.println(F("blink"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    while(state == HIGH){
      digitalWrite(LED, HIGH);
      vTaskDelay(100/portTICK_PERIOD_MS);
      digitalWrite(LED, LOW);
      vTaskDelay(100/portTICK_PERIOD_MS);
    }
  }
}

void TaskBuzzer(void *pvParameters){
  Serial.println(F("buzzer"));
  delay(10);
  if(ulTaskNotifyTake(pdTRUE, portMAX_DELAY) != 0){
    while(state == HIGH){
      for(int x = 0; x < 180; x++){
        sinVal = (sin(x*(3.1412/180)));
        toneVal = 1000 + (int(sinVal*2000));
        tone(BUZZER, toneVal);
        delay(1);
      }
    }
  }
}
