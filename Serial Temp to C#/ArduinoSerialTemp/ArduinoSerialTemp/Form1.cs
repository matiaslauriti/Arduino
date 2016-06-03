using System.Windows.Forms;

namespace ArduinoSerialTemp {

	public partial class Form1 : Form {

		public Form1() {

			InitializeComponent();
			serialPort1.BaudRate = 57600;
			serialPort1.PortName = "COM4";
			serialPort1.Open();
			serialPort1.DataReceived += serialPort1_DataReceived;

			Enviar("O");

		}

		private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {

			string line = serialPort1.ReadExisting();

			if(!line.Equals(string.Empty))
				BeginInvoke(new LineReceivedEvent(LineReceived), line);

		}

		private delegate void LineReceivedEvent(string line);

		private void LineReceived(string line) {
			if(line.Equals("0"))
				labelEstado.Text = "Apagado";
			else
				labelEstado.Text = "Encendido";
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

			if(serialPort1.IsOpen)
				serialPort1.Close();

		}

		private void serialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e) {
			serialPort1.Close();
		}

		private void button1_Click(object sender, System.EventArgs e) {

			Enviar("E");

			if(chbObtener.Checked)
				Obtener();

		}

		private void button2_Click(object sender, System.EventArgs e) {

			Enviar("A");

			if(chbObtener.Checked)
				Obtener();

		}

		private void button3_Click(object sender, System.EventArgs e) {
			Obtener();
		}

		private void Obtener() {
			Enviar("O");
		}

		private void Enviar(string texto) {
			serialPort1.Write(texto);
		}

	}

}