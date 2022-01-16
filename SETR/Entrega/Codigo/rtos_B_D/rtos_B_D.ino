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
//int motionDetected;

void setup() {
  /*
   * System D GPIO Setup
  */
  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT);
  pinMode(BUTTON, INPUT);
  /*
   * System B GPIO Setup
  */
//  LEDs & FAN
  pinMode(GLED, OUTPUT);
  pinMode(RLED, OUTPUT);
  pinMode(FAN, OUTPUT);

//  DHT & LCD
  dht.begin();
  lcd.begin(16, 2); // (16, 2) -> dimensions (x,y)

  /*
   * Interrupts (System D only)
  */
  attachInterrupt(digitalPinToInterrupt(BUTTON), ISRAlarmOff, RISING);
  attachInterrupt(digitalPinToInterrupt(SENSOR), ISRAlarmOn, RISING);
  
  /*
   * Tasks
  */
//  System D
  xTaskCreate(TaskBuzzer, "Sound Buzzer", configMINIMAL_STACK_SIZE, NULL
  , 2, &HandleBuzzer);
  xTaskCreate(TaskBlink, "Blink LED", configMINIMAL_STACK_SIZE, NULL
  , 2, &HandleBlink);
//  System B
  xTaskCreate(TaskTempControl, "Temperature Control", configMINIMAL_STACK_SIZE, NULL
  , 0, NULL);
  
// Initialize Serial Monitor
  Serial.begin(9600);
  while(!Serial);
//   Start Program
  Serial.println("Start");
  vTaskStartScheduler();
}

/*
 * Empty loop()
 * Things are run inside Tasks.
*/
void loop(){}
