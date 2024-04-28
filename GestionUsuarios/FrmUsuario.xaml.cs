using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionUsuarios
{
    /// <summary>
    /// Lógica de interacción para FrmUsuario.xaml
    /// </summary>
    public partial class FrmUsuario : Window
    {
        private int? Id;
        public FrmUsuario(int? id=null)
        {
            InitializeComponent();
            this.Id = id;
            if (this.Id != null) CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new UsuarioDao();
            UsuarioDto usuario = daoUsuario.Obtener(this.Id);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            txtPais.Text = usuario.Pais;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarNombre() && ValidarApellido() && ValidarEmail() && ValidarPais())
            {
                UsuarioDao daoUsuario = new UsuarioDao();
                try
                {
                    if (this.Id == null)
                        daoUsuario.Agregar(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtPais.Text);
                    else
                        daoUsuario.Actualizar(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtPais.Text, (int)Id);
                    this.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

        private bool ValidarNombre()
        {
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private bool ValidarApellido()
        {
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El apellido solo debe contener letras.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool ValidarEmail()
        {
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, introduce una dirección de correo electrónico válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool ValidarPais()
        {
            if (!Regex.IsMatch(txtPais.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El país solo debe contener letras.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        // Permite solo letras en los campos de nombre y apellido
        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }
    }
}
