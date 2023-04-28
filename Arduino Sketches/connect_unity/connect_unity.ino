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

  Serial.begin(115200, SERIAL_8N1);
}

void loop() 
{
  ledState = recvSerial();
  Serial.println(ledState);
  
  if (ledState == 1) 
  {
      digitalWrite(2, HIGH);
  } else if (ledState == -1) {
      digitalWrite(2, LOW);
  }

  if (ledState == 2) 
  {
      digitalWrite(3, HIGH);
  } else if (ledState == -2) {
      digitalWrite(3, LOW);
  }

  if (ledState == 3) 
  {
      digitalWrite(4, HIGH);
  } else if (ledState == -3) {
      digitalWrite(4, LOW);
  }

  if (ledState == 4) 
  {
      digitalWrite(5, HIGH);
  } else if (ledState == -4) {
      digitalWrite(5, LOW);
  }

  if (ledState == 5) 
  {
      digitalWrite(6, HIGH);
  } else if (ledState == -5) {
      digitalWrite(6, LOW);
  }

  if (ledState == 6) 
  {
      digitalWrite(7, HIGH);
  } else if (ledState == -6) {
      digitalWrite(7, LOW);
  }

  if (ledState == 7) 
  {
      digitalWrite(8, HIGH);
  } else if (ledState == -7) {
      digitalWrite(8, LOW);
  }

  if (ledState == 8) 
  {
      digitalWrite(9, HIGH);
  } else if (ledState == -8) {
      digitalWrite(9, LOW);
  }

  if (ledState == 9) 
  {
      digitalWrite(10, HIGH);
  } else if (ledState == -9) {
      digitalWrite(10, LOW);
  }

  if (ledState == 10) 
  {
      digitalWrite(11, HIGH);
  } else if (ledState == -10) {
      digitalWrite(11, LOW);
  }

  if (ledState == 11) 
  {
      digitalWrite(12, HIGH);
  } else if (ledState == -11) {
      digitalWrite(12, LOW);
  }

  if (ledState == 12) 
  {
      digitalWrite(13, HIGH);
  } else if (ledState == -12) {
      digitalWrite(13, LOW);
  }

}

int recvSerial() 
{
  if (Serial.available()) {
    int serialData = Serial.read();
    switch (serialData) {
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
        break;
      case 'C':
        return 3;
        break;
      case 'c': 
        return -3;
        break;
      case 'D':
        return 4;
        break;
      case 'd': 
        return -4;
        break;
      case 'E':
        return 5;
        break;
      case 'e': 
        return -5;
        break;
      case 'F':
        return 6;
        break;
      case 'f': 
        return -6;
        break;
      case 'G':
        return 7;
        break;
      case 'g': 
        return -7;
        break;
      case 'H':
        return 8;
        break;
      case 'h': 
        return -8;
        break;
      case 'I':
        return 9;
        break;
      case 'i': 
        return -9;
        break;
      case 'J':
        return 10;
        break;
      case 'j': 
        return -10;
        break;
      case 'K':
        return 11;
        break;
      case 'k': 
        return -11;
        break;
      case 'L':
        return 12;
        break;
      case 'l': 
        return -12;
        break;
      case 'M':
        return 13;
        break;
      case 'm': 
        return -13;
        break;
      case 'N':
        return 14;
        break;
      case 'n': 
        return -14;
        break;
      case 'O':
        return 15;
        break;
      default:
        return 16;
    }
  }
}

void setPinState() 
{
  if (ledState == 1) 
  {
      digitalWrite(0, HIGH);
  } else if (ledState == -1) {
      digitalWrite(0, LOW);
  }

  if (ledState == 2) 
  {
      digitalWrite(1, HIGH);
  } else if (ledState == -2) {
      digitalWrite(1, LOW);
  }

  if (ledState == 3) 
  {
      digitalWrite(2, HIGH);
  } else if (ledState == -3) {
      digitalWrite(2, LOW);
  }

  if (ledState == 4) 
  {
      digitalWrite(3, HIGH);
  } else if (ledState == -4) {
      digitalWrite(3, LOW);
  }

  if (ledState == 5) 
  {
      digitalWrite(4, HIGH);
  } else if (ledState == -5) {
      digitalWrite(4, LOW);
  }

  if (ledState == 6) 
  {
      digitalWrite(5, HIGH);
  } else if (ledState == -6) {
      digitalWrite(5, LOW);
  }

  if (ledState == 7) 
  {
      digitalWrite(6, HIGH);
  } else if (ledState == -7) {
      digitalWrite(6, LOW);
  }

  if (ledState == 8) 
  {
      digitalWrite(7, HIGH);
  } else if (ledState == -8) {
      digitalWrite(7, LOW);
  }

  if (ledState == 9) 
  {
      digitalWrite(8, HIGH);
  } else if (ledState == -9) {
      digitalWrite(8, LOW);
  }

  if (ledState == 10) 
  {
      digitalWrite(9, HIGH);
  } else if (ledState == -10) {
      digitalWrite(9, LOW);
  }

  if (ledState == 11) 
  {
      digitalWrite(10, HIGH);
  } else if (ledState == -11) {
      digitalWrite(10, LOW);
  }

  if (ledState == 12) 
  {
      digitalWrite(11, HIGH);
  } else if (ledState == -12) {
      digitalWrite(11, LOW);
  }

  if (ledState == 13) 
  {
      digitalWrite(12, HIGH);
  } else if (ledState == -13) {
      digitalWrite(12, LOW);
  }

  if (ledState == 14) 
  {
      digitalWrite(13, HIGH);
  } else if (ledState == -14) {
      digitalWrite(13, LOW);
  } 
}

void setupPins() 
{
  for (int i = 0; i <= 13; i++) 
  {
    pinMode(i, OUTPUT);
  }
}

void resetPins() 
{
    if (ledState == 15) 
    { 
      digitalWrite(0, LOW);
      digitalWrite(1, LOW);
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