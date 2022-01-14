#ifndef SYSB_H
#define SYSB_H
//   System B - (Air)Cooling System

  // Libraries
  #include<Arduino_FreeRTOS.h>
  #include<LiquidCrystal.h> // LCD
  #include<DHT.h>           // Temperature Module

//  GPIO Pins
  #define GLED A5
  #define RLED A4
  #define FAN  A3
  #define DHTPIN 6
//  Temperature Threshold
  #define MAX 19 // 25
  #define MIN 19 // 20

  
/*
 * Task Definition - System D
*/
//   'Temp Control' Task-Handle Pair
  void TaskTempControl(void *pvParameters);
  TaskHandle_t HandleTempControl = NULL;
  
  float temp_control();
  void lcd_update(float temp);

#endif
