// Sistema de acesso a estacionamento
// Projectlibraries
#include <IRremote.h> // InfraRed Remote 
#include <Servo.h>    // Servo Motor

// Códigos dos botões utilizados no comando IR
#define code0 0
#define code1 1
#define code2 2

// Pino de Controlo do Motor Stepper
#define motorPIN 8

Servo motor;

void setup()
{
    Serial.begin(9600);
    motor.attach(motorPIN);
}

void loop()
{
    int code = -1;

    switch(code)
    {
        case code0:
          if(motor.read() == 0)
          {
            motor.write(90);
          }
          break;
        case code1:
          if(motor.read() == 90)
          {
            motor.write(-90);
          }
          break;
        case code2:
          break;
        default:
          break;
    }
}
