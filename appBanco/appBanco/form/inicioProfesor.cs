using System;
using appBanco;
using System.Windows.Forms;
using appBanco.logica;
using appBanco.accesoDatos;
using appBanco.logica;
using System.Data;

namespace FormulariosDeRegistro
{
    public partial class inicioProfesor : Form
    {
        private String codigo = "";
        private String codigoProfesor = "";
        DataSet miDS = new DataSet();
        DataSet DSEstudiante;
        Nota objNota = new Nota();
        public inicioProfesor(String codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
            login loginProfesor = new login();
            codigoProfesor = loginProfesor.MostrarDatosDocente(codigo).Tables["ResultadoDatos"].Rows[0]["PROFESOR_CODIGO"].ToString();
            lblCodProf.Text = "Código: " + codigo + codigoProfesor;
            lblNombresProf.Text = "Nombre: "+loginProfesor.MostrarDatosPersona(codigo).Tables["ResultadoDatos"].Rows[0]["PERSONA_NOMBRE"].ToString();
            lblPersonaApellido.Text = "Apellidos: " + loginProfesor.MostrarDatosPersona(codigo).Tables["ResultadoDatos"].Rows[0]["PERSONA_APELLIDO"].ToString();
            lblIDProf.Text = "Identificación: " + loginProfesor.MostrarDatosPersona(codigo).Tables["ResultadoDatos"].Rows[0]["PERSONA_IDENT"].ToString();
            lblUsuarioProf.Text = loginProfesor.MostrarDatosPersona(codigo).Tables["ResultadoDatos"].Rows[0]["PERSONA_USUARIO"].ToString();
            lblAreaProf.Text = "Area: "+loginProfesor.MostrarDatosDocente(codigo).Tables["ResultadoDatos"].Rows[0]["profesor_area"].ToString();
            lblEspecProf.Text = "Especialización: " + loginProfesor.MostrarDatosDocente(codigo).Tables["ResultadoDatos"].Rows[0]["PROFESOR_ESPECIALIZACION"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Hide();
            obj.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Docente objDocente = new Docente();
            DataSet dataset = new DataSet();
            dataset = objDocente.consultarHorarioProfesor(int.Parse(this.codigoProfesor));
            dgvHorarioProfesor.DataSource = dataset.Tables[0];
        }

        private void btnConsultarCursos_Click(object sender, EventArgs e)
        {
            Docente objDocente = new Docente();
            DataSet dataset = new DataSet();
            dataset = objDocente.materiasImparteProfesor(int.Parse(this.codigoProfesor));
            dgvCursos.DataSource = dataset.Tables[0];
        }
        #region PreCargarComboBoxes
        private void inicioProfesor_Load_1(object sender, EventArgs e)
        {
            Docente objDoc = new Docente();
            miDS = objDoc.materiasImparteProfesor(int.Parse(this.codigoProfesor));
            int total = miDS.Tables[0].Rows.Count;
            for (int i = 0; i < total; i++)
            {
                cmboxcursos.DataSource = miDS.Tables["ResultadoDatos"];
                cmboxcursos.DisplayMember = "GRUPO_NOMBRE";
                cmboxcursos.ValueMember = "grupo_codigo";
            }
            cmboxcursos.Text = "--- Seleccione un curso ---";
            if (cmboxcursos.SelectedIndex == 0)
            {
                //btnRegistrarLdc.Enabled = false;
            }
        }
        #endregion

        private double grupo_codigo;
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            DSEstudiante = objNota.consultarEstudiantes(grupo_codigo);
            dgvVisualizar.DataSource = DSEstudiante.Tables[0];
            tbxIdUsuario.Text = "Ingrese el ID del estudiante";
            txtAsistencia.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtFaltas.Text = "";

            

        }

        private int varIdMatricula = 0;
        private void btnCargarNotas_Click(object sender, EventArgs e)
        {
            //todo implementar select id matricula
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            Nota objNota = new Nota();
            DSEstudiante = objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text));
            dgvVisualizar.DataSource = DSEstudiante.Tables[0];
            txtAsistencia.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtFaltas.Text = "";
            
            if (DSEstudiante.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron Registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbxIdUsuario_TextChanged(object sender, EventArgs e)
        {
            puedeVisualizarNotas();
        }
        private void puedeVisualizarNotas()
        {
            if (tbxIdUsuario.TextLength > 0)
            {
                btnCargarNotas.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                btnCargarNotas.Enabled = false;
            }
        }
        private void btnRegistrar1_Click(object sender, EventArgs e)
        {
            Nota objNota = new Nota();
            varIdMatricula = int.Parse(objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text)).Tables["ResultadoDatos"].Rows[0]["ID_MATRICULA"].ToString());
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            objNota.registrarActualizarNotaCorte1(varIdMatricula, float.Parse(textBox1.Text));
            DSEstudiante = objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text));
            dgvVisualizar.DataSource = DSEstudiante.Tables[0];
            txtAsistencia.Text = "Ingrese el ID del estudiante";
            textBox2.Text = "";
            textBox3.Text = "";
            txtFaltas.Text = "";

            textBox1.Text = "";
            MessageBox.Show("Primera Nota Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void puedeRegistrar1()
        {
            if (textBox1.TextLength > 0)
            {
                btnRegistrar1.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                btnRegistrar1.Enabled = false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            puedeRegistrar1();
        }
        private void btnRegistrar2_Click_1(object sender, EventArgs e)
        {
            Nota objNota = new Nota();
            varIdMatricula = int.Parse(objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text)).Tables["ResultadoDatos"].Rows[0]["ID_MATRICULA"].ToString());
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            objNota.registrarActualizarNotaCorte2(varIdMatricula, float.Parse(textBox2.Text));
            DSEstudiante = objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text));
            dgvVisualizar.DataSource = DSEstudiante.Tables[0];
            txtAsistencia.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox3.Text = "";
            txtFaltas.Text = "";

            textBox2.Text = "";
            MessageBox.Show("Segunda Nota Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void puedeRegistrar2()
        {
            if (textBox2.TextLength > 0)
            {
                btnRegistrar2.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                btnRegistrar2.Enabled = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            puedeRegistrar2();
        }

        private void bntRegistrar3_Click_1(object sender, EventArgs e)
        {
            Nota objNota = new Nota();
            varIdMatricula = int.Parse(objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text)).Tables["ResultadoDatos"].Rows[0]["ID_MATRICULA"].ToString());
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            objNota.registrarActualizarNotaCorte3(varIdMatricula, float.Parse(textBox3.Text));
            DSEstudiante = objNota.consultarNotaEstudiante(grupo_codigo, int.Parse(tbxIdUsuario.Text));
            dgvVisualizar.DataSource = DSEstudiante.Tables[0];
            txtAsistencia.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox2.Text = "";
            txtFaltas.Text = "";

            textBox3.Text = "";
            MessageBox.Show("Tercera Nota Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void puedeRegistrar3()
        {
            if (textBox3.TextLength > 0)
            {
                bntRegistrar3.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                bntRegistrar3.Enabled = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            puedeRegistrar3();
        }
        //CONSULTAR ASISTENCIA

        private void button1_Click_1(object sender, EventArgs e)
        {
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            Asistencia objAsistencia = new Asistencia();
            DataSet dataset = new DataSet();
            dataset = objAsistencia.consultarNumFaltas(grupo_codigo, int.Parse(txtAsistencia.Text));
            dgvVisualizar.DataSource = dataset.Tables[0];
            tbxIdUsuario.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            txtFaltas.Text = "";
            if (dataset.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron Registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private void puedeVisualizarFaltas()
        {
            if (txtAsistencia.TextLength > 0)
            {
                button1.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void txtAsistencia_TextChanged(object sender, EventArgs e)
        {
            puedeVisualizarFaltas();
        }
        //REGISTRO ASISTENCIA
        private void button5_Click_1(object sender, EventArgs e)
        {
            grupo_codigo = double.Parse(cmboxcursos.SelectedValue.ToString());
            Asistencia objAsistencia = new Asistencia();
            objAsistencia.actualizarFaltas(grupo_codigo, double.Parse(txtAsistencia.Text), int.Parse(txtFaltas.Text));
            DataSet dataset = new DataSet();
            dataset = objAsistencia.consultarNumFaltas(grupo_codigo, int.Parse(txtAsistencia.Text));

            dgvVisualizar.DataSource = dataset.Tables[0];

            tbxIdUsuario.Text = "Ingrese el ID del estudiante";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            txtFaltas.Text = "";
            MessageBox.Show("Asistencia Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void puedeRegistrarFaltas()
        {
            if (txtFaltas.TextLength > 0)
            {
                button5.Enabled = true;
                //button1.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private void txtFaltas_TextChanged(object sender, EventArgs e)
        {
            puedeRegistrarFaltas();
        }
    }
}
