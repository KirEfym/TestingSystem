using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class Question:ViewModelBase
    {
        private string text { get; set; }
        private string testName { get; set; }
        private List<Answer> answers { get; set; } = new List<Answer>();
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
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
        public List<Answer> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
                OnPropertyChanged("Answers");
            }
        }
    }
}
