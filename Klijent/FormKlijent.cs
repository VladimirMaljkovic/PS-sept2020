using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FormKlijent : Form
    {
        private List<Zahtev> zahtevi;
        private List<Zahtev> zahteviZaBazu;  //kad se pozove dugme sacuvaj
        private BindingList<Zahtev> zahteviBinding;

        private List<OsiguranoLice> osiguranaLica;
        private List<Laboratorija> laboratorije;

        private Laborant laborant;

        private List<string> rezultati = new List<string> { "Pozitivan", "Negativan" };
        private List<string> tipTesta = new List<string> { "PCR", "Seroloski", "Antitela" };
        private List<string> status = new List<string> { "Neobradjen", "Obradjen", "Nedostaju podaci" };

        public FormKlijent(Laborant laborant)
        {
            InitializeComponent();
            this.laborant = laborant;
        }

        private void FormKlijent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 100);
            zahtevi = Connection.Instance.GetZahtevi();
            osiguranaLica = Connection.Instance.GetOsiguranaLica();
            laboratorije = Connection.Instance.GetLaboratorije();

            fixDGVData();
            adjustOrderAndNames();
        }


        private void fixDGVData()
        {
            zahteviBinding = new BindingList<Zahtev>(zahtevi);
            dgvZahtevi.DataSource = zahteviBinding;

            DataGridViewComboBoxColumn rezultatiCol = new DataGridViewComboBoxColumn
            {
                DataSource = rezultati,
                HeaderText = "Rezultat",
                Name = "RezultatCombo",
                FlatStyle = FlatStyle.Flat

            };

            DataGridViewComboBoxColumn tipTestaCol = new DataGridViewComboBoxColumn
            {
                DataSource = tipTesta,
                HeaderText = "Tip",
                Name = "TipCombo",
                FlatStyle = FlatStyle.Flat
            };

            DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn
            {
                DataSource = status,
                HeaderText = "Status",
                Name = "StatusCombo",
                FlatStyle = FlatStyle.Flat,
            };

            dgvZahtevi.Columns.Add(statusCol);
            dgvZahtevi.Columns.Add(rezultatiCol);
            dgvZahtevi.Columns.Add(tipTestaCol);


            foreach (DataGridViewRow row in dgvZahtevi.Rows)
            {
                int idLica = (int)row.Cells["OsiguranoLiceID"].Value;
                int idLab = (int)row.Cells["LaboratorijaID"].Value;
                OsiguranoLice lice = new OsiguranoLice();
                Laboratorija lab = new Laboratorija();
                lice = osiguranaLica.Find(x => x.OsiguranoLiceID == idLica);
                lab = laboratorije.Find(x => x.LaboratorijaID == idLab);
                row.Cells["ImePrezimeOsiguranogLica"].Value = lice.ImePrezime;
                row.Cells["NazivLaboratorije"].Value = lab.Naziv;

                row.Cells["StatusCombo"].Value = row.Cells["Status"].Value;
            }

        }

        private void adjustOrderAndNames()
        {
            dgvZahtevi.Columns["DatumVremeTestiranja"].DisplayIndex = 0;
            dgvZahtevi.Columns["DatumVremeTestiranja"].HeaderText = "Datum testiranja";

            dgvZahtevi.Columns["Napomena"].DisplayIndex = 7;
            dgvZahtevi.Columns["ImePrezimeOsiguranogLica"].DisplayIndex = 1;
            dgvZahtevi.Columns["ImePrezimeOsiguranogLica"].HeaderText = "Ime i prezime";

            dgvZahtevi.Columns["NazivLaboratorije"].DisplayIndex = 2;
            dgvZahtevi.Columns["NazivLaboratorije"].HeaderText = "Laboratorija";

            dgvZahtevi.Columns["Hitno"].DisplayIndex = 3;
            dgvZahtevi.Columns["TipCombo"].DisplayIndex = 4;
            dgvZahtevi.Columns["StatusCombo"].DisplayIndex = 5;
            dgvZahtevi.Columns["RezultatCombo"].DisplayIndex = 6;

            dgvZahtevi.Columns["ZahtevID"].Visible = false;
            dgvZahtevi.Columns["LaborantID"].Visible = false;
            dgvZahtevi.Columns["DatumVremeRezultata"].Visible = false;
            dgvZahtevi.Columns["Status"].Visible = false;
            dgvZahtevi.Columns["Rezultat"].Visible = false;
            dgvZahtevi.Columns["Tip"].Visible = false;
            dgvZahtevi.Columns["LaboratorijaID"].Visible = false;
            dgvZahtevi.Columns["OsiguranoLiceID"].Visible = false;
        }


        private void buttonIzmeniIzabrani_Click(object sender, EventArgs e)
        {
            ProveraIspravnosti();

            zahteviZaBazu = new List<Zahtev>();
            foreach (DataGridViewRow row in dgvZahtevi.Rows)
            {
                if ((string)row.Cells["StatusCombo"].Value != "Obradjen")
                    continue;
                Zahtev z = new Zahtev
                {
                    Status = (string)row.Cells["StatusCombo"].Value,
                    DatumVremeRezultata = DateTime.Now,
                    DatumVremeTestiranja = (DateTime)row.Cells["DatumVremeTestiranja"].Value,
                    Hitno = (bool)row.Cells["Hitno"].Value,
                    LaborantID = laborant.LaborantID,
                    LaboratorijaID = (int)row.Cells["LaboratorijaID"].Value,
                    Napomena = (string)row.Cells["Napomena"].Value,
                    OsiguranoLiceID = (int)row.Cells["OsiguranoLiceID"].Value,
                    Rezultat = (string)row.Cells["RezultatCombo"].Value,
                    Tip = (string)row.Cells["TipCombo"].Value,
                    ZahtevID = (int)row.Cells["ZahtevID"].Value,
                };
                zahteviZaBazu.Add(z);
            }
        }
        private void ProveraIspravnosti()
        {
            foreach (DataGridViewRow row in dgvZahtevi.Rows)
            {
                if ((string)row.Cells["StatusCombo"].Value != "Obradjen")
                    continue;


            }
        }

        private void buttonSacuvajObradjene_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
