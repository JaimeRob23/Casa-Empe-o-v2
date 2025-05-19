using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaEmpeño.Model;
using CasaEmpeño.Repositories;
using System.Windows.Input;
using CasaEmpeno.View;

namespace CasaEmpeño.ViewModel
{
    public class ProductoViewModel : ViewModelBase
    {
        private readonly IProductoRepository _productoRepository;

        private ObservableCollection<ProductoModel> _productos;
        private ProductoModel _productoActual;
        private string _mensaje;

        public ObservableCollection<ProductoModel> Productos
        {
            get => _productos;
            set
            {
                _productos = value;
                OnPropertyChanged();
            }
        }

        public ProductoModel ProductoActual
        {
            get => _productoActual;
            set
            {
                _productoActual = value;
                OnPropertyChanged();
            }
        }

        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                OnPropertyChanged();
            }
        }

        public ICommand NuevoCommand { get; }
        public ICommand GuardarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public ProductoViewModel()
        {
            _productoRepository = new ProductoRepository();
            ProductoActual = new ProductoModel();
            CargarProductos();

            NuevoCommand = new ViewModelCommand(ExecuteNuevoCommand);
            GuardarCommand = new ViewModelCommand(ExecuteGuardarCommand);
            EditarCommand = new ViewModelCommand(ExecuteEditarCommand);
            EliminarCommand = new ViewModelCommand(ExecuteEliminarCommand);
            LimpiarCommand = new ViewModelCommand(ExecuteLimpiarCommand);
        }

        private void CargarProductos()
        {
            Productos = new ObservableCollection<ProductoModel>(_productoRepository.GetAll());
        }

        private void ExecuteNuevoCommand(object obj)
        {
            ProductoActual = new ProductoModel();
        }

        private void ExecuteGuardarCommand(object obj)
        {

            if (ProductoActual == null)
            {
                new MensajeEmergente("Error interno: no hay producto seleccionado o creado.").ShowDialog();
                return;
            }
            // Validaciones
            if (string.IsNullOrWhiteSpace(ProductoActual.Nombre))
            {
                new MensajeEmergente("El nombre del producto es obligatorio.").ShowDialog();
                return;
            }

            if (!decimal.TryParse(ProductoActual.Precio.ToString(), out decimal precio) || precio <= 0)
            {
                new MensajeEmergente("El precio debe ser un numero mayor a cero").ShowDialog();
                return;
            }

           
            if (string.IsNullOrWhiteSpace(ProductoActual.Categoria))
            {
                new MensajeEmergente("La categoria es obligatoria.").ShowDialog();
                return;
            }

            
            if (string.IsNullOrWhiteSpace(ProductoActual.Estado))
            {
                new MensajeEmergente("El estado del producto es obligatorio.").ShowDialog();
                return;
            }

            if (ContieneNumeros(ProductoActual.Estado))
            {
                new MensajeEmergente("El estado no debe contener números.").ShowDialog();
                return;
            }
            // Guardar producto si pasa validaciones
            if (ProductoActual.Id == 0)
            {
                if (_productoRepository.Add(ProductoActual))

                {
                    new MensajeEmergente("Producto agregado correctamente").ShowDialog();
                    //Mensaje = "Producto agregado correctamente";
                    CargarProductos();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar

                }
                else
                {
                    new MensajeEmergente("Error al agregar producto").ShowDialog();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar

                }
            }
            else
            {
                if (_productoRepository.Edit(ProductoActual))
                {
                    new MensajeEmergente("Producto actualizado correctamente").ShowDialog();
                    //Mensaje = "Producto actualizado correctamente";
                    CargarProductos();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
                else
                {
                    new MensajeEmergente("Error al actualizar producto").ShowDialog();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
            }
        }


        private void ExecuteEditarCommand(object obj)
        {
            if (obj is ProductoModel producto)
            {
                ProductoActual = _productoRepository.GetById(producto.Id);
            }
        }

        private void ExecuteEliminarCommand(object obj)
        {
            if (obj is ProductoModel producto)
            {
                if (_productoRepository.Delete(producto.Id))
                {
                    new MensajeEmergente("Producto eliminado correctamente").ShowDialog();
                    CargarProductos();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
                else
                {
                    new MensajeEmergente("Error al eliminar producto").ShowDialog();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
            }
        }

        private void ExecuteLimpiarCommand(object obj)
        {
            ProductoActual = new ProductoModel();
            Mensaje = string.Empty;
        }

        private bool ContieneNumeros(string texto)
        {
            return texto.Any(char.IsDigit);
        }

    }
}
