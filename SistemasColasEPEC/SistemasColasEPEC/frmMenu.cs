using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasColasEPEC
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnPrimerSistema_Click(object sender, EventArgs e)
        {
            frmPrimerSistema frmPrimerSistema = new frmPrimerSistema();
            frmPrimerSistema.Show();
        }

        private void btnSegundoSistema_Click(object sender, EventArgs e)
        {
            frmSegundoSistema frmSegundoSistema = new frmSegundoSistema();
            frmSegundoSistema.Show();
        }
    }
}
