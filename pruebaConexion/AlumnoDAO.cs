using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaConexion
{
    public class AlumnoDAO
    {
        Conexion cn =new Conexion();

        public bool AgregarAlumno(string nom ,string carr,int ed)
        {
            string consulta = "insert into alumno(nombre,carrera,edad) values (@nom ,@carr,@ed)";
            SqlCommand cmd = new SqlCommand(consulta,cn.conectar);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@carr", carr);
            cmd.Parameters.AddWithValue("@ed", ed);
            cn.Abrir();
            int fila = cmd.ExecuteNonQuery();
            if (fila == 0) {
                MessageBox.Show("ERROR AL AGREGAR ALUMNO");
                return false;
            }
            cn.Cerrar();
            return true;
        }

        public DataTable listarAlumno()
        {
            DataTable dt = new DataTable();
            string consulta = "select * from alumno ";
            SqlCommand cmd = new SqlCommand(consulta, cn.conectar);
            cn.Abrir();
            SqlDataReader dr =  cmd.ExecuteReader();//select
            dt.Load(dr);
            cn.Cerrar();
            return dt;

        }
        public bool actualizarAlumno(string nom, string carr, int ed,int id)
        {
            string consulta = "update alumno set nombre =@nombre, carrera=@carrera,edad=@edad where idAlumno=@idAlumno";
            SqlCommand cmd = new SqlCommand(consulta, cn.conectar);
            cmd.Parameters.AddWithValue("@idAlumno", id);
            cmd.Parameters.AddWithValue("@nombre", nom);
            cmd.Parameters.AddWithValue("@carrera", carr);
            cmd.Parameters.AddWithValue("@edad", ed);
            cn.Abrir();
            int fila = cmd.ExecuteNonQuery();
            if (fila == 0)
            {
                MessageBox.Show("ERROR AL EDITAR ALUMNO");
                return false;
            }
            cn.Cerrar();
            return true;
        }
        public bool eliminarAlumno(int id)
        {
            string consulta = "delete from alumno where idAlumno =@idAlumno";
            SqlCommand cmd = new SqlCommand(consulta, cn.conectar);
            cmd.Parameters.AddWithValue("@idAlumno", id);
    
            cn.Abrir();
            int fila = cmd.ExecuteNonQuery();
            if (fila == 0)
            {
                MessageBox.Show("ERROR AL ELIMINAR AL ALUMNO");
                return false;
            }
            cn.Cerrar();
            return true;
        }


    }

}
