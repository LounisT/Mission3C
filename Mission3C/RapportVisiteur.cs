using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission3C
{
    public partial class RapportVisiteur : Form
    {

        private mission3Entities mesDonnees;
        public DataTable table = new DataTable();
        public RapportVisiteur(mission3Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;


            var getIdVisiteur = (from rapport in mesDonnees.rapport
                                 orderby rapport.idVisiteur
                                 select rapport.idVisiteur).Distinct();
            comboBox1.DataSource = getIdVisiteur.ToList();

            dataGridView1.Visible = true;
            comboBox1.Visible = true;

            var GetRapports = (from rapport in mesDonnees.rapport
                               select rapport);
            dataGridView1.DataSource = GetRapports.ToList();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;
            comboBox1.Visible = true;
            string idv = comboBox1.Text;

            var lesId = (from rapport in mesDonnees.rapport
                         where rapport.idVisiteur == idv
                         select rapport);
            dataGridView1.DataSource = lesId.ToList();


            List<ResultLine> result = lesId
            .GroupBy(l => l.idVisiteur)
            .Select(cl => new ResultLine
            {
                idVisiteur = cl.FirstOrDefault().idVisiteur.ToString()
            }).ToList();

            //dataGridView1.DataSource = result .;
        }



        private void button2_Click(object sender, EventArgs e) 
        {
            var exporXML = (from rapport in mesDonnees.rapport
                            where rapport.idVisiteur == comboBox1.Text
                            select new { rapport.id, rapport.date, rapport.motif, rapport.bilan, rapport.idVisiteur }
                            ).ToList();

            List<ResultLine> result = exporXML
      .GroupBy(l => l.idVisiteur)
      .Select(cl => new ResultLine
      {
          Id = cl.FirstOrDefault().id.ToString(),
          date = cl.FirstOrDefault().date.ToString(),
          motif = cl.FirstOrDefault().motif.ToString(),
          bilan = cl.FirstOrDefault().bilan.ToString(),
          idVisiteur = cl.FirstOrDefault().idVisiteur.ToString(),
      }).ToList();

            table.Columns.Add("id", typeof(string));
            table.Columns.Add("Date", typeof(string));
            table.Columns.Add("Motif", typeof(string));
            table.Columns.Add("Bilan", typeof(string));
            table.Columns.Add("idVisiteur", typeof(string));

            foreach (var v in result)
            {
                table.Rows.Add(v.Id, v.date, v.motif, v.bilan, v.idVisiteur);
            }

            string a = comboBox1.Text;
            this.dataGridView1.DataSource = this.bindingSource1;
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.WriteXml("RapportVisiteur.xml");
            this.Close();
            MessageBox.Show("Les rapports du visiteur " + a + " ont été exportés en XML avec succès ! Votre fichier se situe dans Mission3C/bin/Debug.");
            table.Reset();


        }
        /*private void button1_Click(object sender, EventArgs e)
        {

        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}


        
    
