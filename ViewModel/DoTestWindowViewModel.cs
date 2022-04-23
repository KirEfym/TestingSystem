using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.Model;
using WPFTestingSystem.CommandFolder;
using System.Windows;
using WPFTestingSystem.Manager;

namespace WPFTestingSystem.ViewModel
{
   public class DoTestWindowViewModel:ViewModelBase
    {
        StatisticsManager statisticsManager = new StatisticsManager();
        private Test test;
        private User user;
        private QuestionShell questionShell;
        private AnswerShell currentQuestion;
        private ScrollButtonCommand scrollBackButtonCommand;
        private ScrollButtonCommand scrollForwardButtonCommand;
        private ScrollButtonCommand endTestButton;
        private bool buttonBox;
        private int pageNumber = 0;
        public ScrollButtonCommand ScrollBackButtonCommand => scrollBackButtonCommand ?? (scrollBackButtonCommand = new ScrollButtonCommand(scrollBack,backPossibility));
        public ScrollButtonCommand ScrollForwardButtonCommand => scrollForwardButtonCommand ?? (scrollForwardButtonCommand = new ScrollButtonCommand(scrollForward, forwardPossibility));
        public ScrollButtonCommand EndTestButton => endTestButton ?? (endTestButton = new ScrollButtonCommand(endTest, endPossibility));
        public int PageNumber
        {
            get
            {
                int result=pageNumber+1;
                return result ;
            }
        }
        public int QuestionNumber
        {
            get
            {
                return test.Questions.Count;
            }
        }
        public bool ButtonBox
        {
            get
            {
                return buttonBox;
            }
            set
            {
                buttonBox = value;
                OnPropertyChanged("ButtonBox");
            }
        }
        public AnswerShell CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }
        public Test Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }

        public DoTestWindowViewModel(Test test,User user)
        {
            this.test = test;
            this.user = user;
            initQuestionShell();
            CurrentQuestion = questionShell.AnswerShells[0];
            ButtonBox = defineType();
        }
       //public DoTestWindowViewModel()
       //{
       //   
       //}
        private void endTest()
        {
            Statistics temp = new Statistics();
            temp.Date = DateTime.Now;
            temp.PassPercent = questionShell.GetPercentResult();
            temp.TestName = test.Name;
            temp.UserName = user.Name;
            if (temp.PassPercent >= test.Percent)
            {
                temp.IsPassed = true;
                MessageBox.Show("Test passed");
            }
            else
            {
                temp.IsPassed = false;
                MessageBox.Show("Test failed");
            }
            statisticsManager.AddStatisticsItem(temp);
        }
        private bool endPossibility()
        {
            if (pageNumber == QuestionNumber - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void scrollBack()
        {
            pageNumber--;
            OnPropertyChanged("PageNumber");
            CurrentQuestion = questionShell.AnswerShells[pageNumber];
            ButtonBox = defineType();
        }
        private bool backPossibility()
        {
            if (pageNumber > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void scrollForward()
        {
            pageNumber++;
            OnPropertyChanged("PageNumber");
            CurrentQuestion = questionShell.AnswerShells[pageNumber];
            ButtonBox = defineType();
        }
        private bool forwardPossibility()
        {
            if (pageNumber < QuestionNumber-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool defineType()
        {
            if ((from i in currentQuestion.SavedAnswers where i.IsCorrect == true select i).Count() > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void initQuestionShell()
        {
            List<AnswerShell> answerShells = new List<AnswerShell>();
            foreach(Question question in test.Questions)
            {
                List<SavedAnswer> savedAnswers = new List<SavedAnswer>();
                foreach(Answer answer in question.Answers)
                {
                    SavedAnswer savedAnswer = new SavedAnswer(answer.IsCorrect,answer.Text);
                    savedAnswers.Add(savedAnswer);
                }
                AnswerShell answerShell = new AnswerShell(savedAnswers,question.Text);
                answerShells.Add(answerShell);
            }
            this.questionShell = new QuestionShell(QuestionNumber,answerShells);
        }
    }
}
