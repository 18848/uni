/**
 * System D - Security System on Free_RTOS
 */
#include "SysD.h"
#include "SysB.h"

/*
 * System B - Cooling System
*/
// Fan State (ON/OFF)
volatile byte fan_state = LOW;

// Controllers Definitions
LiquidCrystal lcd(13, 12, 11, 10, 9, 8);  // LCD
DHT dht(DHTPIN, DHT11);                   // DHT - Humidity and Temperature

/*
 * System D - Alarm System
*/
// Alarm state (ON/OFF)
volatile byte alarm_state = LOW;

// Motion Detected (True/False)
int motionDetected;



void setup() {
  // Serial Monitor
  Serial.begin(9600);
  /*
   * System D setup
  */
  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT_PULLUP);
  pinMode(BUTTON, INPUT_PULLUP);
  /*
   * System B setup
  */
//  LEDs & FAN
  pinMode(GLED, OUTPUT);
  pinMode(RLED, OUTPUT);
  pinMode(FAN, OUTPUT);
//  DHT & LCD
  dht.begin();
  lcd.begin(16, 2); // (16, 2) -> dimensions (x,y)
//  startTemp();
  /*
   * Interrupts
  */
//  System D
  SemAlarmOn = xSemaphoreCreateBinary();
  attachInterrupt(digitalPinToInterrupt(BUTTON), ISRAlarmOff, RISING);
  attachInterrupt(digitalPinToInterrupt(SENSOR), ISRAlarmOn, RISING);
  
  /*
   * Tasks
  */
////  System D
//  xTaskCreate(TaskBuzzer, "Sound Buzzer/Alarm", 300, NULL, 1, &HandleBuzzer);
  
//  System B
  xTaskCreate(TaskBuzzer, "Sound Buzzer", configMINIMAL_STACK_SIZE, NULL, 2, &HandleBuzzer);
  xTaskCreate(TaskBlink, "Blink LED", configMINIMAL_STACK_SIZE, NULL, 2, &HandleBlink);
  xTaskCreate(TaskTempControl, "Temperature Control", configMINIMAL_STACK_SIZE, NULL, 0, &HandleTempControl);
  
//   Start Program
  Serial.println("Start");
  vTaskStartScheduler();
}

void loop(){}
