/**
 * System D - Security System
 */
#define LED A0
#define BUZZER A1
#define BUTTON 3  // INTERRUPT PORT
#define SENSOR 2  // INTERRUPT PORT

volatile byte alarm_state = LOW;

// Timer Vars
int t0 = millis();
int t1;
volatile byte s = LOW; // LED 

// Buzzer Vars
float sinVal;
int toneVal;

// Interrupt Functions Declaration
void AlarmOn();
void AlarmOff();

void setup() {
//  GPIO Setup
  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT);
  pinMode(BUTTON, INPUT);

//  Interrupts Setup
  attachInterrupt(digitalPinToInterrupt(SENSOR), AlarmOn, RISING);
  attachInterrupt(digitalPinToInterrupt(BUTTON), AlarmOff, RISING);

//  Serial Setup
  Serial.begin(9600);
  while(!Serial);
  Serial.println("System D - Alarm System");
}

void loop() {
  while(alarm_state == HIGH){
//    Alarm On
    for(int x = 0; x < 180; x++){
//      Intermitent LED (Using Timer)
      t1 = millis();
      if(t1 - t0 > 100){
        s = !s;
        digitalWrite(LED, s);
        t0 = t1;
      }
//      Buzzer
      sinVal = (sin(x*(3.1412/180)));
      toneVal = 1000 + (int(sinVal*2000));
      tone(BUZZER, toneVal);
      delay(1);
    }
  }

// Alarm Off
  digitalWrite(LED, LOW);
  noTone(BUZZER);
}

/*
 * Interrupt Functions Definitions
*/

// Set Alarm On
void AlarmOn(){
  if(alarm_state == LOW){
    Serial.println("Alarm On");
    alarm_state = HIGH;
  }
}

// Set Alarm Off
void AlarmOff(){
  if(alarm_state == HIGH){
    Serial.println("Alarm Off");
    alarm_state = LOW; 
  }
}
