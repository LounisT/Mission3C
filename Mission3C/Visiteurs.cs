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
    public partial class Visiteurs : Form
    {
        private mission3Entities mesDonnees;
        public Visiteurs(mission3Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;


            var LesVisiteurs = (from visiteur in mesDonnees.visiteur 
                                select visiteur);
            dataGridView1.DataSource = LesVisiteurs.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mesDonnees.SaveChanges();
            MessageBox.Show("Enregistré avec succès !");

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AjouterVisiteur a = new AjouterVisiteur(this.mesDonnees);
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupprimerVisiteur s = new SupprimerVisiteur(this.mesDonnees);
            s.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
