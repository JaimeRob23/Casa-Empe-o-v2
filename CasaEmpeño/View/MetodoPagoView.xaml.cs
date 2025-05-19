using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace CasaEmpeño.View
{
    /// <summary>
    /// Interaction logic for MetodoPagoView.xaml
    /// </summary>
    public partial class MetodoPagoView : Window
    {
        public MetodoPagoView()
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
    }
}