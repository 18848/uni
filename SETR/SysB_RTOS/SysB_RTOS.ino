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
  pinMode(SENSOR, INPUT);
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
  attachInterrupt(digitalPinToInterrupt(BUTTON), ISRAlarmOff, RISING);
  attachInterrupt(digitalPinToInterrupt(SENSOR), ISRAlarmOn, RISING);
//  attachInterrupt(digitalPinToInterrupt(DHTPIN), ISRTempControl, CHANGE);
  
  /*
   * Tasks
  */
//  System D
  xTaskCreate(TaskBuzzer, "Sound Buzzer/Alarm", 300, NULL, 1, &HandleBuzzer);
  xTaskCreate(TaskBlink, "Blink LED", 300, NULL, 2, &HandleBlink);
  
//  System B
  xTaskCreate(TaskTempControl, "Temperature Control", 128, NULL, 0, &HandleTempControl);

//   Start Program
  Serial.println(F("Start"));
  vTaskStartScheduler();
}

void loop(){}
