namespace core_WinFormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dataGridView1;
        private Label lblStatus;
        private GroupBox groupBox1;
        private TextBox txtNev;
        private Label label1;
        private TextBox txtBeosztas;
        private Label label2;
        private TextBox txtFizetes;
        private Label label3;
        private DateTimePicker dtpBelepes;
        private Label label4;
        private CheckBox chkAktiv;
        private Button btnUj;
        private Button btnTorles;
        private Button btnUjites;
        private TextBox txtId;
        private Label label5;
        private Button btnFrissit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnUjites = new System.Windows.Forms.Button();
            this.btnTorles = new System.Windows.Forms.Button();
            this.btnUj = new System.Windows.Forms.Button();
            this.chkAktiv = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBelepes = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFizetes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBeosztas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNev = new System.Windows.Forms.TextBox();
            this.btnFrissit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(850, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(103, 23);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Dolgozók: 0";

            // groupBox1
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.btnUjites);
            this.groupBox1.Controls.Add(this.btnTorles);
            this.groupBox1.Controls.Add(this.btnUj);
            this.groupBox1.Controls.Add(this.chkAktiv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpBelepes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFizetes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBeosztas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNev);
            this.groupBox1.Location = new System.Drawing.Point(12, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dolgozó adatai";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "ID:";

            // txtId
            this.txtId.Location = new System.Drawing.Point(120, 32);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(150, 27);
            this.txtId.TabIndex = 12;

            // btnUjites
            this.btnUjites.Location = new System.Drawing.Point(600, 160);
            this.btnUjites.Name = "btnUjites";
            this.btnUjites.Size = new System.Drawing.Size(100, 40);
            this.btnUjites.TabIndex = 11;
            this.btnUjites.Text = "Újítás";
            this.btnUjites.UseVisualStyleBackColor = true;
            this.btnUjites.Click += new System.EventHandler(this.btnUjites_Click);

            // btnTorles
            this.btnTorles.Location = new System.Drawing.Point(710, 160);
            this.btnTorles.Name = "btnTorles";
            this.btnTorles.Size = new System.Drawing.Size(100, 40);
            this.btnTorles.TabIndex = 10;
            this.btnTorles.Text = "Törlés";
            this.btnTorles.UseVisualStyleBackColor = true;
            this.btnTorles.Click += new System.EventHandler(this.btnTorles_Click);

            // btnUj
            this.btnUj.Location = new System.Drawing.Point(490, 160);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(100, 40);
            this.btnUj.TabIndex = 9;
            this.btnUj.Text = "Mentés";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);

            // chkAktiv
            this.chkAktiv.AutoSize = true;
            this.chkAktiv.Location = new System.Drawing.Point(490, 95);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Size = new System.Drawing.Size(65, 24);
            this.chkAktiv.TabIndex = 8;
            this.chkAktiv.Text = "Aktív";
            this.chkAktiv.UseVisualStyleBackColor = true;

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Belépés:";

            // dtpBelepes
            this.dtpBelepes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBelepes.Location = new System.Drawing.Point(120, 160);
            this.dtpBelepes.Name = "dtpBelepes";
            this.dtpBelepes.Size = new System.Drawing.Size(150, 27);
            this.dtpBelepes.TabIndex = 6;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fizetés:";

            // txtFizetes
            this.txtFizetes.Location = new System.Drawing.Point(120, 127);
            this.txtFizetes.Name = "txtFizetes";
            this.txtFizetes.Size = new System.Drawing.Size(150, 27);
            this.txtFizetes.TabIndex = 4;
            this.txtFizetes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFizetes_KeyPress);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beosztás:";

            // txtBeosztas
            this.txtBeosztas.Location = new System.Drawing.Point(120, 92);
            this.txtBeosztas.Name = "txtBeosztas";
            this.txtBeosztas.Size = new System.Drawing.Size(300, 27);
            this.txtBeosztas.TabIndex = 2;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Név:";

            // txtNev
            this.txtNev.Location = new System.Drawing.Point(120, 62);
            this.txtNev.Name = "txtNev";
            this.txtNev.Size = new System.Drawing.Size(300, 27);
            this.txtNev.TabIndex = 0;

            // btnFrissit
            this.btnFrissit.Location = new System.Drawing.Point(762, 6);
            this.btnFrissit.Name = "btnFrissit";
            this.btnFrissit.Size = new System.Drawing.Size(100, 29);
            this.btnFrissit.TabIndex = 3;
            this.btnFrissit.Text = "Frissítés";
            this.btnFrissit.UseVisualStyleBackColor = true;
            this.btnFrissit.Click += new System.EventHandler(this.btnFrissit_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 579);
            this.Controls.Add(this.btnFrissit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Dolgozó Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }

}
