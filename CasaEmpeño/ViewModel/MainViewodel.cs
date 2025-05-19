using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CasaEmpeño.View;

namespace CasaEmpeño.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenUserManagerCommand { get; }
        public ICommand OpenProductManagerCommand { get; }

        public MainViewModel()
        {
            OpenUserManagerCommand = new ViewModelCommand(ExecuteOpenUserManagerCommand);
            OpenProductManagerCommand = new ViewModelCommand(ExecuteOpenProductManagerCommand);
        }

        private void ExecuteOpenUserManagerCommand(object obj)
        {
            // Lógica para abrir el gestor de usuarios
            var clienteView = new ClienteView();
            clienteView.Show();
        }

        private void ExecuteOpenProductManagerCommand(object obj)
        {
            // Lógica para abrir el gestor de productos
            var productoView = new ProductoView();
            productoView.Show();
        }
    }
}
