#include <Adafruit_NeoMatrix.h>
#include <gamma.h>

Adafruit_NeoMatrix matrix(8, 8, 6);

typedef enum MessagePosition {
  X,
  Y,
  R,
  G,
  B,
  Complete
};

typedef struct PixelMessage {
  int x;
  int y;
  int r;
  int g;
  int b;

  bool isComplete;
  bool isValid;
  bool readFinished;
  
  MessagePosition messagePosition;
  
} PixelMessage;


void setup() {
  Serial.begin(9600);
  
  matrix.begin();
  matrix.clear();
  matrix.setBrightness(20);
  matrix.show();
}

void loop() {
  if(!Serial.available() || Serial.read() != '*') {
    return;
  }

  PixelMessage pixel;
  pixel.isComplete = false;
  pixel.messagePosition = X;
    
  do {    
    pixel.readFinished = false;
    
    String value;
    do {
      char data = Serial.read();
      if(data >= '0' && data <= '9') {
        value += data;      
      } else if(data == ',' || data == '#') {
        pixel.readFinished = true;
      }

      delay(1);
    } while(!pixel.readFinished);

    switch(pixel.messagePosition) {
      case X:
        pixel.x = value.toInt();
        pixel.messagePosition = Y;
        break;

      case Y:
        pixel.y = value.toInt();
        pixel.messagePosition = R;
        break;

      case R:
        pixel.r = value.toInt();
        pixel.messagePosition = G;
        break;

      case G:
        pixel.g = value.toInt();
        pixel.messagePosition = B;
        break;

      case B:
        pixel.b = value.toInt();
        pixel.messagePosition = Complete;
        
        //Fall-through to avoid another loop iteration

      case Complete:
        pixel.isComplete = true;

        //Check pixel
        pixel.isValid = true;
        pixel.isValid &= (pixel.x >= 0 && pixel.x < 8);
        pixel.isValid &= (pixel.y >= 0 && pixel.y < 8);
        pixel.isValid &= (pixel.r >= 0 && pixel.r <= 255);
        pixel.isValid &= (pixel.g >= 0 && pixel.g <= 255);
        pixel.isValid &= (pixel.b >= 0 && pixel.b <= 255);
      
        break;
    }
    
  } while(!pixel.isComplete);


  //Debug
  if(pixel.isValid) {
    Serial.print("Valid ");
  } else {
    Serial.print("INVALID ");
  }
  
  Serial.print("message: pixel (");
  Serial.print(pixel.x);
  Serial.print(",");
  Serial.print(pixel.y);
  Serial.print("); color: (");
  Serial.print(pixel.r);
  Serial.print(",");
  Serial.print(pixel.g);
  Serial.print(",");
  Serial.print(pixel.b);
  Serial.println(")");

  if(pixel.isValid) {
    matrix.drawPixel(pixel.x, pixel.y, matrix.Color(pixel.r, pixel.g, pixel.b));
    matrix.show();    
  }
}
