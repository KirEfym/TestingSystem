using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class Test:ViewModelBase
    {
        private string id;
        private string name;
        private string category;
        private string description;
        private DateTime created;
        private double percent;
        private string creator;
        private List<Question> questions = new List<Question>();
        public string Id { get => id; set { id = value; } }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                OnPropertyChanged("Category");
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
        public DateTime Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
                OnPropertyChanged("Created");
            }
        }
        public double Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;
                OnPropertyChanged("Percent");
            }
        }
        public string Creator
        {
            get
            {
                return creator;
            }
            set
            {
                creator = value;
                OnPropertyChanged("Creator");
            }
        }
        public List<Question> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
                OnPropertyChanged("Questions");
            }
        }

        public Test()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
