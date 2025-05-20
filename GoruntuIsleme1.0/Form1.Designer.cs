namespace GoruntuIsleme1._0
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
            this.button1 = new System.Windows.Forms.Button();
            this.pbGirisResmi = new System.Windows.Forms.PictureBox();
            this.cmbIslemler = new System.Windows.Forms.ComboBox();
            this.pbIslemSonucu = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudGenislik = new System.Windows.Forms.NumericUpDown();
            this.nudYukseklik = new System.Windows.Forms.NumericUpDown();
            this.nudOran = new System.Windows.Forms.NumericUpDown();
            this.textaltesik = new System.Windows.Forms.TextBox();
            this.textustesik = new System.Windows.Forms.TextBox();
            this.txtKontrastFaktor = new System.Windows.Forms.TextBox();
            this.btnKontrastUygula = new System.Windows.Forms.Button();
            this.txtGenisletmeFaktoru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblalt = new System.Windows.Forms.Label();
            this.lblust = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGirisResmi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIslemSonucu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenislik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYukseklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOran)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(35, 370);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Resim Yükle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbGirisResmi
            // 
            this.pbGirisResmi.BackColor = System.Drawing.Color.White;
            this.pbGirisResmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGirisResmi.Location = new System.Drawing.Point(35, 21);
            this.pbGirisResmi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbGirisResmi.Name = "pbGirisResmi";
            this.pbGirisResmi.Size = new System.Drawing.Size(399, 320);
            this.pbGirisResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGirisResmi.TabIndex = 1;
            this.pbGirisResmi.TabStop = false;
            // 
            // cmbIslemler
            // 
            this.cmbIslemler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbIslemler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIslemler.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbIslemler.ForeColor = System.Drawing.Color.White;
            this.cmbIslemler.FormattingEnabled = true;
            this.cmbIslemler.Location = new System.Drawing.Point(467, 385);
            this.cmbIslemler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIslemler.Name = "cmbIslemler";
            this.cmbIslemler.Size = new System.Drawing.Size(400, 28);
            this.cmbIslemler.TabIndex = 2;
            this.cmbIslemler.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pbIslemSonucu
            // 
            this.pbIslemSonucu.BackColor = System.Drawing.Color.White;
            this.pbIslemSonucu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbIslemSonucu.Location = new System.Drawing.Point(468, 21);
            this.pbIslemSonucu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbIslemSonucu.Name = "pbIslemSonucu";
            this.pbIslemSonucu.Size = new System.Drawing.Size(399, 320);
            this.pbIslemSonucu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIslemSonucu.TabIndex = 3;
            this.pbIslemSonucu.TabStop = false;
        
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(696, 448);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "İşlemi Uygula";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(468, 347);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 27);
            this.button3.TabIndex = 5;
            this.button3.Text = "<--";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(537, 347);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 27);
            this.button4.TabIndex = 6;
            this.button4.Text = "-->";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nudX
            // 
            this.nudX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudX.ForeColor = System.Drawing.Color.White;
            this.nudX.Location = new System.Drawing.Point(36, 459);
            this.nudX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(92, 27);
            this.nudX.TabIndex = 7;
            this.nudX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.Visible = false;
            // 
            // nudY
            // 
            this.nudY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudY.ForeColor = System.Drawing.Color.White;
            this.nudY.Location = new System.Drawing.Point(139, 459);
            this.nudY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(92, 27);
            this.nudY.TabIndex = 8;
            this.nudY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudY.Visible = false;
            // 
            // nudGenislik
            // 
            this.nudGenislik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudGenislik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudGenislik.ForeColor = System.Drawing.Color.White;
            this.nudGenislik.Location = new System.Drawing.Point(241, 459);
            this.nudGenislik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudGenislik.Maximum = new decimal(new int[] {
            380,
            0,
            0,
            0});
            this.nudGenislik.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGenislik.Name = "nudGenislik";
            this.nudGenislik.Size = new System.Drawing.Size(92, 27);
            this.nudGenislik.TabIndex = 9;
            this.nudGenislik.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGenislik.Visible = false;
            // 
            // nudYukseklik
            // 
            this.nudYukseklik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudYukseklik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudYukseklik.ForeColor = System.Drawing.Color.White;
            this.nudYukseklik.Location = new System.Drawing.Point(344, 459);
            this.nudYukseklik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudYukseklik.Maximum = new decimal(new int[] {
            293,
            0,
            0,
            0});
            this.nudYukseklik.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYukseklik.Name = "nudYukseklik";
            this.nudYukseklik.Size = new System.Drawing.Size(92, 27);
            this.nudYukseklik.TabIndex = 10;
            this.nudYukseklik.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYukseklik.Visible = false;
            // 
            // nudOran
            // 
            this.nudOran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudOran.DecimalPlaces = 2;
            this.nudOran.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudOran.ForeColor = System.Drawing.Color.White;
            this.nudOran.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudOran.Location = new System.Drawing.Point(467, 448);
            this.nudOran.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudOran.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudOran.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudOran.Name = "nudOran";
            this.nudOran.Size = new System.Drawing.Size(92, 27);
            this.nudOran.TabIndex = 11;
            this.nudOran.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOran.Visible = false;
            // 
            // textaltesik
            // 
            this.textaltesik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.textaltesik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textaltesik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textaltesik.ForeColor = System.Drawing.Color.White;
            this.textaltesik.Location = new System.Drawing.Point(467, 554);
            this.textaltesik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textaltesik.Name = "textaltesik";
            this.textaltesik.Size = new System.Drawing.Size(91, 27);
            this.textaltesik.TabIndex = 12;
            this.textaltesik.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textustesik
            // 
            this.textustesik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.textustesik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textustesik.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textustesik.ForeColor = System.Drawing.Color.White;
            this.textustesik.Location = new System.Drawing.Point(571, 554);
            this.textustesik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textustesik.Name = "textustesik";
            this.textustesik.Size = new System.Drawing.Size(91, 27);
            this.textustesik.TabIndex = 13;
            this.textustesik.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtKontrastFaktor
            // 
            this.txtKontrastFaktor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtKontrastFaktor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKontrastFaktor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKontrastFaktor.ForeColor = System.Drawing.Color.White;
            this.txtKontrastFaktor.Location = new System.Drawing.Point(467, 500);
            this.txtKontrastFaktor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKontrastFaktor.Name = "txtKontrastFaktor";
            this.txtKontrastFaktor.Size = new System.Drawing.Size(91, 27);
            this.txtKontrastFaktor.TabIndex = 14;
            // 
            // btnKontrastUygula
            // 
            this.btnKontrastUygula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnKontrastUygula.FlatAppearance.BorderSize = 0;
            this.btnKontrastUygula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKontrastUygula.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKontrastUygula.ForeColor = System.Drawing.Color.White;
            this.btnKontrastUygula.Location = new System.Drawing.Point(696, 508);
            this.btnKontrastUygula.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKontrastUygula.Name = "btnKontrastUygula";
            this.btnKontrastUygula.Size = new System.Drawing.Size(172, 43);
            this.btnKontrastUygula.TabIndex = 15;
            this.btnKontrastUygula.Text = "Kontrast Uygula";
            this.btnKontrastUygula.UseVisualStyleBackColor = false;
            this.btnKontrastUygula.Click += new System.EventHandler(this.btnKontrastUygula_Click);
            // 
            // txtGenisletmeFaktoru
            // 
            this.txtGenisletmeFaktoru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtGenisletmeFaktoru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGenisletmeFaktoru.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGenisletmeFaktoru.ForeColor = System.Drawing.Color.White;
            this.txtGenisletmeFaktoru.Location = new System.Drawing.Point(571, 448);
            this.txtGenisletmeFaktoru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGenisletmeFaktoru.Name = "txtGenisletmeFaktoru";
            this.txtGenisletmeFaktoru.Size = new System.Drawing.Size(91, 27);
            this.txtGenisletmeFaktoru.TabIndex = 16;
            this.txtGenisletmeFaktoru.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 437);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "X";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(139, 437);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Y";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(241, 437);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Genişlik";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(344, 437);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Yükseklik";
            this.label4.Visible = false;
            // 
            // lblalt
            // 
            this.lblalt.AutoSize = true;
            this.lblalt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblalt.ForeColor = System.Drawing.Color.Black;
            this.lblalt.Location = new System.Drawing.Point(467, 532);
            this.lblalt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblalt.Name = "lblalt";
            this.lblalt.Size = new System.Drawing.Size(57, 20);
            this.lblalt.TabIndex = 21;
            this.lblalt.Text = "Alt Eşik";
            this.lblalt.Visible = false;
            // 
            // lblust
            // 
            this.lblust.AutoSize = true;
            this.lblust.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblust.ForeColor = System.Drawing.Color.Black;
            this.lblust.Location = new System.Drawing.Point(571, 532);
            this.lblust.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblust.Name = "lblust";
            this.lblust.Size = new System.Drawing.Size(59, 20);
            this.lblust.TabIndex = 22;
            this.lblust.Text = "Üst Eşik";
            this.lblust.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(571, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Genişletme Değeri";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(467, 427);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Yaklaştırma/Uzaklaştırma";
            this.label8.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(924, 617);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblust);
            this.Controls.Add(this.lblalt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGenisletmeFaktoru);
            this.Controls.Add(this.btnKontrastUygula);
            this.Controls.Add(this.txtKontrastFaktor);
            this.Controls.Add(this.textustesik);
            this.Controls.Add(this.textaltesik);
            this.Controls.Add(this.nudOran);
            this.Controls.Add(this.nudYukseklik);
            this.Controls.Add(this.nudGenislik);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbIslemSonucu);
            this.Controls.Add(this.cmbIslemler);
            this.Controls.Add(this.pbGirisResmi);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Görüntü İşleme Uygulaması";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGirisResmi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIslemSonucu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenislik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYukseklik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbGirisResmi;
        private System.Windows.Forms.ComboBox cmbIslemler;
        private System.Windows.Forms.PictureBox pbIslemSonucu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.NumericUpDown nudGenislik;
        private System.Windows.Forms.NumericUpDown nudYukseklik;
        private System.Windows.Forms.NumericUpDown nudOran;
        private System.Windows.Forms.TextBox textaltesik;
        private System.Windows.Forms.TextBox textustesik;
        private System.Windows.Forms.TextBox txtKontrastFaktor;
        private System.Windows.Forms.Button btnKontrastUygula;
        private System.Windows.Forms.TextBox txtGenisletmeFaktoru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblalt;
        private System.Windows.Forms.Label lblust;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}