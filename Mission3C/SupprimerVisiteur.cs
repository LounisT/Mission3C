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
    public partial class SupprimerVisiteur : Form
    {
        private mission3Entities mesDonnees;
        public SupprimerVisiteur(mission3Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;

           

            var getId = (from visiteur in mesDonnees.visiteur
                         select visiteur.id);

            idCombo.DataSource = getId.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = idCombo.Text;
            string idAjt = idCombo.SelectedItem.ToString();

            var rapp = from v in mesDonnees.visiteur
                       join r in mesDonnees.rapport 
                       on v.id equals r.idVisiteur
                       select r;

            var unVisiteur = (from visiteur in mesDonnees.visiteur
                             where visiteur.id == idAjt 
                             select visiteur).First();

            visiteur SUPPRIMER = unVisiteur;

            string message = "Voulez-vous vraiment supprimer ce visiteur ?";
            string caption = "Supprimer un visiteur";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);


            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (rapp != null)
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer ce visiteur, il possède des rapports !");
                }
                else
                {
                    string a = idAjt;
                    visiteur supprimer = new visiteur { id = idAjt };
                    mesDonnees.visiteur.Remove(SUPPRIMER);
                    mesDonnees.SaveChanges();
                    MessageBox.Show("Le visiteur " + a + " à bien été supprimer !");
                }
                
            }
        }

        private void SupprimerVisiteur_Load(object sender, EventArgs e)
        {

        }

        private void idCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
