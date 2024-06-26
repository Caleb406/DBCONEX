﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionUsuarios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            UsuarioDao daoUsuario = new UsuarioDao();
            dgUsuarios.ItemsSource = daoUsuario.Obtener();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.ShowDialog();
            CargarDatos();
        }

        private int ObtenerIdSeleccionado()
        {
            var selected = dgUsuarios.SelectedItems;
            foreach ( var item in selected ) 
            {
                var usr = item as UsuarioDto;
                return usr.Id;
            }
            return -1;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int id = ObtenerIdSeleccionado();
            if ( id == -1 ) 
            {
                MessageBox.Show("No ha seleccionado registro a editar");
            }
            else
            {
                FrmUsuario frmEditar = new FrmUsuario(id);
                frmEditar.ShowDialog();
                CargarDatos();
            }
        }

        private void BtnEliminar_Click( object sender, RoutedEventArgs e)
        {
            int id = ObtenerIdSeleccionado();
if (id == -1)
{
    MessageBox.Show("No ha seleccionado registro a eliminar");
}
else
{
    try
    {
        var Result = MessageBox.Show("¿Desea eliminar el registro seleccionado?",
            "Gestión de Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (Result == MessageBoxResult.Yes)
        {
            // Eliminar registros relacionados en roles_usuarios
            UsuarioDao daoUsuario = new UsuarioDao();
            daoUsuario.EliminarRegistrosRelacionados(id);

            // Luego eliminar el usuario principal
            daoUsuario.Eliminar(id);
            MessageBox.Show("Registro eliminado con éxito");
            CargarDatos();
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Error: " + ex.Message);
    }
}

        }
    }
}