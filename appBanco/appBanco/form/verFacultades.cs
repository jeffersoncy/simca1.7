using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appBanco.logica;
namespace appBanco
{
    public partial class verFacultades : Form
    {
        public verFacultades()
        {
            InitializeComponent();
            Facultad obj = new Facultad();

            DataSet dataSet = new DataSet();  //<- para obtener datos
            dataSet = obj.mostrarFacultades();

            dgvVer.DataSource = dataSet.Tables[0];

        }

        private void btnConsultarDepartamentos_Click(object sender, EventArgs e)
        {
           
            Facultad obj = new Facultad();

            DataSet dataSet = new DataSet();  //<- para obtener datos
            dataSet = obj.mostrarFacultades();

            dgvVer.DataSource = dataSet.Tables[0];
        }
    }
}
