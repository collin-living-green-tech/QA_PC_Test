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
            button1 = new Button();
            pbx1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            lblMicLevel = new Label();
            button4 = new Button();
            button5 = new Button();
            lblBtDevices = new Label();
            panel1 = new Panel();
            lblCursorY = new Label();
            lblCursorX = new Label();
            lblMouseInstructions = new Label();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(268, 322);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Camera";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pbx1
            // 
            pbx1.Location = new Point(57, 33);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(286, 256);
            pbx1.TabIndex = 1;
            pbx1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(57, 322);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Sound Asterix";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(57, 396);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "DVD";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblMicLevel
            // 
            lblMicLevel.AutoSize = true;
            lblMicLevel.Location = new Point(151, 404);
            lblMicLevel.Name = "lblMicLevel";
            lblMicLevel.Size = new Size(184, 15);
            lblMicLevel.TabIndex = 4;
            lblMicLevel.Text = "                                                           ";
            // 
            // button4
            // 
            button4.Location = new Point(56, 356);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Battery";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(165, 322);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 6;
            button5.Text = "Bluetooth";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 450);
            Controls.Add(lblMouseInstructions);
            Controls.Add(lblCursorY);
            Controls.Add(panel1);
            Controls.Add(lblCursorX);
            Controls.Add(lblBtDevices);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(lblMicLevel);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pbx1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += StopRecording;
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button button1;
        private PictureBox pbx1;
        private Button button2;
        private Button button3;
        private Label lblMicLevel;
        private Button button4;
        private Button button5;
        private Label lblBtDevices;
        private Panel panel1;
        private Label lblCursorY;
        private Label lblCursorX;
        private Label lblMouseInstructions;
    }
}