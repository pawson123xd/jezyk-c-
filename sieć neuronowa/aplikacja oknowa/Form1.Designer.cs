namespace WinFormsApp2
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            wyswietl = new TextBox();
            inf = new Label();
            licznik = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)licznik).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(591, 26);
            button1.Name = "button1";
            button1.Size = new Size(186, 103);
            button1.TabIndex = 0;
            button1.Text = "Zadanie1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(591, 166);
            button2.Name = "button2";
            button2.Size = new Size(186, 103);
            button2.TabIndex = 1;
            button2.Text = "Zadanie2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(591, 292);
            button3.Name = "button3";
            button3.Size = new Size(186, 103);
            button3.TabIndex = 2;
            button3.Text = "Zadanie3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(544, 26);
            label1.Name = "label1";
            label1.Size = new Size(41, 75);
            label1.TabIndex = 3;
            label1.Text = "W  Wy\r\n0 0  0\r\n0 1  1\r\n1 0  1\r\n1 1  0\r\n";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(544, 166);
            label2.Name = "label2";
            label2.Size = new Size(44, 75);
            label2.TabIndex = 4;
            label2.Text = "We Wy\r\n0 0  0 1\r\n0 1  1 0\r\n1 0  1 0\r\n1 1  0 0\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(532, 292);
            label3.Name = "label3";
            label3.Size = new Size(53, 135);
            label3.TabIndex = 5;
            label3.Text = "We    Wy\r\n0 0 0  0 0\r\n0 1 0  1 0\r\n1 0 0  1 0\r\n1 1 0  0 1\r\n0 0 1  1 0\r\n0 1 1  0 1\r\n1 0 1  0 1\r\n1 1 1  1 1\r\n";
            label3.Click += label3_Click;
            // 
            // wyswietl
            // 
            wyswietl.BackColor = SystemColors.Window;
            wyswietl.ForeColor = SystemColors.ActiveCaptionText;
            wyswietl.Location = new Point(12, 12);
            wyswietl.Multiline = true;
            wyswietl.Name = "wyswietl";
            wyswietl.ReadOnly = true;
            wyswietl.Size = new Size(182, 426);
            wyswietl.TabIndex = 6;
            wyswietl.TextChanged += textBox1_TextChanged;
            // 
            // inf
            // 
            inf.AutoSize = true;
            inf.Location = new Point(364, 8);
            inf.Name = "inf";
            inf.Size = new Size(110, 15);
            inf.TabIndex = 8;
            inf.Text = "podaj liczbe warstw";
            inf.Click += label4_Click;
            // 
            // licznik
            // 
            licznik.Location = new Point(364, 24);
            licznik.Name = "licznik";
            licznik.Size = new Size(119, 23);
            licznik.TabIndex = 9;
            licznik.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(licznik);
            Controls.Add(inf);
            Controls.Add(wyswietl);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)licznik).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        public TextBox wyswietl;
        private Label inf;
        private NumericUpDown licznik;
    }
}
