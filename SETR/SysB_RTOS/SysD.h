#ifndef SYSD_H
#define SYSD_H
  
  #include<Arduino_FreeRTOS.h>
    
  /*
   * Peripherals Pins
  */
  // System D - Alarm System
  #define LED A0
  #define BUZZER A1
  #define BUTTON 3
  #define SENSOR 2
  
  /*
   * Tasks
  */
//   'Blink' Task-Handle Pair
  void TaskBlink(void *pvParameters);
  TaskHandle_t HandleBlink = NULL;
//   'Buzzer' Task-Handle Pair
  void TaskBuzzer(void *pvParameters);
  TaskHandle_t HandleBuzzer = NULL;

  /*
   * Interrupts
  */
//   'Alarm On'
  void ISRAlarmOn();
//   'Alarm Off'
  void ISRAlarmOff();

//  Aux Functions
  void alarm_off();

#endif
