namespace framework_WindowsFormsApp
{
    partial class Form_Main
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
            this.listBox_dolgozok = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_dolgozo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_insert = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_getAll = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_teljesnev = new System.Windows.Forms.TextBox();
            this.textBox_beosztas = new System.Windows.Forms.TextBox();
            this.numericUpDown_fizetes = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_belepes = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_kilepes = new System.Windows.Forms.DateTimePicker();
            this.checkBox_aktiv = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dolgozo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_fizetes)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_dolgozok
            // 
            this.listBox_dolgozok.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_dolgozok.FormattingEnabled = true;
            this.listBox_dolgozok.ItemHeight = 16;
            this.listBox_dolgozok.Location = new System.Drawing.Point(0, 0);
            this.listBox_dolgozok.Name = "listBox_dolgozok";
            this.listBox_dolgozok.Size = new System.Drawing.Size(165, 392);
            this.listBox_dolgozok.TabIndex = 0;
            this.listBox_dolgozok.SelectedIndexChanged += new System.EventHandler(this.listBox_dolgozok_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox_aktiv);
            this.groupBox1.Controls.Add(this.dateTimePicker_kilepes);
            this.groupBox1.Controls.Add(this.dateTimePicker_belepes);
            this.groupBox1.Controls.Add(this.numericUpDown_fizetes);
            this.groupBox1.Controls.Add(this.textBox_beosztas);
            this.groupBox1.Controls.Add(this.textBox_teljesnev);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.button_getAll);
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.button_insert);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(165, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 392);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiválasztott dolgozó";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_dolgozo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(432, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 371);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox_dolgozo
            // 
            this.pictureBox_dolgozo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_dolgozo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_dolgozo.Name = "pictureBox_dolgozo";
            this.pictureBox_dolgozo.Size = new System.Drawing.Size(134, 50);
            this.pictureBox_dolgozo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_dolgozo.TabIndex = 1;
            this.pictureBox_dolgozo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telejs név";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Belépés";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kilépés";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Beosztás";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fizetés";
            // 
            // button_insert
            // 
            this.button_insert.Location = new System.Drawing.Point(34, 296);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(79, 36);
            this.button_insert.TabIndex = 9;
            this.button_insert.Text = "&Create";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(224, 296);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(79, 36);
            this.button_update.TabIndex = 10;
            this.button_update.Text = "&Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(319, 296);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(79, 36);
            this.button_delete.TabIndex = 11;
            this.button_delete.Text = "&Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_getAll
            // 
            this.button_getAll.Location = new System.Drawing.Point(129, 296);
            this.button_getAll.Name = "button_getAll";
            this.button_getAll.Size = new System.Drawing.Size(79, 36);
            this.button_getAll.TabIndex = 12;
            this.button_getAll.Text = "&Read";
            this.button_getAll.UseVisualStyleBackColor = true;
            this.button_getAll.Click += new System.EventHandler(this.button_getAll_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(139, 48);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 22);
            this.textBox_id.TabIndex = 13;
            // 
            // textBox_teljesnev
            // 
            this.textBox_teljesnev.Location = new System.Drawing.Point(139, 82);
            this.textBox_teljesnev.Name = "textBox_teljesnev";
            this.textBox_teljesnev.Size = new System.Drawing.Size(260, 22);
            this.textBox_teljesnev.TabIndex = 14;
            // 
            // textBox_beosztas
            // 
            this.textBox_beosztas.Location = new System.Drawing.Point(139, 116);
            this.textBox_beosztas.Name = "textBox_beosztas";
            this.textBox_beosztas.Size = new System.Drawing.Size(260, 22);
            this.textBox_beosztas.TabIndex = 14;
            // 
            // numericUpDown_fizetes
            // 
            this.numericUpDown_fizetes.Location = new System.Drawing.Point(139, 150);
            this.numericUpDown_fizetes.Name = "numericUpDown_fizetes";
            this.numericUpDown_fizetes.Size = new System.Drawing.Size(230, 22);
            this.numericUpDown_fizetes.TabIndex = 15;
            // 
            // dateTimePicker_belepes
            // 
            this.dateTimePicker_belepes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_belepes.Location = new System.Drawing.Point(139, 185);
            this.dateTimePicker_belepes.Name = "dateTimePicker_belepes";
            this.dateTimePicker_belepes.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_belepes.TabIndex = 16;
            // 
            // dateTimePicker_kilepes
            // 
            this.dateTimePicker_kilepes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_kilepes.Location = new System.Drawing.Point(139, 219);
            this.dateTimePicker_kilepes.Name = "dateTimePicker_kilepes";
            this.dateTimePicker_kilepes.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_kilepes.TabIndex = 17;
            // 
            // checkBox_aktiv
            // 
            this.checkBox_aktiv.AutoSize = true;
            this.checkBox_aktiv.Location = new System.Drawing.Point(139, 258);
            this.checkBox_aktiv.Name = "checkBox_aktiv";
            this.checkBox_aktiv.Size = new System.Drawing.Size(58, 20);
            this.checkBox_aktiv.TabIndex = 18;
            this.checkBox_aktiv.Text = "Aktív";
            this.checkBox_aktiv.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Ft";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_dolgozok);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dolgozo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_fizetes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_dolgozok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_dolgozo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_getAll;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_insert;
        private System.Windows.Forms.NumericUpDown numericUpDown_fizetes;
        private System.Windows.Forms.TextBox textBox_beosztas;
        private System.Windows.Forms.TextBox textBox_teljesnev;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.CheckBox checkBox_aktiv;
        private System.Windows.Forms.DateTimePicker dateTimePicker_kilepes;
        private System.Windows.Forms.DateTimePicker dateTimePicker_belepes;
        private System.Windows.Forms.Label label7;
    }
}