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
            lblTouch = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTouchVal = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblBtCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Location = new Point(15, 33);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(328, 215);
            pbx1.TabIndex = 1;
            pbx1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(3, 179);
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
            lblMicLevel.Location = new Point(191, 176);
            lblMicLevel.Name = "lblMicLevel";
            lblMicLevel.Size = new Size(181, 15);
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
            panel1.Location = new Point(405, 263);
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
            lblCursorY.Location = new Point(502, 455);
            lblCursorY.Name = "lblCursorY";
            lblCursorY.Size = new Size(0, 15);
            lblCursorY.TabIndex = 2;
            // 
            // lblCursorX
            // 
            lblCursorX.AutoSize = true;
            lblCursorX.Location = new Point(421, 455);
            lblCursorX.Name = "lblCursorX";
            lblCursorX.Size = new Size(0, 15);
            lblCursorX.TabIndex = 1;
            // 
            // lblMouseInstructions
            // 
            lblMouseInstructions.AutoSize = true;
            lblMouseInstructions.Location = new Point(476, 219);
            lblMouseInstructions.Name = "lblMouseInstructions";
            lblMouseInstructions.Size = new Size(133, 15);
            lblMouseInstructions.TabIndex = 9;
            lblMouseInstructions.Text = "Move Mouse Inside Box";
            // 
            // lblBattery
            // 
            lblBattery.AutoSize = true;
            lblBattery.Location = new Point(191, 44);
            lblBattery.Name = "lblBattery";
            lblBattery.Size = new Size(0, 15);
            lblBattery.TabIndex = 10;
            // 
            // lblDvd
            // 
            lblDvd.AutoSize = true;
            lblDvd.Location = new Point(191, 0);
            lblDvd.Name = "lblDvd";
            lblDvd.Size = new Size(0, 15);
            lblDvd.TabIndex = 11;
            // 
            // lblActivation
            // 
            lblActivation.AutoSize = true;
            lblActivation.Location = new Point(191, 88);
            lblActivation.Name = "lblActivation";
            lblActivation.Size = new Size(0, 15);
            lblActivation.TabIndex = 12;
            // 
            // lblTouch
            // 
            lblTouch.AutoSize = true;
            lblTouch.Location = new Point(3, 132);
            lblTouch.Name = "lblTouch";
            lblTouch.Size = new Size(76, 15);
            lblTouch.TabIndex = 13;
            lblTouch.Text = "Touchscreen:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTouchVal, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTouch, 0, 3);
            tableLayoutPanel1.Controls.Add(button2, 0, 4);
            tableLayoutPanel1.Controls.Add(lblMicLevel, 1, 4);
            tableLayoutPanel1.Controls.Add(lblDvd, 1, 0);
            tableLayoutPanel1.Controls.Add(lblBattery, 1, 1);
            tableLayoutPanel1.Controls.Add(lblActivation, 1, 2);
            tableLayoutPanel1.Location = new Point(12, 259);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(376, 223);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // lblTouchVal
            // 
            lblTouchVal.AutoSize = true;
            lblTouchVal.Location = new Point(191, 132);
            lblTouchVal.Name = "lblTouchVal";
            lblTouchVal.Size = new Size(0, 15);
            lblTouchVal.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 88);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 16;
            label3.Text = "Activated:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 44);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 15;
            label2.Text = "Battery Status:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 14;
            label1.Text = "DVD:";
            // 
            // lblBtCount
            // 
            lblBtCount.AutoSize = true;
            lblBtCount.Location = new Point(584, 70);
            lblBtCount.Name = "lblBtCount";
            lblBtCount.Size = new Size(0, 15);
            lblBtCount.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 494);
            Controls.Add(lblBtCount);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblMouseInstructions);
            Controls.Add(lblCursorY);
            Controls.Add(panel1);
            Controls.Add(lblCursorX);
            Controls.Add(lblBtDevices);
            Controls.Add(pbx1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += StopRecording;
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private Label lblTouch;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTouchVal;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblBtCount;
    }
}