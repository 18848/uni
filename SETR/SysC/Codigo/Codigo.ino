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

// Multitasking
// Milisegundos Anterior
unsigned long previousMillisIR = 0;
unsigned long previousMillisMotor = 0;
// Percorrer por x tempo
int tempoIR = 10;
int tempoMotor = 50;


// Variáveis a usar
int code = 0;
int state = 0;


void setup()
{
    Serial.begin(9600);
    // Inicializar o recetor
    irrecv.enableIRIn(); 
    //Definir o Motor Stepper
    motor.attach(motorPIN);
    motor.write(0);

}

void loop(){

  // Milisegundos atuais para cálculo
  unsigned long currentMillis = millis();

  // Task de receber código do sensor de infravermelhos
  if((unsigned long)(currentMillis - previousMillisIR) >= tempoIR){
    
    if(IrReceiver.decode(&results)){
      code = results.value;
      Serial.println(code);  
      switch(code)
      {
        case cima:
          if(motor.read() >= 0 && motor.read() <= 90){
            state = 1;
            Serial.println("sobe");
          }
          break;
        case baixo:
          if(motor.read() >= 0 && motor.read() <= 90){
            state = 0;
            Serial.println("desce");
          }
          break;
        case desliga:
            state = 2;
            break;
        default:
          break;
      }
      irrecv.resume();
    }
    previousMillisIR = currentMillis;
  }
  // Task de alterar posição do motor
  if((unsigned long)(currentMillis - previousMillisMotor) >= tempoMotor){

    if (state == 1 && motor.read()<= 89){
      motor.write(motor.read() + 1);
      Serial.println(motor.read());  
    }
    else if (state == 0 && motor.read()>= 1){
      motor.write(motor.read() - 1);
      Serial.println(motor.read());
    }

    
    previousMillisMotor = currentMillis;
  }
   
}
