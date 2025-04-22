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
            ((System.ComponentModel.ISupportInitialize)(this.pbGirisResmi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIslemSonucu)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "resim yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbGirisResmi
            // 
            this.pbGirisResmi.Location = new System.Drawing.Point(27, 12);
            this.pbGirisResmi.Name = "pbGirisResmi";
            this.pbGirisResmi.Size = new System.Drawing.Size(285, 238);
            this.pbGirisResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGirisResmi.TabIndex = 1;
            this.pbGirisResmi.TabStop = false;
            // 
            // cmbIslemler
            // 
            this.cmbIslemler.FormattingEnabled = true;
            this.cmbIslemler.Location = new System.Drawing.Point(224, 291);
            this.cmbIslemler.Name = "cmbIslemler";
            this.cmbIslemler.Size = new System.Drawing.Size(174, 21);
            this.cmbIslemler.TabIndex = 2;
            this.cmbIslemler.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pbIslemSonucu
            // 
            this.pbIslemSonucu.Location = new System.Drawing.Point(335, 12);
            this.pbIslemSonucu.Name = "pbIslemSonucu";
            this.pbIslemSonucu.Size = new System.Drawing.Size(285, 238);
            this.pbIslemSonucu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIslemSonucu.TabIndex = 3;
            this.pbIslemSonucu.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 53);
            this.button2.TabIndex = 4;
            this.button2.Text = "işlemi uygula";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbIslemSonucu);
            this.Controls.Add(this.cmbIslemler);
            this.Controls.Add(this.pbGirisResmi);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGirisResmi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIslemSonucu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbGirisResmi;
        private System.Windows.Forms.ComboBox cmbIslemler;
        private System.Windows.Forms.PictureBox pbIslemSonucu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

