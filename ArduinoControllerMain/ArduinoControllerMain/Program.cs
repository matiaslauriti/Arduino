using System;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace ArduinoController {

	public class ArduinoControllerMain {

		SerialPort currentPort;
		bool portFound;

		static void Main(string[] args) {

			

		}

		private void SetComPort() {

			try {

				string[] ports = SerialPort.GetPortNames();

				foreach(string port in ports) {

					currentPort = new SerialPort(port, 250000);

					if(DetectArduino()) {

						portFound = true;
						break;

					} else
						portFound = false;

				}

			} catch(Exception e) {

				Console.WriteLine("Error: {0}", e.Message.ToString());

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

				Thread.Sleep(1000);

				int count = currentPort.BytesToRead;
				string returnMessage = "";

				while(count > 0) {

					intReturnASCII = currentPort.ReadByte();
					returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
					count--;

				}
				
				currentPort.PortName = returnMessage;

				currentPort.Close();

				if(returnMessage.Contains("HELLO FROM ARDUINO"))
					return true;
				else
					return false;
				
			} catch(Exception e) {

				Console.WriteLine("Error: {0}", e.Message.ToString());

				return false;

			}

		}

	}

}