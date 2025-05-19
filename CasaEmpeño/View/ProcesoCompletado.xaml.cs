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
    /// Lógica de interacción para ProcesoCompletado.xaml
    /// </summary>
    public partial class ProcesoCompletado : Window
    {
        public ProcesoCompletado()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            ProductoEncontradoView ventanaProductoEncontrado = new ProductoEncontradoView();
            ventanaProductoEncontrado.Show();
            this.Close();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainViewCliente ventanaPrincipal = new MainViewCliente();
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
