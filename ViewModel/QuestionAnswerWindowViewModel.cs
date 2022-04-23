using CustomValidatorLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTestingSystem.CommandFolder;
using WPFTestingSystem.Interface;
using WPFTestingSystem.Manager;
using WPFTestingSystem.Model;

namespace WPFTestingSystem.ViewModel
{
    class QuestionAnswerWindowViewModel:ViewModelBase, ICloseWindow
    {
        private Test test;
        EmtyStringValidator emtyString = new EmtyStringValidator();
        TestManager tm = new TestManager();
        private ObservableCollection<string> questions=new ObservableCollection<string>();
        private string selectedQuestion;
        private string answer;
        private string question;
        private bool checkBox;
        private ObservableCollection<string> answerList=new ObservableCollection<string>();
        private Command addAnswerCommand;
        private Command addQuestionCommand;
        private Command closeWindow;
        public Command AddAnswerCommand => addAnswerCommand ?? (addAnswerCommand = new Command(addAnswer));
        public Command AddQuestionCommand => addQuestionCommand ?? (addQuestionCommand = new Command(addQuestion));
        public Command CloseWindow => closeWindow ?? (closeWindow = new Command(Closewindow));
        public ObservableCollection<string> AnswerList
        {
            get
            {
                return answerList;
            }
            set
            {
                answerList = value;
                OnPropertyChanged("AnswerList");
            }
        }
        public bool CheckBox
        {
            get
            {
                return checkBox;
            }
            set
            {
                checkBox = value;
                OnPropertyChanged("CheckBox");
            }
        }
        public ObservableCollection<string> Questions
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
        public string SelectedQuestion
        {
            get
            {
                return selectedQuestion;
            }
            set
            {
                selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }
        public string Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public QuestionAnswerWindowViewModel(Test test)
        {
            this.test = test;
            initComboBox();
        }
        private void initComboBox()
        {
            if (test != null)
            {
                tm.GetTestQuestions(test);
                foreach (Question q in test.Questions)
                {
                    questions.Add(q.Text);
                    OnPropertyChanged("Questions");
                }

            }
        }
        private void addQuestion()
        {
            if (emtyString.ValidateText(question))
            {

                string text = question.Trim();
                if (tm.AddQuestion(test.Id, text))
                {
                    questions.Add(text);
                    OnPropertyChanged("Questions");
                    MessageBox.Show("Question added");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Question field is empty");
            }
        }
        private void addAnswer()
        {
            if (emtyString.ValidateText(answer) && selectedQuestion != null)
            {

                string text = answer.Trim();//Remowes all  spaces in the beginning and end of the string
                if (tm.AddAnswer(test.Id, selectedQuestion, text, checkBox))
                {
                    answerList.Add(text);
                    OnPropertyChanged("AnswerList");
                    MessageBox.Show("Answer added");
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            else
            {
                MessageBox.Show("Answer field or/and question box is empty");
            }
        }
        void Closewindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }

    }
}
