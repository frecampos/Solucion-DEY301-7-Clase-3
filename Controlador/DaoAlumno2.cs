using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//cliente  SQL
using System.Data;
using Biblioteca;//clase alumno
namespace Controlador
{
    public class DaoAlumno2
    {
        SqlConnection conexion;
        String cadena = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=DEY;Persist Security Info=True;User ID=sa;Password=Duocadmin2018";

        public DaoAlumno2()
        {
            conexion = new SqlConnection(cadena);
        }
        //C.R.U.D
        public Boolean Crear(Alumno alum) {
            try
            {
                String Sql = "insert into Alumno values("+
                    "'@rut','@nom','@ape',@ed,'@curso')";
                Sql = Sql.Replace("@rut", alum.Rut);
                Sql = Sql.Replace("@nom", alum.Nombre);
                Sql = Sql.Replace("@ape", alum.Apellido);
                Sql = Sql.Replace("@ed", alum.Edad.ToString());
                Sql = Sql.Replace("@curso", alum.Curso.ToString());
                SqlCommand cmd = new SqlCommand(Sql, conexion);

                conexion.Open();
                int x= cmd.ExecuteNonQuery();
                conexion.Close();
                return x>0;
            }
            catch (Exception ex)
            {
                if (conexion.State==System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public Boolean Crear2(Alumno alum)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "insertar";
                cmd.Parameters.Add("@rut", SqlDbType.NVarChar, 50).Value = alum.Rut;
                cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 50).Value = alum.Nombre;
                cmd.Parameters.Add("@ape", SqlDbType.NVarChar, 50).Value = alum.Apellido;
                cmd.Parameters.Add("@se", SqlDbType.NChar, 1).Value = alum.sexo;
                conexion.Open();
                int x = cmd.ExecuteNonQuery();
                conexion.Close();
                return x > 0;
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                Logger.Mensaje(ex.Message);
                return false;
            }
        }
    }
}
