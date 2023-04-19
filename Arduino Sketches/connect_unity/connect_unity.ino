const int ledPin = 13;
int ledState = 0;

void setup() 
{
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  ledState = recvSerial();
  delay(100);
  if (ledState == 1)
    digitalWrite(ledPin, HIGH);
  else
    digitalWrite(ledPin, LOW);
}

int recvSerial() {
  if (Serial.available()) {
    int serialData = Serial.read();
    switch (serialData) {
      case '1':
        return 1;
        break;
      case '0':
        return 0;
        break;
      default:
        return -1;
    }
  }
}