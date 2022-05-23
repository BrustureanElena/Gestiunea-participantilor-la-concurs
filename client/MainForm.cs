
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;
using services;



namespace client
{
    public partial class MainForm : Form
    {
      
        
        
 
        private readonly List<ProbaDTO> probeData;
        
        private readonly ConcursClientCtrl ctrl;

        public MainForm(ConcursClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
           
            probeData = ctrl.getToateProbeleDTO();
            tableProbe.DataSource = probeData;
            tableProbe.AutoResizeColumns();
            
            tableProbePtInscriere.DataSource = ctrl.getToateProbele();
            tableProbePtInscriere.AutoResizeColumns();
          //lavi 
          
          
            /*tabProba.Controls.Add(tableProbe);
            tabInscriere.Controls.Add(tableProbePtInscriere);
            tabProba.Controls.Add(tableParticipanti);
            tabProba.Controls.Add(buttonCauta);
            */
            
            ctrl.updateEvent += inscriereUpdated;
            
           
            


        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // tableProbe.DataSource = ctrl.getToateProbeleDTO();
           //  tableProbePtInscriere.DataSource = ctrl.getToateProbele();
          //  tableProbe.AutoGenerateColumns = true;
        }
        private void updateDataGridBox(DataGridView dataGrid, IList<ProbaDTO> newData)
        {
            //tableParticipanti.Refresh();
            tableProbe.Refresh();
            tableProbe.DataSource = newData;
            tableProbe.AutoResizeColumns();          
                                             
        }
        public delegate void UpdateDataGridBoxCallback(DataGridView dataGrid, IList<ProbaDTO> newData);
       private void inscriereUpdated(object sender, ConcursEventArgs e)
        {
            if (e.ConcursEventType == ConcursEvent.AddInscriere)
            {
                    long id = e.Data.Proba.Id;
                
                    ProbaDTO probaDto = probeData.Find(proba => proba.Id.Equals(id));
                   
                    var nr = probaDto.nrParticipanti;
                
                   probaDto.nrParticipanti = nr + 1;
               
                   
                    int index = probeData.IndexOf(probaDto);
                   //probeData[index] = null;
                    
                    probeData.Insert(index,probaDto);
                    probeData.Remove(probaDto);
                    tableProbe.BeginInvoke(new UpdateDataGridBoxCallback(this.updateDataGridBox),
                        new Object[] {tableProbe, probeData});
                  
                
            }
            //tableProbe.DataSource = null;
           // tableProbe.Invoke(new UpdateDataGridBoxCallback(this.updateDataGridBox),
             //   new Object[] {tableProbe, probeData});

        }
      //lavi
      
   
     /* public void inscriereUpdated(object sender, ConcursEventArgs e)
      {
          if (e.ConcursEventType==ConcursEvent.AddInscriere)
          {
              long idProba = Int64.Parse(e.Data.ToString());
              foreach (DataGridViewRow row in this.tableProbe.Rows)
                  if (Convert.ToInt32(row.Cells[1].Value) == idProba)
                  {
                      int value = Int32.Parse(row.Cells[0].Value.ToString());
                      value++;
                      row.Cells[0].Value = value;
                  }
                

          }
      }
     
        */
        

        private void button1_Click(object sender, EventArgs e)
        {
            ctrl.updateEvent -= inscriereUpdated;
            ctrl.logout();

            this.Close();

        }

        private void buttonAdaugaInscriere_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("button");
                string numeParticipant = textBoxNume.Text;
                string prenumeParticipant = textBoxPrenume.Text;
                string varstaParticipantS = textBoxVarsta.Text;
                int varstaParticipant = Convert.ToInt32(varstaParticipantS);

                DataGridViewRow row = tableProbePtInscriere.SelectedRows[0];
                string idS = row.Cells[0].Value.ToString();
                long id = Convert.ToInt64(idS);


                //  Proba proba = new Proba(denumire, varstaMin, varstaMax);
                Proba probaGasita = ctrl.getProba(id);
                Console.WriteLine(probaGasita);
                Participant participant = new Participant(numeParticipant, prenumeParticipant, varstaParticipant);
                Console.WriteLine(participant);
                Inscriere inscriere = new Inscriere(participant, probaGasita);
                Console.WriteLine(inscriere);
                //ctrl.addInscriere(inscriere);
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
                         
                         ctrl.addInscriere(inscriere);
                    
 
 
                 /*    tableProbe.Refresh();
                  tableProbe.DataSource = ctrl.getToateProbeleDTO();
                     tableProbe.AutoResizeColumns();*/
                     textBoxNume.Clear();
                     textBoxPrenume.Clear();
                     textBoxVarsta.Clear();
               
                   MessageBox.Show("Adaugat cu succes!", "Yey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
             }
             catch (ConcursException ex)
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
                long id = Convert.ToInt64(idS); 
              
              Proba probaGasita = ctrl.getProba(id);
                Console.WriteLine(probaGasita);
                
                tableParticipanti.DataSource = ctrl.getParticipantiProbaVarsta(probaGasita);
                tableParticipanti.AutoResizeColumns() ;

            }
            catch (ConcursException ex)
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
               // Proba probaGasita = ctrl.findOneByDenumireVarsta(denumire, varstaMin, varstaMax);
               // Console.WriteLine(probaGasita);
               
                //tableParticipanti.DataSource = Service.getParticipantiProbaVarsta(probaGasita);
                tableParticipanti.AutoResizeColumns();

            }
            catch (ConcursException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
