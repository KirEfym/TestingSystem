using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.Manager;
using WPFTestingSystem.Model;
using WPFTestingSystem.Interface;
using WPFTestingSystem.CommandFolder;
using System.ComponentModel;
using CustomValidatorLibrary;
using System.Windows;
using WPFTestingSystem.View;

namespace WPFTestingSystem.ViewModel
{
    class EnterWindowViewModel : IHideWindow, INotifyPropertyChanged,ICloseWindow
    {
        private LogInCommand loginCommand;
        private LogInCommand closeCommand;
        private string login;
        private string password;
        private UserManager userManager = new UserManager();
        EmtyStringValidator esv = new EmtyStringValidator();
        User currentUser;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyRaised("Login");
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
                OnPropertyRaised("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Authorise()
        {
            string log = login.Trim().ToLower();
            string pass = password.Trim();
            if (esv.ValidateText(log) && esv.ValidateText(pass))
            {
                this.currentUser = userManager.Auth(log, pass);
                if (currentUser != null)
                {
                    MainWindow mainWindow = new MainWindow(currentUser);
                    mainWindow.Show();
                    HideWindow();
                }
            }
            else
            {
                MessageBox.Show("Fill out both fields");
            }
        }
        public LogInCommand LoginCommand => loginCommand ?? (loginCommand = new LogInCommand(Authorise));
        public LogInCommand CloseCommand => closeCommand ?? (closeCommand = new LogInCommand(Closewindow));
        void HideWindow()
        {
            Hide?.Invoke();
        }
        void Closewindow()
        {
            Close?.Invoke();
        }
        public Action Hide { get; set; }
        public Action Close { get; set; }
    }
}
