namespace CsharpInterfata
{
    partial class MainForm
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
            this.tabInscrieri = new System.Windows.Forms.TabControl();
            this.tabProba = new System.Windows.Forms.TabPage();
            this.tabInscriere = new System.Windows.Forms.TabPage();
            this.tableProbe = new System.Windows.Forms.DataGridView();
            this.tableParticipanti = new System.Windows.Forms.DataGridView();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.labelNume = new System.Windows.Forms.Label();
            this.labelPrenume = new System.Windows.Forms.Label();
            this.labelVarsta = new System.Windows.Forms.Label();
            this.labelProba1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdaugaInscriere = new System.Windows.Forms.Button();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.textBoxVarsta = new System.Windows.Forms.TextBox();
            this.textBoxProba1 = new System.Windows.Forms.TextBox();
            this.textBoxVarstaMin = new System.Windows.Forms.TextBox();
            this.textBoxVarstaMax = new System.Windows.Forms.TextBox();
            this.textBoxProba2 = new System.Windows.Forms.TextBox();
            this.tabInscrieri.SuspendLayout();
            this.tabProba.SuspendLayout();
            this.tabInscriere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableParticipanti)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabInscrieri
            // 
            this.tabInscrieri.Controls.Add(this.tabProba);
            this.tabInscrieri.Controls.Add(this.tabInscriere);
            this.tabInscrieri.Location = new System.Drawing.Point(30, 12);
            this.tabInscrieri.Name = "tabInscrieri";
            this.tabInscrieri.SelectedIndex = 0;
            this.tabInscrieri.Size = new System.Drawing.Size(703, 408);
            this.tabInscrieri.TabIndex = 2;
            // 
            // tabProba
            // 
            this.tabProba.Controls.Add(this.buttonCauta);
            this.tabProba.Controls.Add(this.tableParticipanti);
            this.tabProba.Controls.Add(this.tableProbe);
            this.tabProba.Location = new System.Drawing.Point(4, 22);
            this.tabProba.Name = "tabProba";
            this.tabProba.Padding = new System.Windows.Forms.Padding(3);
            this.tabProba.Size = new System.Drawing.Size(695, 382);
            this.tabProba.TabIndex = 0;
            this.tabProba.Text = "tabProbe";
            this.tabProba.UseVisualStyleBackColor = true;
            // 
            // tabInscriere
            // 
            this.tabInscriere.Controls.Add(this.textBoxProba2);
            this.tabInscriere.Controls.Add(this.textBoxVarstaMax);
            this.tabInscriere.Controls.Add(this.textBoxVarstaMin);
            this.tabInscriere.Controls.Add(this.textBoxProba1);
            this.tabInscriere.Controls.Add(this.textBoxVarsta);
            this.tabInscriere.Controls.Add(this.textBoxPrenume);
            this.tabInscriere.Controls.Add(this.textBoxNume);
            this.tabInscriere.Controls.Add(this.buttonAdaugaInscriere);
            this.tabInscriere.Controls.Add(this.label3);
            this.tabInscriere.Controls.Add(this.label2);
            this.tabInscriere.Controls.Add(this.label1);
            this.tabInscriere.Controls.Add(this.labelProba1);
            this.tabInscriere.Controls.Add(this.labelVarsta);
            this.tabInscriere.Controls.Add(this.labelPrenume);
            this.tabInscriere.Controls.Add(this.labelNume);
            this.tabInscriere.Location = new System.Drawing.Point(4, 22);
            this.tabInscriere.Name = "tabInscriere";
            this.tabInscriere.Padding = new System.Windows.Forms.Padding(3);
            this.tabInscriere.Size = new System.Drawing.Size(695, 382);
            this.tabInscriere.TabIndex = 1;
            this.tabInscriere.Text = "tabInscrieri";
            this.tabInscriere.UseVisualStyleBackColor = true;
            this.tabInscriere.Click += new System.EventHandler(this.tabInscriere_Click);
            // 
            // tableProbe
            // 
            this.tableProbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableProbe.Location = new System.Drawing.Point(25, 30);
            this.tableProbe.Name = "tableProbe";
            this.tableProbe.Size = new System.Drawing.Size(256, 319);
            this.tableProbe.TabIndex = 0;
            this.tableProbe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableProbe_CellContentClick);
            // 
            // tableParticipanti
            // 
            this.tableParticipanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableParticipanti.Location = new System.Drawing.Point(395, 30);
            this.tableParticipanti.Name = "tableParticipanti";
            this.tableParticipanti.Size = new System.Drawing.Size(284, 319);
            this.tableParticipanti.TabIndex = 1;
            // 
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(307, 30);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(75, 23);
            this.buttonCauta.TabIndex = 2;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(224, 48);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(35, 13);
            this.labelNume.TabIndex = 0;
            this.labelNume.Text = "Nume";
            // 
            // labelPrenume
            // 
            this.labelPrenume.AutoSize = true;
            this.labelPrenume.Location = new System.Drawing.Point(218, 80);
            this.labelPrenume.Name = "labelPrenume";
            this.labelPrenume.Size = new System.Drawing.Size(49, 13);
            this.labelPrenume.TabIndex = 1;
            this.labelPrenume.Text = "Prenume";
            // 
            // labelVarsta
            // 
            this.labelVarsta.AutoSize = true;
            this.labelVarsta.Location = new System.Drawing.Point(222, 114);
            this.labelVarsta.Name = "labelVarsta";
            this.labelVarsta.Size = new System.Drawing.Size(37, 13);
            this.labelVarsta.TabIndex = 2;
            this.labelVarsta.Text = "Varsta";
            // 
            // labelProba1
            // 
            this.labelProba1.AutoSize = true;
            this.labelProba1.Location = new System.Drawing.Point(218, 144);
            this.labelProba1.Name = "labelProba1";
            this.labelProba1.Size = new System.Drawing.Size(41, 13);
            this.labelProba1.TabIndex = 3;
            this.labelProba1.Text = "Proba1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "varstaMinima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "varstaMaxima";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Proba2";
            // 
            // buttonAdaugaInscriere
            // 
            this.buttonAdaugaInscriere.Location = new System.Drawing.Point(316, 270);
            this.buttonAdaugaInscriere.Name = "buttonAdaugaInscriere";
            this.buttonAdaugaInscriere.Size = new System.Drawing.Size(139, 37);
            this.buttonAdaugaInscriere.TabIndex = 7;
            this.buttonAdaugaInscriere.Text = "Adauga inscriere";
            this.buttonAdaugaInscriere.UseVisualStyleBackColor = true;
            this.buttonAdaugaInscriere.Click += new System.EventHandler(this.buttonAdaugaInscriere_Click);
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(316, 48);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(100, 20);
            this.textBoxNume.TabIndex = 8;
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Location = new System.Drawing.Point(316, 77);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrenume.TabIndex = 9;
            // 
            // textBoxVarsta
            // 
            this.textBoxVarsta.Location = new System.Drawing.Point(316, 111);
            this.textBoxVarsta.Name = "textBoxVarsta";
            this.textBoxVarsta.Size = new System.Drawing.Size(100, 20);
            this.textBoxVarsta.TabIndex = 10;
            // 
            // textBoxProba1
            // 
            this.textBoxProba1.Location = new System.Drawing.Point(316, 141);
            this.textBoxProba1.Name = "textBoxProba1";
            this.textBoxProba1.Size = new System.Drawing.Size(100, 20);
            this.textBoxProba1.TabIndex = 11;
            // 
            // textBoxVarstaMin
            // 
            this.textBoxVarstaMin.Location = new System.Drawing.Point(316, 180);
            this.textBoxVarstaMin.Name = "textBoxVarstaMin";
            this.textBoxVarstaMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxVarstaMin.TabIndex = 12;
            // 
            // textBoxVarstaMax
            // 
            this.textBoxVarstaMax.Location = new System.Drawing.Point(316, 207);
            this.textBoxVarstaMax.Name = "textBoxVarstaMax";
            this.textBoxVarstaMax.Size = new System.Drawing.Size(100, 20);
            this.textBoxVarstaMax.TabIndex = 13;
            // 
            // textBoxProba2
            // 
            this.textBoxProba2.Location = new System.Drawing.Point(316, 234);
            this.textBoxProba2.Name = "textBoxProba2";
            this.textBoxProba2.Size = new System.Drawing.Size(100, 20);
            this.textBoxProba2.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabInscrieri);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabInscrieri.ResumeLayout(false);
            this.tabProba.ResumeLayout(false);
            this.tabInscriere.ResumeLayout(false);
            this.tabInscriere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableParticipanti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabInscrieri;
        private System.Windows.Forms.TabPage tabProba;
        private System.Windows.Forms.Button buttonCauta;
        private System.Windows.Forms.DataGridView tableParticipanti;
        private System.Windows.Forms.DataGridView tableProbe;
        private System.Windows.Forms.TabPage tabInscriere;
        private System.Windows.Forms.TextBox textBoxVarsta;
        private System.Windows.Forms.TextBox textBoxPrenume;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Button buttonAdaugaInscriere;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProba1;
        private System.Windows.Forms.Label labelVarsta;
        private System.Windows.Forms.Label labelPrenume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.TextBox textBoxProba2;
        private System.Windows.Forms.TextBox textBoxVarstaMax;
        private System.Windows.Forms.TextBox textBoxVarstaMin;
        private System.Windows.Forms.TextBox textBoxProba1;
    }
}