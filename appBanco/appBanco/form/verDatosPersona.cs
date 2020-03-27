using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using appBanco.logica;

namespace appBanco
{
    public partial class verDatosPersona : Form
    {
        public verDatosPersona()
        {
            InitializeComponent();
        }
        Persona PersonaVista = new Persona();
        DataSet miDs2 = new DataSet();
        private void btnConsulClient_Click(object sender, EventArgs e)
        {
            miDs2 = PersonaVista.mostrarPersona();
            if (miDs2.Tables[0].Rows.Count > 0)
            {
                dgvMostrarClientes.DataSource = miDs2.Tables[0];
            }
            else
            {
                MessageBox.Show("No hay Datos Registrados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
