int sensorPin = A1; //Pino do sensor de luz
int readValue;      //Valor lido do sensor
int ledPin = 3;     //Pino do LED

void setup() {
  // put your setup code here, to run once:
  pinMode(INPUT, sensorPin);
  pinMode(OUTPUT, ledPin);
  
}

void loop() {
  // put your main code here, to run repeatedly:

  //Ler o valor de luz que o sensor deteta
  readValue = analogRead(sensorPin);

  //Caso o valor de luz seja inferior a 200
  if (readValue < 200){
    
    //Desligar o LED
    analogWrite(ledPin, 0);
    delay(100);

  }
  //Caso o valor de luz seja entre 200 e 500
  else if(readValue >= 200 && readValue < 500){

    //Ligar o LED com 1/4 da sua potência
    analogWrite(ledPin, 64);
    delay(100);
    
  }
  //Caso o valor de luz seja entre 500 e 800
  else if(readValue >= 500 && readValue < 800){
    
    //Ligar o LED com 1/2 da sua potência
    analogWrite(ledPin, 128);
    delay(100);

  }
  //Caso o valor de luz seja superior a 800
  else{

    //Ligar o LED com potência total
    analogWrite(ledPin, 255);
    delay(100);
    
  }

}
