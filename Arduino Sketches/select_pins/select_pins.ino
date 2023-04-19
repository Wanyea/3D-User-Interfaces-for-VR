#include <TimerOne.h>


// output pin variables

const int zero_pin = 0;
const int one_pin = 1;
const int two_pin = 2;
const int three_pin = 3;
const int four_pin = 4;
const int five_pin = 5;
const int six_pin = 6;
const int seven_pin = 7;
const int eight_pin = 8;
const int nine_pin = 9;
const int ten_pin = 10;
const int eleven_pin = 11;
const int twelve_pin = 12;
const int thirteen_pin = 13;

void setup() 
{
   setPinsMode();
   Serial.begin(9600);

}

void loop() 
{
   Serial.flush();
   Serial.println();
}

void setPinsMode() 
{

   pinMode(zero_pin, OUTPUT);
   pinMode(one_pin, OUTPUT);
   pinMode(two_pin, OUTPUT);
   pinMode(three_pin, OUTPUT);
   pinMode(four_pin, OUTPUT);
   pinMode(five_pin, OUTPUT);
   pinMode(six_pin, OUTPUT);
   pinMode(seven_pin, OUTPUT);
   pinMode(eight_pin, OUTPUT);
   pinMode(nine_pin, OUTPUT);
   pinMode(ten_pin, OUTPUT);
   pinMode(eleven_pin, OUTPUT);
   pinMode(twelve_pin, OUTPUT);
   pinMode(thirteen_pin, OUTPUT); 

   digitalWrite(zero_pin, HIGH);  
}
