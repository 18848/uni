#include <LiquidCrystal.h>
#include <DHT.h>

#define GLED A5
#define RLED A4
#define FAN  A3
#define DHTPIN 6

LiquidCrystal lcd(13, 12, 11, 10, 9, 8);

DHT dht(DHTPIN, DHT11);

float temp;
volatile byte state = LOW;

void setup() {
// Initialize Serial Monitor
  Serial.begin(9600);

// Initialize temp LED's and Fan
  pinMode(GLED, OUTPUT);
  pinMode(RLED, OUTPUT);
  pinMode(FAN, OUTPUT);

// Initialize DHT
  dht.begin();

// Initialize LCD
  lcd.begin(16, 2);
}

void temp_control();
void lcd_update();

void loop() {
  temp_control();
  lcd_update();
}

void temp_control(){
  int before = millis();
  temp = dht.readTemperature();
  int after = millis();
  Serial.println(after - before);
  delay(1000);
  if (isnan(temp)) {
    Serial.println(F("Failed to read from DHT sensor!"));
  }
  if(temp > 25){
    Serial.println(F("Temperature is to high. Cooling Down."));
    digitalWrite(FAN, HIGH);
    state = HIGH;
  }
  else if(temp < 20){
    Serial.println(F("Temperature stabilized."));
    digitalWrite(FAN, LOW);
    state = LOW;
  }
  if(state == LOW){
    digitalWrite(GLED, HIGH);
    digitalWrite(RLED, LOW);
  }
  else if(state == HIGH){
    digitalWrite(GLED, LOW);
    digitalWrite(RLED, HIGH);
  }
}

void lcd_update(){
  lcd.clear();
  if(state == HIGH){
    lcd.print("Fan ON");
  }
  else if(state == LOW){
    lcd.print("Fan OFF");
  }
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
  lcd.setCursor(0, 1);
  lcd.print("Temp: ");
  lcd.print(temp);
  lcd.write(byte(0));
  lcd.print("C");
  delay(1000);
}
