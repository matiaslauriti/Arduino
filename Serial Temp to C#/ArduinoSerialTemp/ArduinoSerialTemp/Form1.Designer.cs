namespace ArduinoSerialTemp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.btnEncender = new System.Windows.Forms.Button();
			this.btnApagar = new System.Windows.Forms.Button();
			this.btnObtener = new System.Windows.Forms.Button();
			this.labelEstadoTexto = new System.Windows.Forms.Label();
			this.labelEstado = new System.Windows.Forms.Label();
			this.chbObtener = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// serialPort1
			// 
			this.serialPort1.PortName = "COM4";
			this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
			// 
			// btnEncender
			// 
			this.btnEncender.Location = new System.Drawing.Point(25, 38);
			this.btnEncender.Name = "btnEncender";
			this.btnEncender.Size = new System.Drawing.Size(75, 23);
			this.btnEncender.TabIndex = 1;
			this.btnEncender.Text = "Encender";
			this.btnEncender.UseVisualStyleBackColor = true;
			this.btnEncender.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnApagar
			// 
			this.btnApagar.Location = new System.Drawing.Point(106, 38);
			this.btnApagar.Name = "btnApagar";
			this.btnApagar.Size = new System.Drawing.Size(75, 23);
			this.btnApagar.TabIndex = 2;
			this.btnApagar.Text = "Apagar";
			this.btnApagar.UseVisualStyleBackColor = true;
			this.btnApagar.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnObtener
			// 
			this.btnObtener.Location = new System.Drawing.Point(187, 38);
			this.btnObtener.Name = "btnObtener";
			this.btnObtener.Size = new System.Drawing.Size(75, 23);
			this.btnObtener.TabIndex = 3;
			this.btnObtener.Text = "Obtener";
			this.btnObtener.UseVisualStyleBackColor = true;
			this.btnObtener.Click += new System.EventHandler(this.button3_Click);
			// 
			// labelEstadoTexto
			// 
			this.labelEstadoTexto.AutoSize = true;
			this.labelEstadoTexto.Location = new System.Drawing.Point(56, 9);
			this.labelEstadoTexto.Name = "labelEstadoTexto";
			this.labelEstadoTexto.Size = new System.Drawing.Size(84, 13);
			this.labelEstadoTexto.TabIndex = 4;
			this.labelEstadoTexto.Text = "Estado del LED:";
			// 
			// labelEstado
			// 
			this.labelEstado.AutoSize = true;
			this.labelEstado.Location = new System.Drawing.Point(146, 9);
			this.labelEstado.Name = "labelEstado";
			this.labelEstado.Size = new System.Drawing.Size(0, 13);
			this.labelEstado.TabIndex = 5;
			// 
			// chbObtener
			// 
			this.chbObtener.AutoSize = true;
			this.chbObtener.Location = new System.Drawing.Point(265, 43);
			this.chbObtener.Name = "chbObtener";
			this.chbObtener.Size = new System.Drawing.Size(15, 14);
			this.chbObtener.TabIndex = 6;
			this.chbObtener.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 67);
			this.Controls.Add(this.chbObtener);
			this.Controls.Add(this.labelEstado);
			this.Controls.Add(this.labelEstadoTexto);
			this.Controls.Add(this.btnObtener);
			this.Controls.Add(this.btnApagar);
			this.Controls.Add(this.btnEncender);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Button btnEncender;
		private System.Windows.Forms.Button btnApagar;
		private System.Windows.Forms.Button btnObtener;
		private System.Windows.Forms.Label labelEstadoTexto;
		private System.Windows.Forms.Label labelEstado;
		private System.Windows.Forms.CheckBox chbObtener;
	}
}

