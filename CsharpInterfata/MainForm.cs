using CSharp.domain;
using CSharp.service;
using CSharp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpInterfata
{
    public partial class MainForm : Form
    {
        Service Service { get; set; }
        Form1 loginCtr;
        public MainForm(Service service, Form1 loginCtrLLL)
        {
            InitializeComponent();
            Service = service;
            loginCtr = loginCtrLLL;
            tabProba.Controls.Add(tableProbe);
            tabInscriere.Controls.Add(tableProbePtInscriere);
            tabProba.Controls.Add(tableParticipanti);
            tabProba.Controls.Add(buttonCauta);
       

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableProbe.DataSource = Service.getToateProbeleDTO();
            tableProbePtInscriere.DataSource = Service.getToateProbele();
            tableProbe.AutoGenerateColumns = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service.logout();
            this.Close();
            loginCtr.Show();
        }

        private void buttonAdaugaInscriere_Click(object sender, EventArgs e)
        {
            try
            {
                string numeParticipant = textBoxNume.Text;
                string prenumeParticipant = textBoxPrenume.Text;
                string varstaParticipantS = textBoxVarsta.Text;
                int varstaParticipant = Convert.ToInt32(varstaParticipantS);

                DataGridViewRow row = tableProbePtInscriere.SelectedRows[0];
                string idS = row.Cells[0].Value.ToString();
                string denumire = row.Cells[1].Value.ToString();
                string varstaMinS = row.Cells[2].Value.ToString();
                string varstaMaxS = row.Cells[3].Value.ToString();
                int varstaMin = Convert.ToInt32(varstaMinS);
                int varstaMax = Convert.ToInt32(varstaMaxS);
                //  Proba proba = new Proba(denumire, varstaMin, varstaMax);
                Proba probaGasita = Service.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
               
                if (numeParticipant.Equals("") || prenumeParticipant.Equals(""))
                {
                    MessageBox.Show("Nume sau prenume invalid! ", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                if (probaGasita == null)
                {
                    MessageBox.Show("Probe invalide", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (probaGasita != null)

                        Service.addInscriere(numeParticipant, prenumeParticipant, varstaParticipant, probaGasita);
                   


                    tableProbe.Refresh();
                    tableProbe.DataSource = Service.getToateProbeleDTO();
                    tableProbe.AutoResizeColumns();
                    textBoxNume.Clear();
                    textBoxPrenume.Clear();
                    textBoxVarsta.Clear();
              
                    MessageBox.Show("Adaugat cu succes!", "Yey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
           try
            {

                DataGridViewRow row = tableProbe.SelectedRows[0];
                string idS = row.Cells[1].Value.ToString();
                string denumire = row.Cells[2].Value.ToString();
                string varstaMinS = row.Cells[3].Value.ToString();
                string varstaMaxS = row.Cells[4].Value.ToString();
                int varstaMin = Convert.ToInt32(varstaMinS); 
                int varstaMax = Convert.ToInt32(varstaMaxS);
              //  Proba proba = new Proba(denumire, varstaMin, varstaMax);
                Proba probaGasita = Service.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
                Console.WriteLine(probaGasita);
                long id = Convert.ToInt64(idS);  
                tableParticipanti.DataSource = Service.getParticipantiProbaVarsta(probaGasita);
                tableParticipanti.AutoResizeColumns() ;

            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tabInscriere_Click(object sender, EventArgs e)
        {

        }

        private void tableProbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                String idS = tableProbe.Rows[e.RowIndex].Cells[1].Value.ToString();
                long id = Convert.ToInt64(idS);
              
                string denumire = tableProbe.Rows[e.RowIndex].Cells[2].Value.ToString();
                string varstaMinS = tableProbe.Rows[e.RowIndex].Cells[3].Value.ToString();
                string varstaMaxS = tableProbe.Rows[e.RowIndex].Cells[4].Value.ToString();
                int varstaMin = Convert.ToInt32(varstaMinS);
                int varstaMax = Convert.ToInt32(varstaMaxS);
                Proba probaGasita = Service.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
                Console.WriteLine(probaGasita);
               
                tableParticipanti.DataSource = Service.getParticipantiProbaVarsta(probaGasita);
                tableParticipanti.AutoResizeColumns();

            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
