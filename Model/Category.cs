using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class Category:ViewModelBase
    {
        private string categoryName;
        private ObservableCollection<TreeViewFormatTest> tests = new ObservableCollection<TreeViewFormatTest>();
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        public ObservableCollection<TreeViewFormatTest> Tests
        {
            get
            {
                return tests;
            }
            set
            {
                tests = value;
                OnPropertyChanged("Tests");
            }
        }
       public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }
    }
}
