using appMarket.Interfaces;
using appMarket.Layers.Entities;
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
    public partial class frmTarjeta : Form
    {
        public frmTarjeta()
        {
            InitializeComponent();
        }

        private void frmTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTarjetas.DataSource = new BLL.BLLTarjeta().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                IBLLTarjeta bll = new BLL.BLLTarjeta();
                Tarjeta tarjeta = new Tarjeta();
                tarjeta.IdTarjeta = (int)nudId.Value;
                tarjeta.DescripcionTarjeta = txtDescripcion.Text;

                bll.Save(tarjeta);

                MessageBox.Show("Tarjeta guardada!");
                dgvTarjetas.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvTarjetas_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTarjetas.SelectedRows.Count > 0) 
            {
                Tarjeta t = dgvTarjetas.SelectedRows[0].DataBoundItem as Tarjeta;
                nudId.Value = t.IdTarjeta;
                txtDescripcion.Text = t.DescripcionTarjeta;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("Seguro?", "Pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    int id = (int)nudId.Value;
                    IBLLTarjeta bll = new BLL.BLLTarjeta();

                    bll.Delete(id);

                    MessageBox.Show("Tarjeta eliminada!");
                    dgvTarjetas.DataSource = bll.GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
