using appMarket.Layers.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMarket
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmTarjeta();
            frm.ShowDialog();
        }

        private void provincesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProvincia();
            frm.ShowDialog();
        }
    }
}
