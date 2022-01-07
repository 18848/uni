#ifndef SYSB_H
#define SYSB_H

  #include<Arduino_FreeRTOS.h>
  #include<LiquidCrystal.h>
  #include<DHT.h>
  
//   System B - (Air)Cooling System
  #define GLED A5
  #define RLED A4
  #define FAN  A3
  #define THERMISTOR A2
  #define DHTPIN 6

  #define RESISTOR 10000
  #define THERMNOM 10000
  #define TEMPNOM 25
  #define BETA 3900

  #define SAMPLE 30

  
/*
 * Task Definition - System D
*/
//   'Temp Control' Task-Handle Pair
  void TaskTempControl(void *pvParameters);
  TaskHandle_t HandleTempControl = NULL;
  void ISRTempControl();
//   'LCD Update' Task-Handle Pair
//  void TaskLCDUpdate(void *pvParameters);

  
  float temp_control();
  void lcd_update(float temp);

  float readTemp();
  void startTemp();


#endif
