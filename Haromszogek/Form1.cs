using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
    public partial class frmFo : Form
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;


        public frmFo()
        {
            aOldal = 0;
            bOldal = 0;
            cOldal = 0;
            InitializeComponent();
            tbaoldal.Text = aOldal.ToString();
            tbbolal.Text = bOldal.ToString();
            tbcoldal.Text = cOldal.ToString();
            lbHaromszogLista.Items.Clear();
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSzamol_Click(object sender, EventArgs e)
        {
            try
            {
                aOldal = double.Parse(tbaoldal.Text);
                bOldal = double.Parse(tbbolal.Text);
                cOldal = double.Parse(tbcoldal.Text);

                if (aOldal == 0 || bOldal == 0 || cOldal == 0)
                {
                    MessageBox.Show("Egyik oldal sem lehet 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    var h = new Haromszog(aOldal, bOldal, cOldal);

                    List<string> adatok = h.AdatokSzoveg();

                    foreach (var a in adatok)
                    {
                        lbHaromszogLista.Items.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Számot adj meg","Hiba",MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbaoldal.Focus();
            }
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (lbHaromszogLista.Items.Count > 0)
            {
                lbHaromszogLista.Items.Clear();
            }
            else
            {
                MessageBox.Show("Nincs mit törölni");
            }
            
        }
    }
}
