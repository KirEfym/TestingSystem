using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class SavedAnswer:ViewModelBase
    {
        private bool isChecked=false;
        private string answerText;
        private bool isCorrect;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public bool IsCorrect
        {
            get
            {
                return isCorrect;
            }
            set
            {
                isCorrect = value;
                OnPropertyChanged("IsCorrect");
            }
        }
        public string AnswerText
        {
            get
            {
                return answerText;
            }
            set
            {
                answerText = value;
                OnPropertyChanged("AnswerText");
            }
        }
        public bool GetVariantResult()
        {
            if(isChecked==true && isCorrect==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SavedAnswer(bool isCorrect,string answerText)
        {
            this.isCorrect = isCorrect;
            this.answerText = answerText;
        }
    }
}
