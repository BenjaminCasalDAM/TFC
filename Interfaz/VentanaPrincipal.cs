using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFC_Benjamin
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_Platos_Click(object sender, EventArgs e)
        {
            VentanaPlatos vtaPlatos = new VentanaPlatos();
            this.Hide();
            vtaPlatos.ShowDialog();
            this.Close();
        }

        private void button_Ingredientes_Click(object sender, EventArgs e)
        {
            VentanaIngredientes vtaIngredientes = new VentanaIngredientes();
            this.Hide();
            vtaIngredientes.ShowDialog();
            this.Close();
        }

        private void button_Seguimiento_Click(object sender, EventArgs e)
        {
            VentanaSeguimiento vtaSeguimiento = new VentanaSeguimiento();
            this.Hide();
            vtaSeguimiento.ShowDialog();
            this.Close();
        }
    }
}
