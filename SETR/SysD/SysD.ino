/**
 * System D - Security System
 */
#define LED A0
#define BUZZER A1
#define BUTTON 3
#define SENSOR 2

volatile byte state = LOW;

float sinVal;
int toneVal;
int motionDetected;

void button_interrupt();

void setup() {
  // put your setup code here, to run once:
  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT);
  attachInterrupt(digitalPinToInterrupt(BUTTON), button_interrupt, RISING);
  
  Serial.begin(9600);
  delay(5000);
}

void loop() {
  
  // put your main code here, to run repeatedly:
  motionDetected = digitalRead(SENSOR);
  if(motionDetected == HIGH && state == LOW){
    state = HIGH;
    Serial.println("System D - Motion Detected!");
    digitalWrite(LED, HIGH);
    while(state == HIGH){
        for(int x = 0; x < 180; x++){
        sinVal = (sin(x*(3.1412/180)));
        toneVal = 1000 + (int(sinVal*2000));
        tone(BUZZER, toneVal);
        delay(2);
      }
      if(state == LOW){
        break;
      }
    }
  }
  else{
    digitalWrite(LED, LOW);
    noTone(BUZZER);
    delay(200);
  }
}


void button_interrupt(){
  if(motionDetected == HIGH){
    Serial.println("interrupt");
    state = LOW; 
    digitalWrite(LED, LOW);
    noTone(BUZZER);
    delay(200);
  }
}
