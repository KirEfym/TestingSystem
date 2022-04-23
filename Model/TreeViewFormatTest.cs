using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class TreeViewFormatTest:ViewModelBase
    {
        private string id;
        private string testName;
        private string description;
       public TreeViewFormatTest(string testName,string description,string id)
        {
            this.testName = testName;
            this.description = description;
            this.id = id;
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                testName = value;
                OnPropertyChanged("TestName");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}
