#include <Adafruit_GFX.h>
#include <gfxfont.h>
#include <Adafruit_NeoPixel.h>


// Matrix constructor
Adafruit_NeoMatrix matrix(8, 8, 6);

// Pixel read checker
bool dataReadFinished = false;

// Message Completion check
bool messageReadComplete = false;

// Valid checker
bool messageValid = false;

// Message read from serial
String message = "";

typedef enum MessagePosition
{
  X,
  Y,
  R,
  G,
  B,
  Complete
};

// Coordinates
int x, y;

// Colors
int red, green, blue;

void setup() {

    // Initialize serial with baud rate
    Serial.begin(9600);

    // Initialize matrix
    matrix.begin();               // Begin matrix
    matrix.clear();               // Clear matrix
    matrix.setBrightness(20);     // Set the brightness
    matrix.show();                // Show matrix

    MessagePosition messagePosition = X;

}

void loop() {

    // Check to see that serial is not available or does not start with '*'
    if(!Serial.available() || Serial.read() != '*')
    {
        return;
    }

    messageComplete = false;
    messagePosition = X;

    while (!messageComplete)
    {
    
        // Read pixel data
        while (!dataReadFinished)
        {
            char data = Serial.read();  
            if (data >= '0' && data <= '9')
            {
                message += data;
            }
            else if (data == ',' || data == '#')
            {
                messageReadFinished = true;
            }
            delay(1);   
        }
        
        // Check message position
        switch(messagePosition)
        {
          
            case X:
                x = message.toInt();
                messagePosition = Y;
                break;
            case Y:
                y = message.toInt();
                messagePosition = Z;
                break;
            case R:
                red = message.toInt();
                messagePosition = R;
                break;
            case G:
                green = message.toInt();
                messagePosition = B;
                break;
            case B:
                blue = message.toInt();
                messagePosition = Complete;
    
            case Complete:
                messageComplete = true;
                if(x >= 0 && x < 8 && y >= 0 && y < 8)
                {
                    if(red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)
                    {
                        messageValid = true;
                    }
                  
                }
                break;
        }
    
    }
    
    if(messageValid)
    {
      Serial.print("Valid ");
    }
    else
    {
      Serial.print("Invalid ");
    }

    Serial.print("X: ");
    Serial.println(x);
    Serial.print("Y: ");
    Serial.println(y);

    Serial.print("R: ");
    Serial.println(red);
    Serial.print("G: ");
    Serial.println(green);
    Serial.print("B: ");
    Serial.println(blue);


    if(messageValid)
    {

        matrix.drawPixel(x, y, matrix.Color(red, green, blue));
        matrix.show();

        messagePosition = X;
        messageValid = false;
        dataReadFinished = false;
        message = "";
      
    }
    

}










