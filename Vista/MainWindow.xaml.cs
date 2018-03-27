using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca;//importar biblioteca
using Controlador;//importar controlador
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboCurso.ItemsSource = Enum.GetValues(typeof(TipoCurso));
            cboCurso.SelectedIndex = 0;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno alum = new Alumno();
                alum.Rut = txtRut.Text;
                alum.Nombre = txtNombre.Text;
                alum.Apellido = txtApellido.Text;
                alum.Edad = int.Parse(txtEdad.Text);
                alum.Curso = (TipoCurso)cboCurso.SelectedValue;
                DaoAlumno2 dao = new DaoAlumno2();
                bool resp = dao.Crear(alum);
                if (resp==true)
                {
                    MessageBox.Show("Grabo");
                }
                else
                {
                    MessageBox.Show("Existe Rut");
                }
            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de Ingreso de Datos");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            DaoAlumno dao = new DaoAlumno();
            foreach (Alumno item in dao.Listar())
            {
                string texto = 
                    string.Format("Rut:{0} Nombre:{1} Curso:{2}",
                    item.Rut, item.Nombre, item.Curso);
                lstListado.Items.Add(texto);
            }
        }
    }
}
