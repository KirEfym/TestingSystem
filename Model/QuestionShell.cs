using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class QuestionShell:ViewModelBase
    {
        double percent;
        private List<AnswerShell> answerShells = new List<AnswerShell>();
        public List<AnswerShell> AnswerShells
        {
            get
            {
                return answerShells;
            }
            set
            {
                answerShells = value;
                OnPropertyChanged("AnswerShells");
            }
        }
        public double GetPercentResult()
        {
            double temp=0;
            foreach(AnswerShell As in answerShells)
            {
                if(As.GetAnswerResult())
                {
                    temp += percent;
                }
            }
            return temp;
        }
        public QuestionShell(int NumberOfQuestion, List<AnswerShell> answerShells)
        {
            percent = 100 / NumberOfQuestion;
            this.answerShells = answerShells;
        }
    }
}
