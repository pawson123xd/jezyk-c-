namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Date = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Center_points_Count = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_iter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Start_grouping = new System.Windows.Forms.Button();
            this.List_Divergence = new System.Windows.Forms.ComboBox();
            this.Count_mink = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listsDategroup = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.ResualGroupsitera = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkcreateChart = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Center_points_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_iter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Count_mink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResualGroupsitera)).BeginInit();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.HideSelection = false;
            this.Date.Location = new System.Drawing.Point(600, 25);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(200, 415);
            this.Date.TabIndex = 0;
            this.Date.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dane";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(504, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Center_points_Count
            // 
            this.Center_points_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Center_points_Count.Location = new System.Drawing.Point(415, 377);
            this.Center_points_Count.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Center_points_Count.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Center_points_Count.Name = "Center_points_Count";
            this.Center_points_Count.Size = new System.Drawing.Size(69, 20);
            this.Center_points_Count.TabIndex = 3;
            this.Center_points_Count.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Center_points_Count.ValueChanged += new System.EventHandler(this.Center_points_Count_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Liczba środkowe punkt min 2 max 25";
            // 
            // numeric_iter
            // 
            this.numeric_iter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numeric_iter.Location = new System.Drawing.Point(135, 376);
            this.numeric_iter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_iter.Name = "numeric_iter";
            this.numeric_iter.Size = new System.Drawing.Size(69, 20);
            this.numeric_iter.TabIndex = 5;
            this.numeric_iter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numeric_iter.Visible = false;
            this.numeric_iter.ValueChanged += new System.EventHandler(this.numeric_iter_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Liczba iteracji";
            this.label3.Visible = false;
            // 
            // Start_grouping
            // 
            this.Start_grouping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Start_grouping.Location = new System.Drawing.Point(3, 376);
            this.Start_grouping.Name = "Start_grouping";
            this.Start_grouping.Size = new System.Drawing.Size(126, 64);
            this.Start_grouping.TabIndex = 7;
            this.Start_grouping.Text = "Grupowanie";
            this.Start_grouping.UseVisualStyleBackColor = true;
            this.Start_grouping.Visible = false;
            this.Start_grouping.Click += new System.EventHandler(this.Start_grouping_Click);
            // 
            // List_Divergence
            // 
            this.List_Divergence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.List_Divergence.FormattingEnabled = true;
            this.List_Divergence.Location = new System.Drawing.Point(210, 376);
            this.List_Divergence.Name = "List_Divergence";
            this.List_Divergence.Size = new System.Drawing.Size(112, 21);
            this.List_Divergence.TabIndex = 8;
            this.List_Divergence.Visible = false;
            this.List_Divergence.SelectedIndexChanged += new System.EventHandler(this.List_Divergence_SelectedIndexChanged);
            // 
            // Count_mink
            // 
            this.Count_mink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Count_mink.Location = new System.Drawing.Point(138, 415);
            this.Count_mink.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.Count_mink.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Count_mink.Name = "Count_mink";
            this.Count_mink.Size = new System.Drawing.Size(69, 20);
            this.Count_mink.TabIndex = 9;
            this.Count_mink.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Count_mink.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " Liczba mink do funkcji Minkowskiego";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Funkcja miara odległości";
            this.label5.Visible = false;
            // 
            // listsDategroup
            // 
            this.listsDategroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listsDategroup.HideSelection = false;
            this.listsDategroup.Location = new System.Drawing.Point(445, 25);
            this.listsDategroup.Name = "listsDategroup";
            this.listsDategroup.Size = new System.Drawing.Size(150, 300);
            this.listsDategroup.TabIndex = 12;
            this.listsDategroup.UseCompatibleStateImageBehavior = false;
            this.listsDategroup.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Dane Grupy";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ResualGroupsitera
            // 
            this.ResualGroupsitera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResualGroupsitera.Location = new System.Drawing.Point(340, 377);
            this.ResualGroupsitera.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ResualGroupsitera.Name = "ResualGroupsitera";
            this.ResualGroupsitera.Size = new System.Drawing.Size(69, 20);
            this.ResualGroupsitera.TabIndex = 14;
            this.ResualGroupsitera.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ResualGroupsitera.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(341, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Wynik grup po danym iteracji";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // checkcreateChart
            // 
            this.checkcreateChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkcreateChart.AutoSize = true;
            this.checkcreateChart.Location = new System.Drawing.Point(301, 416);
            this.checkcreateChart.Name = "checkcreateChart";
            this.checkcreateChart.Size = new System.Drawing.Size(294, 17);
            this.checkcreateChart.TabIndex = 16;
            this.checkcreateChart.Text = " Pokazanie danych dany  i  wykresó po określnym iteracji";
            this.checkcreateChart.UseVisualStyleBackColor = true;
            this.checkcreateChart.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkcreateChart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ResualGroupsitera);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listsDategroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Count_mink);
            this.Controls.Add(this.List_Divergence);
            this.Controls.Add(this.Start_grouping);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numeric_iter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Center_points_Count);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Center_points_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_iter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Count_mink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResualGroupsitera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Center_points_Count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_iter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Start_grouping;
        private System.Windows.Forms.ComboBox List_Divergence;
        private System.Windows.Forms.NumericUpDown Count_mink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listsDategroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ResualGroupsitera;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkcreateChart;
    }
}

