using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZLibrary.Models;
using ZLibrary.Repository;

namespace ZLibrary.View.ViewModels
{
    public class UserVM
    {
        private UserRepo userRepo;
        private User user;
        private readonly Login login;

        public string? Name
        {
            get
            {
                return user.Name;
            }
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    onPropertyChanged(nameof(user.Name));
                }

            }
        }
        public string? Password
        {
            get
            {
                return user.Password;
            }
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    onPropertyChanged(nameof(user.Password));
                }

            }
        }
        //  public string Type { get; set; }
        public User? User
        {
            get
            {
                return user;
            }
            set
            {
                if (user != value)
                {
                    user = value;
                    onPropertyChanged(nameof(user));
                }

            }
        }
        public ICommand Check { get; }
        public UserVM(Login login)
        {
            userRepo = new UserRepo();
            user = new User();
            Check = new RelayCommand(CheckUser);
            this.login = login;
        }

        private async void CheckUser()
        {
            if (await userRepo.CheckAccount(Name, Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                login.Close();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
