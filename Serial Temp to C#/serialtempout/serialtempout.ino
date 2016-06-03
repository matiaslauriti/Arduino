int led = 13;

void setup() {

  pinMode(led, OUTPUT);
  
  Serial.begin(57600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  
}

void loop() {
  
  if(Serial.available() > 0) {

    char recived = Serial.read();
    
    if(recived == 'E')
      digitalWrite(led, HIGH);
    else if(recived == 'A')
      digitalWrite(led, LOW);
    else if(recived == 'O')
      Serial.print(digitalRead(led));
      
  }

}
