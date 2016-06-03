using System;
using System.Threading;
using ArduinoController;
using System.IO.Ports;

namespace ArduinoMain {

	class Program {

		private static ArduinoControllerMain arduino;
		private static SerialPort arduinoPort;

		static void Main(string[] args) {
			
			arduino = new ArduinoControllerMain();

			try {
				arduino.SetComPort();
			} catch(Exception e) {
				Console.WriteLine("Error: {0}", e.Message);
			}

			if(arduino.portFound) {

				try {
					arduinoPort = new SerialPort(arduino.currentPort.PortName, arduino.baudRate);
					Menu();
				} catch(Exception e) {
					Console.WriteLine("Error: {0}", e.Message);
				}

			} else
				Console.WriteLine("No se encontró un Arduino");

			Console.WriteLine("Ejecucion finalizada...");
			Console.ReadKey();

		}

		public static string SendMessage(bool state = false, bool getstate = false) {

			int byteToSend1 = 4, byteToSend2 = 0;

			if(state && getstate)
				byteToSend1 = 2;
			else if(state)
				byteToSend2 = 255;

			//The below setting are for the Hello handshake
			byte[] buffer = new byte[5];

			buffer[0] = Convert.ToByte(16);
			buffer[1] = Convert.ToByte(127);
			buffer[2] = Convert.ToByte(byteToSend1);
			buffer[3] = Convert.ToByte(byteToSend2);
			buffer[4] = Convert.ToByte(4);

			int intReturnASCII = 0;
			char charReturnValue = (Char)intReturnASCII;

			arduinoPort.Open();
			arduinoPort.Write(buffer, 0, 5);

			string returnMessage = "";

			if(state && getstate) {

				while(arduinoPort.BytesToRead == 0);
				
				returnMessage = arduinoPort.ReadExisting();

			}

			Thread.Sleep(100);

			arduinoPort.Close();

			return returnMessage;

		}

		public static string GetState() {
			return SendMessage(true, true);
		}

		public static void Menu() {

			bool stop = false;

			while(!stop) {

				Console.Write("[1] para prender LED, [2] para apagar, [3] para obtener estado actual, [4] para salir: ");
				string tecla = Console.ReadLine();
				Console.Clear();

				switch(tecla) {

					case "1":
						SendMessage(true);
						Console.WriteLine("Prendiendo LED...");
					break;

					case "2":
						SendMessage();
						Console.WriteLine("Apagando LED...");
					break;

					case "3":
						Console.WriteLine("El estado actual es: {0}", GetState());
					break;

					case "4":
					default:
						stop = true;
					break;

				}

			}

		}

	}

}