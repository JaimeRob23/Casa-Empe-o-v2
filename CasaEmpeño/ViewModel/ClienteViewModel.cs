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
    public class ClienteViewModel : ViewModelBase
    {
        private readonly IClienteRepository _clienteRepository;

        private ObservableCollection<ClienteModel> _clientes;
        private ClienteModel _clienteActual;
        private string _mensaje;

        public ObservableCollection<ClienteModel> Clientes
        {
            get => _clientes;
            set => SetField(ref _clientes, value);
        }

        public ClienteModel ClienteActual
        {
            get => _clienteActual;
            set => SetField(ref _clienteActual, value);
        }

        public string Mensaje
        {
            get => _mensaje;
            set => SetField(ref _mensaje, value);
        }

        public ICommand NuevoCommand { get; }
        public ICommand GuardarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public ClienteViewModel()
        {
            _clienteRepository = new ClienteRepository();
            ClienteActual = new ClienteModel();
            CargarClientes();

            NuevoCommand = new ViewModelCommand(ExecuteNuevoCommand);
            GuardarCommand = new ViewModelCommand(ExecuteGuardarCommand);
            EditarCommand = new ViewModelCommand(ExecuteEditarCommand);
            EliminarCommand = new ViewModelCommand(ExecuteEliminarCommand);
            LimpiarCommand = new ViewModelCommand(ExecuteLimpiarCommand);
        }

        private void CargarClientes()
        {
            Clientes = new ObservableCollection<ClienteModel>(_clienteRepository.GetAll());
        }

        private void ExecuteNuevoCommand(object obj)
        {
            ClienteActual = new ClienteModel();
        }

        private void ExecuteGuardarCommand(object obj)
        {
            if (ClienteActual == null)
            {
                new MensajeEmergente("Error interno: no hay cliente seleccionado o creado.").ShowDialog();
                return;
            }
            // Validaciones
            if (string.IsNullOrWhiteSpace(ClienteActual.NombreCompleto))
            {
                new MensajeEmergente("El nombre del cliente es obligatorio.").ShowDialog();
                return;
            }

            if (ContieneNumeros(ClienteActual.NombreCompleto))
            {
                new MensajeEmergente("El nombre o algun apellido contiene numeros, porfavor retirelos.").ShowDialog();
                return;
            }



            if (string.IsNullOrWhiteSpace(ClienteActual.Materno))
            {
                new MensajeEmergente("El Apellido Materno es obligatorio.").ShowDialog();
                return;
            }

            if (ContieneNumeros(ClienteActual.Materno))
            {
                new MensajeEmergente("El apellido materno no debe contener números.").ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(ClienteActual.Paterno))
            {
                new MensajeEmergente("El Apellido Paterno es obligatorio.").ShowDialog();
                return;
            }

            if (ContieneNumeros(ClienteActual.Paterno))
            {
                new MensajeEmergente("El apellido paterno no debe contener números.").ShowDialog();
                return;
            }

            if (ClienteActual.Edad <= 0 || ClienteActual.Edad > 100)
            {
                new MensajeEmergente("La edad del cliente debe ser mayor a cero y/o menor que 100.").ShowDialog();
                return;
            }

            // Guardar cliente si pasa validaciones
            if (ClienteActual.Id == 0)
            {
                if (_clienteRepository.Add(ClienteActual))
                {
                    new MensajeEmergente("Cliente agregado correctamente").ShowDialog();
                    CargarClientes();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
                else
                {
                    new MensajeEmergente("Error al agregar al cliente").ShowDialog();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
            }
            else
            {
                if (_clienteRepository.Edit(ClienteActual))
                {
                    new MensajeEmergente("Cliente actualizado correctamente").ShowDialog();
                    CargarClientes();
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
                else
                {
                    Mensaje = "Error al actualizar cliente";
                    ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
                }
            }
        }


        private void ExecuteEditarCommand(object obj)
        {
            if (obj is ClienteModel cliente)
            {
                ClienteActual = _clienteRepository.GetById(cliente.Id);
            }
        }

        private void ExecuteEliminarCommand(object obj)
        {
            if (obj is ClienteModel cliente && _clienteRepository.Delete(cliente.Id))
            {
                new MensajeEmergente("Cliente eliminado correctamente").ShowDialog();
                CargarClientes();
                ExecuteLimpiarCommand(null); // Limpiar campos después de agregar
            }
        }

        private void ExecuteLimpiarCommand(object obj)
        {
            ClienteActual = new ClienteModel();
            Mensaje = string.Empty;
        }

        private bool ContieneNumeros(string texto)
        {
            return texto.Any(char.IsDigit);
        }
    }
}
