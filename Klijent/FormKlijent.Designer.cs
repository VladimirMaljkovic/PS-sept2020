
namespace Klijent
{
    partial class FormKlijent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvZahtevi = new System.Windows.Forms.DataGridView();
            this.buttonIzmeniIzabrani = new System.Windows.Forms.Button();
            this.buttonSacuvajObradjene = new System.Windows.Forms.Button();
            this.zahtevBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahtevBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.formKlijentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formKlijentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZahtevi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahtevBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahtevBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formKlijentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formKlijentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvZahtevi
            // 
            this.dgvZahtevi.AllowUserToAddRows = false;
            this.dgvZahtevi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvZahtevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZahtevi.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvZahtevi.Location = new System.Drawing.Point(13, 12);
            this.dgvZahtevi.Name = "dgvZahtevi";
            this.dgvZahtevi.Size = new System.Drawing.Size(876, 249);
            this.dgvZahtevi.TabIndex = 0;
            // 
            // buttonIzmeniIzabrani
            // 
            this.buttonIzmeniIzabrani.Location = new System.Drawing.Point(13, 267);
            this.buttonIzmeniIzabrani.Name = "buttonIzmeniIzabrani";
            this.buttonIzmeniIzabrani.Size = new System.Drawing.Size(104, 45);
            this.buttonIzmeniIzabrani.TabIndex = 1;
            this.buttonIzmeniIzabrani.Text = "Izmeni izabrani zahtev";
            this.buttonIzmeniIzabrani.UseVisualStyleBackColor = true;
            this.buttonIzmeniIzabrani.Click += new System.EventHandler(this.buttonIzmeniIzabrani_Click);
            // 
            // buttonSacuvajObradjene
            // 
            this.buttonSacuvajObradjene.Location = new System.Drawing.Point(132, 267);
            this.buttonSacuvajObradjene.Name = "buttonSacuvajObradjene";
            this.buttonSacuvajObradjene.Size = new System.Drawing.Size(104, 45);
            this.buttonSacuvajObradjene.TabIndex = 2;
            this.buttonSacuvajObradjene.Text = "Sacuvaj obradjene zahteve";
            this.buttonSacuvajObradjene.UseVisualStyleBackColor = true;
            this.buttonSacuvajObradjene.Click += new System.EventHandler(this.buttonSacuvajObradjene_Click);
            // 
            // zahtevBindingSource
            // 
            this.zahtevBindingSource.DataSource = typeof(Domen.Zahtev);
            // 
            // zahtevBindingSource1
            // 
            this.zahtevBindingSource1.DataSource = typeof(Domen.Zahtev);
            // 
            // formKlijentBindingSource
            // 
            this.formKlijentBindingSource.DataSource = typeof(Klijent.FormKlijent);
            // 
            // formKlijentBindingSource1
            // 
            this.formKlijentBindingSource1.DataSource = typeof(Klijent.FormKlijent);
            // 
            // FormKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 323);
            this.Controls.Add(this.buttonSacuvajObradjene);
            this.Controls.Add(this.buttonIzmeniIzabrani);
            this.Controls.Add(this.dgvZahtevi);
            this.Name = "FormKlijent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Klijent";
            this.Load += new System.EventHandler(this.FormKlijent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZahtevi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahtevBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahtevBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formKlijentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formKlijentBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvZahtevi;
        private System.Windows.Forms.Button buttonIzmeniIzabrani;
        private System.Windows.Forms.Button buttonSacuvajObradjene;
        private System.Windows.Forms.BindingSource formKlijentBindingSource1;
        private System.Windows.Forms.BindingSource formKlijentBindingSource;
        private System.Windows.Forms.BindingSource zahtevBindingSource;
        private System.Windows.Forms.BindingSource zahtevBindingSource1;
    }
}

