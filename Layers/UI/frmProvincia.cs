using appMarket.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMarket.Layers.UI
{
    public partial class frmProvincia : Form
    {
        public frmProvincia()
        {
            InitializeComponent();
        }

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            try
            {
                IBLLProvincia bll = new BLL.BLLProvincia();
                dgvProvincias.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }
    }
}
