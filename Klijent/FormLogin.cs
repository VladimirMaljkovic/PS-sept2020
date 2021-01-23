using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Klijent
{
    public partial class FormLogin : Form
    {
        private Laborant laborant;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (!Connection.Instance.Connect())
            {
                MessageBox.Show("Connection failed");
                return;
            }
        }

        private void buttonPrijaviSe_Click(object sender, EventArgs e)
        {
            laborant = Connection.Instance.Login(txtUsername.Text, txtPassword.Text);
            if (laborant == null)
            {
                MessageBox.Show("Nema tog");
                return;
            }
            FormKlijent formKlijent = new FormKlijent(laborant);
            this.Visible = false;
            formKlijent.ShowDialog();
            this.Visible = true;
        }
    }
}
