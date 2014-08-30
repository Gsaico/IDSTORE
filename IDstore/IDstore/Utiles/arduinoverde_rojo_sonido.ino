/*
  Fuente hardware arduino mega 2560 rev, para  IDStore
   
*/
const int LED_Rojo=8;
const int LED_Verde=10;
int inByte = 0;
 
void setup(){
    Serial.begin(9600); //abrir puertoserial
    pinMode(LED_Verde, OUTPUT);
    pinMode(LED_Rojo, OUTPUT);
    digitalWrite(LED_Verde, LOW);
    digitalWrite(LED_Rojo, LOW);
  }
 
void loop(){
 
    if(Serial.available() > 0){//respuesta de puerto serie mayor a cero
 
        inByte = Serial.read(); //lectura del puerto serial  
        Serial.println(inByte);
        if(inByte == '0')
            digitalWrite(LED_Verde, LOW);//apago led verde
        else if(inByte=='1')
           { digitalWrite(LED_Verde, HIGH);// enciendo el led verde
            delay(500); // espera durante medio segundo
            digitalWrite(LED_Verde, LOW);}// apago el led verde
        else if(inByte=='2')
            digitalWrite(LED_Rojo, LOW);//apago el led rojo
        else if(inByte=='3')
           { digitalWrite(LED_Rojo, HIGH);// enciendo el led rojo
             tone(6, 4978, 200);//emito un sonido en pwm 6, 200ms, Frecuencia 4978
            delay(500);// espera durante medio segundo
            digitalWrite(LED_Rojo, LOW);
          
          
          }
    }
}

