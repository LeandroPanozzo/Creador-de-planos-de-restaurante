using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalRestaurante
{
    public partial class ElegirModoForm : Form
    {
        public ElegirModoForm()
        {
            InitializeComponent();
        }

        private void EditarBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form1
            Form1 form1 = new Form1();

            // Mostrar Form1
            form1.Show();
        }

        private void PrevisualizacionBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia de PrevisualizacionForm
            PrevisualizacionForm previsualizacionForm = new PrevisualizacionForm();

            previsualizacionForm.Show();

        }

        private void ElegirModoForm_Load(object sender, EventArgs e)
        {

        }

        private void SalirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
