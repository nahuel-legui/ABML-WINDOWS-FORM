using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaConexion
{
    public partial class editarAlumno : Form
    {
        private int idAlumno;
        public editarAlumno(Alumno objAlumno)
        {
            InitializeComponent();
            idAlumno = objAlumno.idAlumno;
            tbxNombre.Text=objAlumno.nombre;
            tbxCarrera.Text=objAlumno.carrera;
            tbxEdad.Text =  objAlumno.edad.ToString();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AlumnoDAO alumDao = new AlumnoDAO();
            if (alumDao.actualizarAlumno(tbxNombre.Text,tbxCarrera.Text,int.Parse (tbxEdad.Text),idAlumno) )
            {

                MessageBox.Show("ALUMNO ACTUALIZADO CORRECTAMENTE");
                
            }
            this.Close();
        }
    }
}
