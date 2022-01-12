#ifndef SYSB_H
#define SYSB_H

  #include<Arduino_FreeRTOS.h>
  #include<LiquidCrystal.h>
  #include<DHT.h>
  
//   System B - (Air)Cooling System
  #define GLED A5
  #define RLED A4
  #define MAX 21 // 25
  #define MIN 20 // 20
  #define FAN  A3
  #define DHTPIN 6

  
/*
 * Task Definition - System D
*/
//   'Temp Control' Task-Handle Pair
  void TaskTempControl(void *pvParameters);
  TaskHandle_t HandleTempControl = NULL;
  
  float temp_control();
  void lcd_update(float temp);

#endif
