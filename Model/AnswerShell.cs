using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class AnswerShell : ViewModelBase
    {
        private string questionText;
        private List<SavedAnswer> savedAnswers = new List<SavedAnswer>();
        public List<SavedAnswer> SavedAnswers
        {
            get
            {
                return savedAnswers;
            }
            set
            {
                savedAnswers = value;
                OnPropertyChanged("SavedAnswers");
            }
        }
        public string QuestionText
        {
            get
            {
                return questionText;
            }
            set
            {
                questionText = value;
                OnPropertyChanged("QuestionText");
            }
        }
        public bool GetAnswerResult()
        {
           foreach(SavedAnswer sa in savedAnswers)
            {
                if(sa.GetVariantResult())
                {
                    return true;
                }
            }
            return false;
        }
        public AnswerShell(List<SavedAnswer> savedAnswers, string questionText)
        {
            this.savedAnswers = savedAnswers;
            this.questionText = questionText;
        }
    }
}
