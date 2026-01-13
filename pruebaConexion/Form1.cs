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
    public partial class Form1 : Form
    {
        public AlumnoDAO a1 = new AlumnoDAO();
        public Form1()
        {
            InitializeComponent();
            dgvAlumnos.DataSource = a1.listarAlumno();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxNombre.Text)||string.IsNullOrWhiteSpace(tbxCarrera.Text)||string.IsNullOrWhiteSpace(tbxEdad.Text))
            {
                MessageBox.Show("ES NECESARIO QUE COMPLETE TODOS LOS CAMPOS ");
                return;
            }
            if(!int.TryParse(tbxEdad.Text,out int edad))
            {
                MessageBox.Show("SOLO EDADES CON NUMEROS ");
                tbxEdad.Text = string.Empty;
                tbxEdad.Focus();
                return;
            }
            

            string nombre = tbxNombre.Text;
            string carrera = tbxCarrera.Text;

            if (a1.AgregarAlumno(nombre, carrera, edad))
            {
                MessageBox.Show("GUARDADO CORRECTAMENTE");
            }

            tbxNombre.Clear();
            tbxCarrera.Clear();
            tbxEdad.Clear();
            dgvAlumnos.DataSource = a1.listarAlumno();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvAlumnos.DataSource = a1.listarAlumno();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow != null) {
                Alumno alum = new Alumno();
                alum.idAlumno = int.Parse(dgvAlumnos.CurrentRow.Cells["idAlumno"].Value.ToString());
                alum.nombre = dgvAlumnos.CurrentRow.Cells["nombre"].Value.ToString();
                alum.carrera = dgvAlumnos.CurrentRow.Cells["Carrera"].Value.ToString();
                alum.edad = int.Parse(dgvAlumnos.CurrentRow.Cells["edad"].Value.ToString());
                editarAlumno frmEditar = new editarAlumno(alum);
                frmEditar.ShowDialog();
                //refresca la grilla  
                dgvAlumnos.DataSource = a1.listarAlumno();

            }
            else
            {
                MessageBox.Show("POR FAVOR SELECCIONE UNA FILA ");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow != null)
            {
                
                int idAlumno = int.Parse(dgvAlumnos.CurrentRow.Cells["idAlumno"].Value.ToString());

                if (a1.eliminarAlumno(idAlumno))
                {
                    MessageBox.Show("ALUMNO ELIMINADO CORRECTAMENTE");
                }
      
                //refresca la grilla  
                dgvAlumnos.DataSource = a1.listarAlumno();

            }
            else
            {
                MessageBox.Show("POR FAVOR SELECCIONE UNA FILA ");
            }

        }
    }
}
