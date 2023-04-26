int ledState = 0;

void setup() 
{
  pinMode(13, OUTPUT);
  Serial.begin(9600);
}

void loop() 
{
  ledState = recvSerial();
  
  if (ledState == 1) 
  {
      digitalWrite(13, HIGH);
  } else if (ledState == -1) {
      digitalWrite(13, LOW);
  }
    
}

int recvSerial() 
{
  if (Serial.available()) {
    int serialData = Serial.read();
    Serial.print(serialData);
    switch (serialData) {
      case '1':
        return 1;
        break;
      case '-1':
        return -1;
        break;
      default:
        return 0;
    }
  }
}

void activatePin() 
{
  
}