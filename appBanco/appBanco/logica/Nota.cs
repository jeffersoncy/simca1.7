using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appBanco.accesoDatos;
using System.Windows.Forms;
using System.Data;

namespace appBanco.logica
{
    class Nota
    {
        Datos misDatos = new Datos();

        public DataSet consultarEstudiantes(double grupo_codigo)
        {
            string consulta;
            consulta = "select Estudiante_codigo, persona_nombre, persona_apellido from matricula natural join (select Estudiante_codigo, persona_nombre, persona_apellido from programa natural join (select estudiante_codigo, persona_nombre, persona_apellido,programa_codigo from persona natural join estudiante)table2)table3 where grupo_codigo = " + grupo_codigo;


            return misDatos.ejecutarSELECT(consulta);
        }

        //obtener idMatricula
        public DataSet obtenerIdMatricula(int parEstudianteCodigo, double parGrupoCodigo)
        {
            string consulta;
            consulta = "SELECT id_Matricula FROM matricula WHERE estudiante_codigo = " + parEstudianteCodigo + " AND grupo_codigo = " + parGrupoCodigo;
            return misDatos.ejecutarSELECT(consulta);
        }

        public DataSet consultarNotaEstudiante(double grupo_codigo, int codigo_Estudiante)
        {
            string consulta;
            consulta = "select nota_primercorte as Nota1,nota_segundocorte as Nota2,nota_tercercorte as Nota3, matricula.id_matricula from matricula inner join nota on matricula.id_matricula = nota.id_matricula where estudiante_codigo = " + codigo_Estudiante + "AND grupo_codigo = " + grupo_codigo;
            return misDatos.ejecutarSELECT(consulta);
        }

        public int crearRegistroNotas(int prmIDNota)
        {
            string consulta;
            consulta = "insert into NOTA values(" + prmIDNota + ", null, null, null)";
            return misDatos.ejecutarDML(consulta);
        }


        #region ACTUALIZACIONES DE NOTAS
        public int registrarActualizarNotaCorte1(int prmIdMatricula, float prmNotaCorte1)
        {
            string consulta;
            consulta = "update NOTA set NOTA_PRIMERCORTE = " + prmNotaCorte1 + " where ID_NOTA = " + prmIdMatricula;
            return misDatos.ejecutarDML(consulta);
        }

        public int registrarActualizarNotaCorte2(int prmIdMatricula, float prmNotaCorte2)
        {
            string consulta;
            consulta = "update NOTA set NOTA_SEGUNDOCORTE = " + prmNotaCorte2 + " where ID_NOTA = " + prmIdMatricula;
            return misDatos.ejecutarDML(consulta);
        }

        public int registrarActualizarNotaCorte3(int prmIdMatricula, float prmNotaCorte3)
        {
            string consulta;
            consulta = "update NOTA set NOTA_TERCERCORTE = " + prmNotaCorte3 + " where ID_NOTA = " + prmIdMatricula;
            return misDatos.ejecutarDML(consulta);
        }

        #endregion


        public DataSet consultarNotaCorte1(int prmIDNota)
        {
            string consulta;
            consulta = "select NOTA_PRIMERCORTE from NOTA where ID_NOTA = " + prmIDNota;
            return misDatos.ejecutarSELECT(consulta);
        }

        public DataSet consultarNotaCorte2(int prmIDNota)
        {
            string consulta;
            consulta = "select NOTA_SEGUNDOCORTE from NOTA where ID_NOTA = " + prmIDNota;
            return misDatos.ejecutarSELECT(consulta);
        }

        public DataSet consultarNotaCorte3(int prmIDNota)
        {
            string consulta;
            consulta = "select NOTA_TERCERCORTE from NOTA where ID_NOTA = " + prmIDNota;
            return misDatos.ejecutarSELECT(consulta);
        }

        public int eliminarRegistroNotas(int prmIDNota)
        {
            string consulta;
            consulta = "delete from NOTA where ID_NOTA = " + prmIDNota;
            return misDatos.ejecutarDML(consulta);
        }
    }
}