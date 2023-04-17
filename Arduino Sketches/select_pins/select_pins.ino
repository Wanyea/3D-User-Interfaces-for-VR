#include <TimerOne.h>

// variables

const int eleven_pin = 11;
const int twelve_pin = 12;
const int thirteen_pin = 13;



void setup() 
{
  // put your setup code here, to run once:

}

void loop() 
{
  pinMode(eleven_pin, OUTPUT);           
  digitalWrite(eleven_pin, HIGH);

  pinMode(twelve_pin, OUTPUT);           
  digitalWrite(twelve_pin, HIGH);

  pinMode(thirteen_pin, OUTPUT);           
  digitalWrite(thirteen_pin, HIGH);

}
