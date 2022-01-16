// Sistema de acesso a estacionamento
// Projectlibraries
#include <IRremote.h> // InfraRed Remote 
#include <Servo.h>    // Servo Motor

// Códigos dos botões utilizados no comando IR
#define desliga -23971
#define cima -28561
#define baixo -8161

// Pino para Sensor Infravermelho
#define RECV_PIN 11
IRrecv irrecv(RECV_PIN);
decode_results results; // Definir a variável para os dados do recetor

// Pino de Controlo do Motor Stepper
#define motorPIN 8
Servo motor;

// Pinos para Controlo de Led
int ledPin = 6;       // LED Vermelho
int lightSensor = A1; // Fotoresistor

// Pinos Sensor Ultrassonico
#define triggPin 3
#define echoPin 4

// Interrupt
int buttonPin = 2;    // Botão de Interrupt

// - Multitasking -
// Milisegundos Anterior
unsigned long previousMillisIR = 0;
unsigned long previousMillisMotor = 0;
unsigned long previousMillisControlLed = 0;
unsigned long previousMillisUltrassonic = 0;
// Intervalos de tempo
int tempoIR = 0;
int tempoMotor = 50;
int tempoLed = 10;
int tempoUltrassonic = 0;
// Funções
void remoteReadFunction();
void motorWriteFunction();
void ledControlFunction();
void ultrassonicFunction();


// Variáveis a usar
int code = 0;
int state = 0;
int readValue = 0;
long duration;


void setup()
{
    Serial.begin(9600);

    // Inicializar o recetor
    irrecv.enableIRIn(); 
    
    //Definir o Motor Stepper
    motor.attach(motorPIN);
    motor.write(0);

    // Definição dos modos dos pinos para controlo do LED
    pinMode(lightSensor,INPUT);
    pinMode(ledPin,OUTPUT);

    // Definição Sensor Ultrassónico
    pinMode(triggPin, OUTPUT);
    pinMode(echoPin, INPUT); 
    
    // Definição Interrupt
    pinMode(buttonPin, INPUT_PULLUP);
    attachInterrupt(0,myISR, HIGH); // Interrupt

}


void loop(){

  // Milisegundos atuais para cálculo
  unsigned long currentMillis = millis();

  // Task de receber código do sensor de infravermelhos
  if((unsigned long)(currentMillis - previousMillisIR) >= tempoIR){
    remoteReadFunction();
    previousMillisIR = currentMillis;
  }
  
  // Task de alterar posição do motor
  if((unsigned long)(currentMillis - previousMillisMotor) >= tempoMotor){
    motorWriteFunction();
    previousMillisMotor = currentMillis;
  }

  // Task de controlo do LED
  if((unsigned long)(currentMillis - previousMillisControlLed) >= tempoLed){
    ledControlFunction();
    previousMillisControlLed = currentMillis;
  }

  // Task de controlo do Sensor Ultrassonico
  if((unsigned long)(currentMillis - previousMillisUltrassonic) >= tempoUltrassonic){
    ultrassonicFunction();
    previousMillisUltrassonic = currentMillis;
  }
  
}


// Função para ler sensor infravermelho
void remoteReadFunction(){
  if(IrReceiver.decode(&results)){
      code = results.value;
      Serial.print("Codigo: ");
      Serial.println(code);
      switch(code)
      {
        case cima:
          //Subir o motor
          if(motor.read() >= 0 && motor.read() <= 90){
            state = 1;
            Serial.println("sobe");
          }
          break;
        case baixo:
          //Descer o motor
          if(motor.read() >= 0 && motor.read() <= 90){
            state = 0;
            Serial.println("desce");
          }
          break;
        case desliga:
          //Parar o Motor
          state = 2;
          break;
        default:
          break;
      }
      irrecv.resume();
    }
}

//Função para alterar posição do Servo
void motorWriteFunction(){

  // A cada iteração no multitasking verifica o estado ("sobe" 1 ou "desce" 0)
  if (state == 1 && motor.read()<= 89){
      motor.write(motor.read() + 1);
      Serial.println(motor.read());  
  }
  else if (state == 0 && motor.read()>= 1){
    motor.write(motor.read() - 1);
    Serial.println(motor.read());
  }
}

//Função para controlo do LED
void ledControlFunction(){
  
  //Ler o valor de luz que o sensor deteta
  readValue = analogRead(lightSensor);
  //Caso o valor de luz seja inferior a 200
  if (readValue < 200){
    //Desligar o LED
    analogWrite(ledPin, 0);

  }
  //Caso o valor de luz seja entre 200 e 500
  else if(readValue >= 200 && readValue < 500){
    //Ligar o LED com 1/4 da sua potência
    analogWrite(ledPin, 64);
    
  }
  //Caso o valor de luz seja entre 500 e 800
  else if(readValue >= 500 && readValue < 800){
    //Ligar o LED com 1/2 da sua potência
    analogWrite(ledPin, 128);

  }
  //Caso o valor de luz seja superior a 800
  else{
    //Ligar o LED com potência total
    analogWrite(ledPin, 255);
  }
}

// Função Sensor Ultrassonico
void ultrassonicFunction(){
  // Verifica a distancia ao sensor ultrassonico
  digitalWrite(triggPin, LOW);
  delayMicroseconds(2);
  digitalWrite(triggPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(triggPin, LOW);
  duration = pulseIn(echoPin, HIGH);

  // Caso a distancia seja menor que o valor 250 para o servo
  if(duration <= 250){
    state = 2;
  }
}


//Função de interrupt
void myISR(){
  //Desliga o Led enquanto o botão é pressionado
  Serial.println("Interrupt!");
  analogWrite(ledPin, 0);

  //Enquanto o botão é pressionado mantém o interrupt
  while(digitalRead(buttonPin) == LOW){
    
  } 
}
