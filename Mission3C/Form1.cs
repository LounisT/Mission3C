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
    public partial class Form1 : Form
    {
        private mission3Entities mesDonnees;
        public Form1()
        {
            InitializeComponent();
            this.mesDonnees = new mission3Entities();
        }

        private void gestiionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visiteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visiteurs v = new Visiteurs(this.mesDonnees);
            v.Show();

        }

        private void rapportVisiteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportVisiteur rv = new RapportVisiteur(this.mesDonnees);
            rv.Show();
        }
    }
}
