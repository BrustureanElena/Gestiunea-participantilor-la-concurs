namespace client
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
            this.buttonCauta = new System.Windows.Forms.Button();
            this.tableParticipanti = new System.Windows.Forms.DataGridView();
            this.tableProbe = new System.Windows.Forms.DataGridView();
            this.tabInscriere = new System.Windows.Forms.TabPage();
            this.textBoxVarsta = new System.Windows.Forms.TextBox();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.buttonAdaugaInscriere = new System.Windows.Forms.Button();
            this.labelVarsta = new System.Windows.Forms.Label();
            this.labelPrenume = new System.Windows.Forms.Label();
            this.labelNume = new System.Windows.Forms.Label();
            this.tableProbePtInscriere = new System.Windows.Forms.DataGridView();
            this.tabInscrieri.SuspendLayout();
            this.tabProba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableParticipanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbe)).BeginInit();
            this.tabInscriere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbePtInscriere)).BeginInit();
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
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(314, 6);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(75, 23);
            this.buttonCauta.TabIndex = 2;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // tableParticipanti
            // 
            this.tableParticipanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableParticipanti.Location = new System.Drawing.Point(395, 30);
            this.tableParticipanti.Name = "tableParticipanti";
            this.tableParticipanti.Size = new System.Drawing.Size(284, 319);
            this.tableParticipanti.TabIndex = 1;
            // 
            // tableProbe
            // 
            this.tableProbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableProbe.Location = new System.Drawing.Point(25, 30);
            this.tableProbe.Name = "tableProbe";
            this.tableProbe.Size = new System.Drawing.Size(327, 319);
            this.tableProbe.TabIndex = 0;
            this.tableProbe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableProbe_CellContentClick);
            // 
            // tabInscriere
            // 
            this.tabInscriere.Controls.Add(this.tableProbePtInscriere);
            this.tabInscriere.Controls.Add(this.textBoxVarsta);
            this.tabInscriere.Controls.Add(this.textBoxPrenume);
            this.tabInscriere.Controls.Add(this.textBoxNume);
            this.tabInscriere.Controls.Add(this.buttonAdaugaInscriere);
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
            // textBoxVarsta
            // 
            this.textBoxVarsta.Location = new System.Drawing.Point(437, 221);
            this.textBoxVarsta.Name = "textBoxVarsta";
            this.textBoxVarsta.Size = new System.Drawing.Size(100, 20);
            this.textBoxVarsta.TabIndex = 10;
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Location = new System.Drawing.Point(437, 175);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrenume.TabIndex = 9;
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(437, 129);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(100, 20);
            this.textBoxNume.TabIndex = 8;
            // 
            // buttonAdaugaInscriere
            // 
            this.buttonAdaugaInscriere.Location = new System.Drawing.Point(382, 271);
            this.buttonAdaugaInscriere.Name = "buttonAdaugaInscriere";
            this.buttonAdaugaInscriere.Size = new System.Drawing.Size(139, 37);
            this.buttonAdaugaInscriere.TabIndex = 7;
            this.buttonAdaugaInscriere.Text = "Adauga inscriere";
            this.buttonAdaugaInscriere.UseVisualStyleBackColor = true;
            this.buttonAdaugaInscriere.Click += new System.EventHandler(this.buttonAdaugaInscriere_Click);
            // 
            // labelVarsta
            // 
            this.labelVarsta.AutoSize = true;
            this.labelVarsta.Location = new System.Drawing.Point(365, 221);
            this.labelVarsta.Name = "labelVarsta";
            this.labelVarsta.Size = new System.Drawing.Size(37, 13);
            this.labelVarsta.TabIndex = 2;
            this.labelVarsta.Text = "Varsta";
            // 
            // labelPrenume
            // 
            this.labelPrenume.AutoSize = true;
            this.labelPrenume.Location = new System.Drawing.Point(353, 175);
            this.labelPrenume.Name = "labelPrenume";
            this.labelPrenume.Size = new System.Drawing.Size(49, 13);
            this.labelPrenume.TabIndex = 1;
            this.labelPrenume.Text = "Prenume";
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(365, 132);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(35, 13);
            this.labelNume.TabIndex = 0;
            this.labelNume.Text = "Nume";
            // 
            // tableProbePtInscriere
            // 
            this.tableProbePtInscriere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableProbePtInscriere.Location = new System.Drawing.Point(29, 55);
            this.tableProbePtInscriere.Name = "tableProbePtInscriere";
            this.tableProbePtInscriere.Size = new System.Drawing.Size(293, 253);
            this.tableProbePtInscriere.TabIndex = 11;
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
            ((System.ComponentModel.ISupportInitialize)(this.tableParticipanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbe)).EndInit();
            this.tabInscriere.ResumeLayout(false);
            this.tabInscriere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableProbePtInscriere)).EndInit();
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
        private System.Windows.Forms.Label labelVarsta;
        private System.Windows.Forms.Label labelPrenume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.DataGridView tableProbePtInscriere;
    }
}