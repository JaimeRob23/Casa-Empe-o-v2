using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CasaEmpeño.Model;
using CasaEmpeño.Repositories;
using CasaEmpeño.View;
using System.Windows.Input;
using System.Windows;

namespace CasaEmpeño.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserRepository _userRepository;

        private string _username;
        private SecureString _password;
        private string _name;
        private string _lastName;
        private string _email;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set => SetField(ref _username, value);
        }

        public SecureString Password
        {
            get => _password;
            set => SetField(ref _password, value);
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetField(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetField(ref _errorMessage, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand BackCommand { get; }

        public RegisterViewModel()
        {
            _userRepository = new UserRepository();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand);
            BackCommand = new ViewModelCommand(ExecuteBackCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3)
            {
                ErrorMessage = "El nombre de usuario debe tener al menos 3 caracteres";
                return;
            }

            if (Password == null || Password.Length < 6)
            {
                ErrorMessage = "La contraseña debe tener al menos 6 caracteres";
                return;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "El nombre es requerido";
                return;
            }

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                ErrorMessage = "Ingrese un correo electrónico válido";
                return;
            }

            var userModel = new UserModel
            {
                Username = Username,
                Password = ConvertSecureStringToString(Password),
                Name = Name,
                LastName = LastName,
                Email = Email,
                Id = Guid.NewGuid().ToString()
            };

            try
            {
                _userRepository.Add(userModel);
                MessageBox.Show("Registro exitoso! Ahora puede iniciar sesión", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                ExecuteBackCommand(null);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error al registrar: " + ex.Message;
            }
        }

        private void ExecuteBackCommand(object obj)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is RegisterView)
                {
                    window.Close();
                    break;
                }
            }
        }

        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            try
            {
                return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
}
