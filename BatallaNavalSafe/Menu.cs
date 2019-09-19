using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatallaNaval
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnSemi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Game semiAuto = new Game();            
            semiAuto.Show();
            this.Cursor = Cursors.Arrow;
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            ModoAuto auto = new ModoAuto();
            auto.Show();
        }
    }
}
