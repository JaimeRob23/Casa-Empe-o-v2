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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CasaEmpeño.View
{
    /// <summary>
    /// Lógica de interacción para InformacionProductoView.xaml
    /// </summary>
    public partial class InformacionProductoView : Window
    {
        public InformacionProductoView()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MainViewCliente ventanaPrincipal = new MainViewCliente();
            ventanaPrincipal.Show();
            this.Close();
        }
        private void BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            // Código para continuar
        }
        private void SubirFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar foto del producto";
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProductoImagen.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                ProductoImagen.Visibility = Visibility.Visible;
            }
        }
    }
}
