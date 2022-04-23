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
using WPFTestingSystem.ViewModel;
using WPFTestingSystem.Model;

namespace WPFTestingSystem.View
{
    /// <summary>
    /// Interaction logic for DoTestWindow.xaml
    /// </summary>
    public partial class DoTestWindow : Window
    {
        public DoTestWindow(Test test,User user)
        {
            InitializeComponent();
            DataContext = new DoTestWindowViewModel(test,user);
        }
    }
}
