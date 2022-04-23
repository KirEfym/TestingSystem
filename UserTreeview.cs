using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFTestingSystem
{
   public class UserTreeview : TreeView, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItem", typeof(Object), typeof(UserTreeview), new PropertyMetadata(null));
        public new Object SelectedItem
        {
            get { return (Object)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
                NotifyPropertyChanged("SelectedItem");
            }
        }

        public UserTreeview()
            : base()
        {
            base.SelectedItemChanged += new RoutedPropertyChangedEventHandler<Object>(MyTreeView_SelectedItemChanged);
        }

        private void MyTreeView_SelectedItemChanged(Object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            this.SelectedItem = base.SelectedItem;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String aPropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(aPropertyName));
        }
    }
}
