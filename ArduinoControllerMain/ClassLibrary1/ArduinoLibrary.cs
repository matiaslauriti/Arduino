using System;
using System.Threading;
using System.IO.Ports;

namespace ArduinoController {

	public class ArduinoControllerMain {

		public SerialPort currentPort;
		public bool portFound = false;
		public readonly int baudRate = 57600;

		public void SetComPort() {

			try {

				string[] ports = SerialPort.GetPortNames();

				foreach(string port in ports) {

					currentPort = new SerialPort(port, baudRate);

					if(DetectArduino()) {

						portFound = true;
						currentPort.PortName = port;
						break;

					} else {
						portFound = false;

					}

				}

			} catch(Exception e) {

				throw new Exception("Error: " + e.Message);

			}

		}

		private bool DetectArduino() {

			try {

				//The below setting are for the Hello handshake
				byte[] buffer = new byte[5];

				buffer[0] = Convert.ToByte(16);
				buffer[1] = Convert.ToByte(128);
				buffer[2] = Convert.ToByte(0);
				buffer[3] = Convert.ToByte(0);
				buffer[4] = Convert.ToByte(4);

				int intReturnASCII = 0;
				char charReturnValue = (Char)intReturnASCII;

				currentPort.Open();
				currentPort.Write(buffer, 0, 5);

				//Thread.Sleep(1000);

				/*
				Al comentar la linea de arriba, no estoy dandole tiempo a arduino a que envie, ya que la PC procesa mas rapido
				entonces hacia que el programa se detenga por 1 segundo...

				El while(count == 0); directamente entra en loop infinito hasta que recibe... osea, tener cuidado que siempre se reciba.
				Si por algun motivo no se recibe, se va a quedar ahi trabado, loop infinito....
				*/

				string returnMessage = "";

				while(currentPort.BytesToRead == 0);

				returnMessage = currentPort.ReadExisting();
				
				currentPort.Close();

				if(returnMessage.Equals("ARDUINO"))
					return true;
				else
					return false;

			} catch(Exception e) {

				Console.WriteLine("Error: {0}", e.Message);

				return false;

			}

		}

	}

}