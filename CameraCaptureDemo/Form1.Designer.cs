namespace CameraCaptureDemo
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbx1 = new PictureBox();
            button2 = new Button();
            lblMicLevel = new Label();
            lblBtDevices = new Label();
            panel1 = new Panel();
            lblCursorY = new Label();
            lblCursorX = new Label();
            lblMouseInstructions = new Label();
            lblBattery = new Label();
            lblDvd = new Label();
            lblActivation = new Label();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Location = new Point(57, 33);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(286, 215);
            pbx1.TabIndex = 1;
            pbx1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(57, 396);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Speakers";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblMicLevel
            // 
            lblMicLevel.AutoSize = true;
            lblMicLevel.Location = new Point(159, 400);
            lblMicLevel.Name = "lblMicLevel";
            lblMicLevel.Size = new Size(184, 15);
            lblMicLevel.TabIndex = 4;
            lblMicLevel.Text = "                                                           ";
            // 
            // lblBtDevices
            // 
            lblBtDevices.AutoSize = true;
            lblBtDevices.Location = new Point(420, 70);
            lblBtDevices.Name = "lblBtDevices";
            lblBtDevices.Size = new Size(62, 15);
            lblBtDevices.TabIndex = 7;
            lblBtDevices.Text = "Bluetooth:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Location = new Point(394, 249);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 170);
            panel1.TabIndex = 8;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // lblCursorY
            // 
            lblCursorY.AutoSize = true;
            lblCursorY.Location = new Point(408, 205);
            lblCursorY.Name = "lblCursorY";
            lblCursorY.Size = new Size(0, 15);
            lblCursorY.TabIndex = 2;
            // 
            // lblCursorX
            // 
            lblCursorX.AutoSize = true;
            lblCursorX.Location = new Point(408, 167);
            lblCursorX.Name = "lblCursorX";
            lblCursorX.Size = new Size(0, 15);
            lblCursorX.TabIndex = 1;
            // 
            // lblMouseInstructions
            // 
            lblMouseInstructions.AutoSize = true;
            lblMouseInstructions.Location = new Point(465, 205);
            lblMouseInstructions.Name = "lblMouseInstructions";
            lblMouseInstructions.Size = new Size(133, 15);
            lblMouseInstructions.TabIndex = 9;
            lblMouseInstructions.Text = "Move Mouse Inside Box";
            // 
            // lblBattery
            // 
            lblBattery.AutoSize = true;
            lblBattery.Location = new Point(57, 317);
            lblBattery.Name = "lblBattery";
            lblBattery.Size = new Size(82, 15);
            lblBattery.TabIndex = 10;
            lblBattery.Text = "Battery Status:";
            // 
            // lblDvd
            // 
            lblDvd.AutoSize = true;
            lblDvd.Location = new Point(57, 285);
            lblDvd.Name = "lblDvd";
            lblDvd.Size = new Size(33, 15);
            lblDvd.TabIndex = 11;
            lblDvd.Text = "DVD:";
            // 
            // lblActivation
            // 
            lblActivation.AutoSize = true;
            lblActivation.Location = new Point(57, 359);
            lblActivation.Name = "lblActivation";
            lblActivation.Size = new Size(60, 15);
            lblActivation.TabIndex = 12;
            lblActivation.Text = "Activated:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 450);
            Controls.Add(lblActivation);
            Controls.Add(lblDvd);
            Controls.Add(lblBattery);
            Controls.Add(lblMouseInstructions);
            Controls.Add(lblCursorY);
            Controls.Add(panel1);
            Controls.Add(lblCursorX);
            Controls.Add(lblBtDevices);
            Controls.Add(lblMicLevel);
            Controls.Add(button2);
            Controls.Add(pbx1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += StopRecording;
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbx1;
        private Button button2;
        private Label lblMicLevel;
        private Label lblBtDevices;
        private Panel panel1;
        private Label lblCursorY;
        private Label lblCursorX;
        private Label lblMouseInstructions;
        private Label lblBattery;
        private Label lblDvd;
        private Label lblActivation;
    }
}