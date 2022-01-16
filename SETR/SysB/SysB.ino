#include <LiquidCrystal.h>
#include <DHT.h>

// GPIO Pins
#define GLED A5
#define RLED A4
#define FAN  A3
#define DHTPIN 6
//Temperature Threshold
#define MAX 19 // 25
#define MIN 19 // 20

// LCD and Temperature Modules Controllers
LiquidCrystal lcd(13, 12, 11, 10, 9, 8);
DHT dht(DHTPIN, DHT11);

volatile byte fan_state = LOW;

void setup() {
// Initialize temp LED's and Fan
  pinMode(GLED, OUTPUT);
  pinMode(RLED, OUTPUT);
  pinMode(FAN, OUTPUT);

// Initialize DHT
  dht.begin();

// Initialize LCD
  lcd.begin(16, 2);
  
// Initialize Serial Monitor
  Serial.begin(9600);
  while(!Serial);
  Serial.println("System B - Temperature Control");
}

/*
 * Functions Declarations
*/
float temp_control();
void lcd_update(float temp);

// Program Flow
void loop() {
  float temp;
  temp = temp_control();
  lcd_update(temp);
//  Delay for readability and stability
  delay(1000);
//  Free memory to avoid overflow
  free(&temp);
}

/*
 * Functions Definitions
*/

/*
 * Temperature Scan 
 * Fan Control
 * LED Control
*/
float temp_control(){
  float temp;
  temp = dht.readTemperature(); // Temperature Reading
  
  if (isnan(temp)) { // If it fails to read DHT
    Serial.println("Failed to read from DHT sensor!");
    delay(500);
    return 0;
  }
  
//  Temperature Control
  if(temp > MAX && fan_state == LOW){//T1
    Serial.println("Temperature is to high. Cooling Down.");
    digitalWrite(FAN, HIGH);
    fan_state = HIGH;
  }
  else if(temp < MIN && fan_state == HIGH){//T2
    Serial.println("Temperature stabilized.");
    digitalWrite(FAN, LOW);
    fan_state = LOW;
  }

//  LED Indicators Control
  if(fan_state == LOW){//L1
    digitalWrite(GLED, HIGH);
    digitalWrite(RLED, LOW);
  }
  else{//L2
    digitalWrite(GLED, LOW);
    digitalWrite(RLED, HIGH);
  }
  
  return temp;
}


/*
 * LCD Information Update
 * Fan State
 * Current Temperature
*/
void lcd_update(float temp){
  lcd.clear();  // Clear LCD Screen

//  Print Fan State
  if(fan_state == HIGH){
    lcd.print("Fan ON");
  }
  else if(fan_state == LOW){
    lcd.print("Fan OFF");
  }
//  Definition of the 'degree' character
  byte degree[8] = {
  B11100,
  B10100,
  B11100,
  B00000,
  B00000,
  B00000,
  B00000,
  };
  lcd.createChar(0, degree);
  
//  Print Temperature
  lcd.setCursor(0, 1);
  lcd.print("Temp: ");
  lcd.print(temp);
  lcd.write(byte(0));
  lcd.print("C");
}
