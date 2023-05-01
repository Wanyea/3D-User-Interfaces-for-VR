int pwmOutput = 0;
int ledState = 0;
void setup() 
{

  pinMode(1, OUTPUT);
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);

  digitalWrite(2, LOW);
  digitalWrite(3, LOW);
  digitalWrite(4, LOW);
  digitalWrite(5, LOW);
  digitalWrite(6, LOW);
  digitalWrite(7, LOW);
  digitalWrite(8, LOW);
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
  digitalWrite(12, LOW);
  digitalWrite(13, LOW);

  Serial.begin(4800, SERIAL_8N1);
}

void loop() 
{

  // Serial.println(Serial.available());
  
  // while (Serial.available() >= 3) 
  // {

  //   Serial.println("Serial available!");
  //   Serial.println(Serial.read());
  //   byte ledPin = Serial.read();
  //   byte ledState = Serial.read();
  //   byte pwmValue = Serial.read();

  //   Serial.println("ledPin: ");
  //   Serial.println(ledPin);
  //   Serial.println(", ledState: ");
  //   Serial.println(ledState);
  //   Serial.println(", pwmValue: ");
  //   Serial.println(pwmValue);

  //   if (ledState == 3) // Motors 11, 12, 1
  //   {
  //       pwmOutput = map(pwmValue, 0, 255, 0, 255);
  //       analogWrite(ledPin, pwmOutput);
  //   } 
    

  ledState = recvSerial();
  Serial.println("led state: " + ledState);
  
  if (ledState == 1) 
  {
      digitalWrite(12, HIGH);
      digitalWrite(13, HIGH);
      digitalWrite(2, HIGH);
  }  else if (ledState == -1) {
      digitalWrite(12, LOW);
      digitalWrite(13, LOW);
      digitalWrite(2, LOW);
  }

  if (ledState == 2) 
  {
      digitalWrite(3, HIGH);
      digitalWrite(4, HIGH);
      digitalWrite(5, HIGH);
  } else if (ledState == -2) {
      digitalWrite(3, LOW);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
  }

  if (ledState == 3) 
  {
      digitalWrite(6, HIGH);
      digitalWrite(7, HIGH);
      digitalWrite(8, HIGH);
  } else if (ledState == -3) {
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
  }

  if (ledState == 4) 
  {
     digitalWrite(9, HIGH);
     digitalWrite(10, HIGH);
     digitalWrite(11, HIGH);
  } else if (ledState == -4) {
     digitalWrite(9, LOW);
     digitalWrite(10, LOW);
     digitalWrite(11, LOW);
  }  

  if (ledState == 5) 
  {
      digitalWrite(2, HIGH);
      digitalWrite(3, HIGH);
      digitalWrite(4, HIGH);
      digitalWrite(5, HIGH);
      digitalWrite(6, HIGH);
      digitalWrite(7, HIGH);
      digitalWrite(8, HIGH);
      digitalWrite(9, HIGH);
      digitalWrite(10, HIGH);
      digitalWrite(11, HIGH);
      digitalWrite(12, HIGH);
      digitalWrite(13, HIGH);

      delay(1000);

      digitalWrite(2, LOW);
      digitalWrite(3, LOW);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
      digitalWrite(13, LOW);

      delay(1000);
      
  } else if (ledState == -5) {
      digitalWrite(2, LOW);
      digitalWrite(3, LOW);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
      digitalWrite(13, LOW);
  }  
}

int recvSerial() 
{
  if (Serial.available()) 
  {
    int serialData = Serial.read();
    switch (serialData) 
    {
      case 'A':
        return 1;
        break;
      case 'a':
        return -1;
        break;
      case 'B':
        return 2;
        break;
      case 'b':
        return -2;
      case 'C':
        return 3;
        break;
      case 'c':
        return -3;
      case 'D':
        return 4;
        break;
      case 'd':
        return -4;
      case 'E':
        return 5;
        break;
      case 'e':
        return -5;
        break;
    }
  }
}


void resetPins() 
{
    if (ledState == 15) 
    { 
      digitalWrite(2, LOW);
      digitalWrite(3, LOW);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
      digitalWrite(13, LOW);
    }
}