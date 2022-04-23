using System;
using System.Collections.Generic;
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
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.View
{
    /// <summary>
    /// Interaction logic for EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        public EnterWindow()
        {
            InitializeComponent();
            DataContext = new EnterWindowViewModel();
            Loaded += LoadedHandler;
        }
        private void LoadedHandler(object sender,RoutedEventArgs e)
        {
            if(DataContext is IHideWindow hide)
            {
                hide.Hide += () =>
                  {
                      this.Hide();
                  };
            }
            if(DataContext is ICloseWindow close)
            {
                close.Close += () =>
                  {
                      this.Close();
                  };
            }
        }
    }
}
