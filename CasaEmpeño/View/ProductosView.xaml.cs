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
    /// Lógica de interacción para ProductosView.xaml

    public partial class ProductosView : Window
    {
        public ProductosView()
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

        private void btnBuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            BuscarProducto ventanaBusqueda = new BuscarProducto();
            ventanaBusqueda.Show();
            this.Close();
        }
    }
}
