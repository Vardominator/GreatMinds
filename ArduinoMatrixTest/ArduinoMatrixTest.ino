#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>


Adafruit_NeoMatrix matrix(8, 8, 6);

String message = "";
String clr = "";
char messageChars[16];
int values[5];
bool messageComplete = false;

int messagePosition;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(19200);

  matrix.begin();
  matrix.setBrightness(20);
  matrix.show();

  if(Serial.available()){
    Serial.println("Serial open!");
  }

}

void loop() {

   

    if(!Serial.available())
    {
        return;
    }

    clr = Serial.read();

    if(clr == "clear"){
      matrix.clear();
    }
  
    // Read chars from serial until '#' is met
    do {
      
        char data = Serial.read(); 
        
        if((data >= '0' && data <= '9') || data == ',')
        {
            message += data;
        }
        else if (data == '#')
        {
            messageComplete = true;
        }
        
        delay(1);
      
    } while (!messageComplete);

  
    Serial.println(message);


    if(messageComplete){
    
        int firstCommaIndex = message.indexOf(',');
        int secondCommaIndex = message.indexOf(',', firstCommaIndex + 1);
        int thirdCommaIndex = message.indexOf(',', secondCommaIndex + 1);
        int fourthCommaIndex = message.indexOf(',', thirdCommaIndex + 1);
        int hashtag = 15;                           c
    
        String firstVal = message.substring(0, firstCommaIndex);
        String secondVal = message.substring(firstCommaIndex + 1, secondCommaIndex);
        String thirdVal = message.substring(secondCommaIndex + 1, thirdCommaIndex);
        String fourthVal = message.substring(thirdCommaIndex + 1, fourthCommaIndex);
        String fifthVal = message.substring(fourthCommaIndex + 1, hashtag);
    
        int xPos = firstVal.toInt();
        int yPos = secondVal.toInt();
        int rVal = thirdVal.toInt();
        int gVal = fourthVal.toInt();
        int bVal = fifthVal.toInt();
    
        Serial.println(firstVal);
        Serial.println(secondVal);
        Serial.println(thirdVal);
        Serial.println(fourthVal);
        Serial.println(fifthVal);
        
        //matrix.drawPixel(xPos, yPos, matrix.Color(rVal, gVal, bVal));
        matrix.drawPixel(xPos, yPos, matrix.Color(255, 0, 0));
        matrix.show();

    }
    else{
        Serial.println("Invalid message, try again!");
    }
    
    message = "";
    messageComplete = false;

}
