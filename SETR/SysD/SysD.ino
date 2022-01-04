int led = 13;
int buzzer = 10;
int sensor = 2;
/**
 * System D - Security System
 */
#define LED 4
#define BUZZER 10
#define SENSOR 2

int x;

float sinVal;
int toneVal;
int motionDetected = LOW;

void setup() {
  // put your setup code here, to run once:
  pinMode(LED, OUTPUT);
  pinMode(BUZZER, OUTPUT);
  pinMode(SENSOR, INPUT);
  Serial.begin(9600);
  delay(5000);
}

void loop() {
  // put your main code here, to run repeatedly:
  motionDetected = digitalRead(SENSOR);
  if(motionDetected == HIGH){
    Serial.println("System D - Motion Detected!");
    digitalWrite(LED, HIGH);
    for(x = 0; x < 180; x++){
      sinVal = (sin(x*(3.1412/180)));
      toneVal = 1000 + (int(sinVal*2000));
      tone(BUZZER, toneVal);
      delay(1);
    }
  }
  else{
    digitalWrite(LED, LOW);
    noTone(BUZZER);
    delay(200);
  }
}
