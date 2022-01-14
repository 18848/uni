int sensorPin = A1; // Pino do sensor de luz
int readValue;      // Valor lido do sensor
int ledPin = 10;     // Pino do LED
int buttonPin = 2;  // Pino do Botão de Interrupt

void setup() {
  // Definição dos modos dos pinos
  pinMode(INPUT, sensorPin);
  pinMode(OUTPUT, ledPin);
  pinMode(buttonPin, INPUT_PULLUP);
  attachInterrupt(0, myISR, HIGH); // Interrupt
  Serial.begin(9600);
}

void loop() {
  //Ler o valor de luz que o sensor deteta
  readValue = analogRead(sensorPin);
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

// Função de Interrupt
void myISR(){
  //Desliga o Led enquanto o botão é pressionado
  Serial.println("Interrupt!");
  analogWrite(ledPin, 0);
  
  while(digitalRead(buttonPin) == LOW){
  } 
}
