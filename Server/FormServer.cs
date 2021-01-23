using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormServer : Form
    {
        private Server s;
        public FormServer()
        {
            InitializeComponent();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            s = new Server();
            Thread thread = new Thread(s.StartServer);
            thread.IsBackground = true;
            thread.Start();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(600, 500);
        }
    }
}
