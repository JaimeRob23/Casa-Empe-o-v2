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

namespace CasaEmpeño.View
{
    /// <summary>
    /// Lógica de interacción para BuscarProducto.xaml
    /// </summary>
    public partial class BuscarProducto : Window
    {
        public BuscarProducto()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            ProductosView ventanaProductos = new ProductosView();
            ventanaProductos.Show();
            this.Close();
        }
        private void BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad en desarrollo");
        }

    }
}
