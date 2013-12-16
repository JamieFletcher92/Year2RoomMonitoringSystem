//---CUSTOM LIBRARY FOR USE WITH HUMIDITY/TEMP SENSOR---
#include <DHT11.h>

//---DECLARING PINS FOR USE WITH SENSORS---
int noisePin = A2;
int ldrPin = A0;
int dhtPin = 2;
int ldrLEDPin = 9;
int noiseLEDPin = 10;
int fanPin = 7;

//---VARIABLES FOR USE WITH SENSOR INPUTS---
float tempValue =0, outputTemp = 0, humValue = 0, outputHum = 0;
int noiseVal = 0, ldrVal = 0;

//---VARIABLES FOR USE WITH HUMIDITY/TEMP SENSOR---
DHT11 dht11(dhtPin);
int err;
float temp, humi;

//---SETTING UP LEDPINS AS OUTPUTS AND BEGING SERIAL AT 9600 BAUD--- 
void setup()
{
  pinMode(noiseLEDPin, OUTPUT);
  pinMode(ldrLEDPin, OUTPUT);
  pinMode(fanPin, OUTPUT);
  Serial.begin(9600); 
}

//---THIS CODE WILL LOOP WHILST THE ARDUINO IS TURNED ON---
void loop()
{
  //---ASSIGNING LDR SENSOR(LIGHT) VALUE TO LDRVAL VARIABLE--- 
  ldrVal = analogRead(ldrPin);
  
  //---IF THE VALUE FROM THE SOUND SENSOR IS OVER 350---
  if(analogRead(noisePin) >= 350)
  {
    //---ASSIGN THIS VALUE TO THE NOISEVAL VARIABLE
    //THIS IF STATEMENT STOPS BAD READINGS RUINING DATA---
    noiseVal = analogRead(noisePin);
  }  
  
  //---ASSIGNING THE HUMIDITY AND TEMPERATURE READINGS TO VARIABLES---
  if((err=dht11.read(humi, temp))==0)
  {
    outputTemp = temp;
    outputHum = humi;
  }
  
  //---IF THE LIGHT READING IS LESS THAN 30(THIS IS DARK)---
  if(ldrVal < 30)
  {
    //---TURN ON THIS LED---
    digitalWrite(ldrLEDPin, HIGH); 
  }
  //---WHEN THE LIGHT READING ISNT LESS THAN 30(IT IS LIGHT)---
  else
  {
    //---KEEP THE LED OFF---
    digitalWrite(ldrLEDPin, LOW);
  }   
  
  //---IF THE VALUE FROM THE SOUND SENSOR IS OVER 500(LOUD)---
  if(noiseVal > 500)
  {
    //---TURN ON THIS WARNING LED---
    digitalWrite(noiseLEDPin, HIGH);
  }
  //---IF THE SOUND SENSOR ISNT ABOVE 500(IT IS QUIET)---
  else
  {
    //---KEEP THIS LED OFF---
    digitalWrite(noiseLEDPin, LOW); 
  }
  
  //---IF THE TEMPERATURE GOES ABOVE 23 (IT GETS WARM)---
  if(outputTemp > 23)
  {
    //---TURN ON THE FAN TO COOL THE ROOM DOWN---
   digitalWrite(fanPin, HIGH); 
  }
  //---IF THE TEMPERATURE IS NOT ABOVE 23(IT IS COOL)---
  else
  {
    //---KEEP THE FAN OFF---
   digitalWrite(fanPin, LOW); 
  }
  
  //---PRINTING ALL OF THE SENSOR VALUES TO THE SERIAL PORT
  //WITH A 1 SECOND DELAY BETWEEN EACH TO STOP ANY CHANCE OF 
  //THE PROGRAM CRASHING WHEN FEEDING INTO THE C# PROGRAM---
  Serial.println(outputTemp);
  delay(1000);
  Serial.println(ldrVal + 1000);
  delay(1000);
  Serial.println(noiseVal + 10000);
  delay(1000);
  Serial.println(outputHum + 100000);
  delay(1000);
}
