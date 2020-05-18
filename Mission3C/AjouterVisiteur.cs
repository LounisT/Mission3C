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
    public partial class AjouterVisiteur : Form
    {
        private mission3Entities mesDonnees;
        public AjouterVisiteur(mission3Entities mesDonnees)
        {
            InitializeComponent();
            this.mesDonnees = mesDonnees;
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            bool requete = true;
            string idAjt = idtextbox.Text;
            string nomAjt = nomtextbox.Text;
            string prenomAjt = prenomtextbox.Text;
            string loginAjt = logintextbox.Text;
            string mdpAjt = mdptextbox.Text;
            string adresseAjt = adressetextbox.Text;
            string cpAjt = cptextbox.Text;
            string villeAjt = villetextbox.Text;
            dateTimePicker1.MinDate = DateTime.Today;
            DateTime dateembaucheAjt = dateTimePicker1.MinDate;



            if (idtextbox.Text == "" || nomtextbox.Text == "" || prenomtextbox.Text == "" || logintextbox.Text == "" || mdptextbox.Text == "" || adressetextbox.Text == "" || cptextbox.Text == "" || villetextbox.Text == "")
            {
                requete = false;
                string message = "Veuillez remplir tous les champs !";
                string caption = "Saisi vide";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            
            else if (requete)
            {
                
                string message = "Voulez-vous vraiment ajouter ce visiteur ?";
                string caption = "Ajouter un visiteur";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);


                if (result == System.Windows.Forms.DialogResult.OK)
                {
                   
                    string a = idAjt;
                    visiteur ajouter = new visiteur { id = idAjt, nom = nomAjt, prenom = prenomAjt, login = loginAjt, mdp = mdpAjt, adresse = adresseAjt, cp = cpAjt, ville = villeAjt, dateEmbauche = dateembaucheAjt};
                    mesDonnees.visiteur.Add(ajouter);
                    mesDonnees.SaveChanges();
                    MessageBox.Show("Le visiteur " + a +  " à bien été ajouté !");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mdptextbox.Text = GetRandomMDP();
            logintextbox.Text = GetRandomLogin();

        }

        private string GetRandomMDP()
        {
            char[] m = "abcdefghijklm".ToCharArray();
            Random r = new Random();
            string random = "";
            for (int i = 0; i < 4; i++)
            {
                random += m[r.Next(0, 13)].ToString();
            }
            return random;
        }

        private string GetRandomLogin()
        {
            char[] l = "AbcDefghIJKLMNOPqRstuvwxYZ".ToCharArray();
            Random r = new Random();
            string random = "";
            for (int i = 0; i < 5; i++)
            {
                random += l[r.Next(0, 26)].ToString();
            }
            return random;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}