using appBanco.accesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBanco.logica
{
    class Asistencia
    {
        Datos misDatos = new Datos();

        public int crearRegistroFaltas(int prmIDAsistencia, int prmCodigoGrupo, double prmCodEstudiante, int prmNumFaltas)
        {
            string consulta;
            consulta = "insert into ASISTE values(" + prmIDAsistencia + ", " + prmCodigoGrupo + ", " + prmNumFaltas + ")";
            return misDatos.ejecutarDML(consulta);
        }

        public int actualizarFaltas(double prmCodigoGrupo, double prmCodEstudiante, int prmNumFaltas)
        {
            string consulta;
            consulta = "update ASISTE set NUMERO_FALTAS = " + prmNumFaltas + " where GRUPO_CODIGO = " + prmCodigoGrupo + " and ESTUDIANTE_CODIGO = " + prmCodEstudiante;
            return misDatos.ejecutarDML(consulta);
        }

        public DataSet consultarNumFaltas(double prmCodigoGrupo, double prmCodEstudiante)
        {
            string consulta;
            consulta = "SELECT estudiante_codigo, numero_faltas FROM asiste where estudiante_codigo = " + prmCodEstudiante + " and grupo_codigo =" + prmCodigoGrupo;

            // consulta = "SELECT  numero_faltas FROM asiste where estudiante_codigo = 401 and grupo_codigo = 1002";
            return misDatos.ejecutarSELECT(consulta);
        }
    }
}
