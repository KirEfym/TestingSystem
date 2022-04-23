using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPFTestingSystem.Interface;
using WPFTestingSystem.Model;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(User user)
        {
            InitializeComponent();
           DataContext = new MainWindowViewModel(user);
            this.Title = string.Format($"Dear {user.Login}, welcome back!");
            Loaded += LoadedHandler;
            
        }
        private void LoadedHandler(object sender, RoutedEventArgs e)
        {
            if (DataContext is IRefreshable refresh)
            {
                refresh.Refresh += () =>
                {
                    _dataGrid.Items.Refresh();
                };
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
