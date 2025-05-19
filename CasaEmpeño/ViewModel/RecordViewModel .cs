using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CasaEmpeño.Model;
using CasaEmpeño.Repositories;
using System.Windows.Input;

namespace CasaEmpeño.ViewModel
{
    internal class RecordViewModel:ViewModelBase
    {


        private readonly RepositoryBase repositoryBase;

        private ObservableCollection<UserModel> _users;
        private UserModel _user;

        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public RecordViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserAccountData();
            _user = new UserModel();
            //_users = repositoryBase.Get();
        }

        private void LoadCurrentUserAccountData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }

        public ICommand AddCommand { get; }

        private void AddExecute(object user)
        {
            User.Id = Guid.NewGuid().ToString();
            userRepository.Add(User);
            //_users = repositoryBase.Get();
        }

        private bool AddCanExecute(object user)
        {
            return true;
        }

       // public ICommand DeleteCommand {
         //   get
           // {
             //   return new ViewModelBaseCommand(DeleteExecute, DeleteCanExecute);
            //} 
        
      //  }
        //private void DeleteExecute(object user)
        //{
          //  userRepository.Delete(User.Id); // Borra el usuario usando el Id
            // Actualizar la lista de usuarios si es necesario
            // Users = userRepository.Get();
        //}

        private bool DeleteCanExecute(object user)
        {
            // Verifica que el objeto user no sea nulo y tenga un Id válido
            return true;
        }

        public ICommand EditCommand { get; }
        private void EditExecute(object user)
        {
            userRepository.Edit(User); // Borra el usuario usando el Id
            // Actualizar la lista de usuarios si es necesario
            // Users = userRepository.Get();
        }

        private bool EditCanExecute(object user)
        {
            // Verifica que el objeto user no sea nulo y tenga un Id válido
            return true;
        }

    }
}
