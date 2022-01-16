#ifndef SYSD_H
#define SYSD_H
  // System D - Alarm System
  
  #include<Arduino_FreeRTOS.h>
    
  /*
   * GPIO Pins
  */
  #define LED A0
  #define BUZZER A1
  #define BUTTON 3  // INTERRUPT PORT
  #define SENSOR 2  // INTERRUPT PORT
  
  /*
   * Tasks & Handles
  */
//   'Blink' Task-Handle Pair
  void TaskBlink(void *pvParameters);
  TaskHandle_t HandleBlink = NULL;
//   'Buzzer' Task-Handle Pair
  void TaskBuzzer(void *pvParameters);
  TaskHandle_t HandleBuzzer = NULL;

  /*
   * Interrupts Functions
  */
//   'Alarm On'
  void ISRAlarmOn();
//   'Alarm Off'
  void ISRAlarmOff();

#endif
