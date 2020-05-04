#include <Arduino.h>
#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>
#include <math.h>


Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver(0x40);

#define MIN_PULSE_WIDTH 500
#define MAX_PULSE_WIDTH 2500
#define FREQUENCY 50

#define LC 85
#define P 135
#define C 50



int pulseWidth(int angle)
{
  int pulse_wide, analog_value;
  pulse_wide = map(angle, 0, 180, MIN_PULSE_WIDTH, MAX_PULSE_WIDTH);
  analog_value = int(float(pulse_wide) / 1000000 * FREQUENCY * 4096);
  return analog_value;
}

int pulseWidthInverse(int angle)
{
  int pulse_wide, analog_value;
  pulse_wide = map(angle, 0, 180, MAX_PULSE_WIDTH, MIN_PULSE_WIDTH);
  analog_value = int(float(pulse_wide) / 1000000 * FREQUENCY * 4096);
  return analog_value;
}

void setup() 
{
  Serial.begin(115200);
  pwm.begin();
  pwm.setPWMFreq(FREQUENCY);
 
  
}


void loop() {

  int direct = pulseWidth((int)(90));
  int inverse = pulseWidthInverse((int)(90));
  pwm.setPWM(0, 0,direct);
  pwm.setPWM(1,0,inverse);   
          // tell servo to go to position in variable 'pos'
    delay(2000);

     direct = pulseWidth((int)(90));
   inverse = pulseWidthInverse((int)(90));
     pwm.setPWM(0, 0,direct);
  pwm.setPWM(1,0,inverse);  
  
  delay(2000);            // tell servo to go to position in variable 'pos'
   

    
}