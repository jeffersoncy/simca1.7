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
    class Docente
    {
        Datos misDatos = new Datos();

        public int ingresarDocente(double identif, double codDocente, int numeroOficina, string area, string especializacion)
        {
            string consulta;
            consulta = "Insert into Profesor Values(" +
            codDocente + "," + identif + "," + numeroOficina + ",'" + area + "','" + especializacion + "')";
            // ejecutar insert update delete DML
            return misDatos.ejecutarDML(consulta);
        }
        public DataSet consultarXPersona(double PerIdent)
        {
            string consulta;
            consulta = "select * from Persona where persona_Ident =" + PerIdent;
            return misDatos.ejecutarSELECT(consulta);
        }
        public DataSet consultarXDocenteActualizar(double DocIdent, double DocCodigo)
        {
            string consulta;
            consulta = "select * from Persona where persona_Ident =" + DocIdent + " and Profesor_Codigo = " + DocCodigo;
            return misDatos.ejecutarSELECT(consulta);
        }

        /*
        metodo para que el usuario sepa que materias imparte profesor 
        este metodo será referenciado desde la interfazInicial del docente ene la pestaña cursos*/
        public DataSet materiasImparteProfesor(int codigoProfesor)
        {
            string consulta;
            consulta = "SELECT grupo_codigo, grupo_nombre ,mat_semestre, fecha_asignacionmateria, fechafin FROM GRUPO INNER JOIN (select materia.mat_cod, mat_nombre, mat_semestre, fecha_asignacionmateria, fechafin, profesor_codigo from imparte inner join materia on materia.mat_cod = imparte.mat_cod)TABLE2 ON GRUPO.MAT_COD = TABLE2.MAT_COD where profesor_codigo = "+ codigoProfesor;
            return misDatos.ejecutarSELECT(consulta);
        }


        //el frm inicio profesor hace referencia a esta consulta desde la pestaña horario
        public DataSet consultarHorarioProfesor(int codigoProfesor)
        {
            string consulta;
            consulta = " SELECT GRUPO_NOMBRE, HORA_INICIO, HORA_FIN, SALON_NOM, SALON_UBICACION, DIAS FROM SALON INNER JOIN(SELECT GRUPO_NOMBRE, HORA_INICIO, HORA_FIN, SALON_COD, DIAS, profesor_codigo FROM imparte INNER JOIN (SELECT GRUPO.MAT_COD, GRUPO_NOMBRE, HORA_INICIO, HORA_FIN, SALON_COD, DIAS FROM GRUPO INNER JOIN TIENE_HORARIO ON GRUPO.GRUPO_CODIGO = tiene_horario.grupo_codigo)TABLE2 ON imparte.mat_cod = TABLE2.MAT_COD)TABLE3 ON SALON.SALON_COD = TABLE3.SALON_COD WHERE PROFESOR_CODIGO =" + codigoProfesor;
            return misDatos.ejecutarSELECT(consulta);
        }


     
        public DataSet mostrarPersona()
        {
            string consulta;
            consulta = "select persona_ident, persona_nombre, persona_apellido from persona";
            return misDatos.ejecutarSELECT(consulta);
        }
        //public DataSet mostrarDocente()
        //{
        //    string consulta;
        //    consulta = "select persona_ident, persona_nombre, persona_apellido from persona";
        //    return misDatos.ejecutarSELECT(consulta);
        //}
    }
}
