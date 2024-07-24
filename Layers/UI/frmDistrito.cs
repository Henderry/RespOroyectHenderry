using appMarket.Interfaces;
using appMarket.Layers.BLL;
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
    public partial class cmbDistrito : Form
    {
        public cmbDistrito()
        {

            InitializeComponent();
        }
        int asd;
        int awd;
        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void frmDistrito_Load(object sender, EventArgs e)
        {
            try
            {
                IBLLProvincia bll= new BLLProvincia();
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
