using CustomValidatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTestingSystem.CommandFolder;
using WPFTestingSystem.Interface;
using WPFTestingSystem.Manager;

namespace WPFTestingSystem.ViewModel
{
   public class RegisterWindowViewModel:ViewModelBase,ICloseWindow
    {
        private LogInCommand registerCommand;
        private LogInCommand closeCommand;
        private string login;
        private string password;
        private string userName;
        private UserManager userManager = new UserManager();
        EmtyStringValidator esv = new EmtyStringValidator();
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public LogInCommand RegisterCommand => registerCommand ?? (registerCommand = new LogInCommand(Register));
        public LogInCommand CloseCommand => closeCommand ?? (closeCommand = new LogInCommand(Closewindow));
       
        void Closewindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        private void Register()
        {
            if (userManager.Register(login, password, userName))
            {
                MessageBox.Show("User created");
                Closewindow();
            }
            else
            {
                MessageBox.Show("Something went wrong, try again later");
            }
        }
    }
}
