using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaConexion
{
    public class Conexion
    {
        //ruta que va a localizar la base de datos
        private string rutaBase = "Data Source = LAPTOP-R39JNBBK\\SQLEXPRESS; Initial Catalog = pruebaConexion; Integrated Security = true";

        public SqlConnection conectar = new SqlConnection();

        public Conexion()
        {
            conectar.ConnectionString = rutaBase;

        }

        public void Abrir()
        {
            try
            {
                conectar.Open();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cerrar()
        {
            conectar.Close();
        }

    }


}
