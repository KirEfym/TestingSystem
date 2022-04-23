using CustomValidatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WPFTestingSystem.CommandFolder;
using WPFTestingSystem.Interface;
using WPFTestingSystem.Manager;
using WPFTestingSystem.Model;
using WPFTestingSystem.View;

namespace WPFTestingSystem.ViewModel
{
   public class CreateTestWindowViewModel:ViewModelBase, ICloseWindow
    {
       private User user;
        private Test test;
        private TestManager testManager=new TestManager();
        private List<Category> categories;
        private string testNameField;
        private string selectedCategory;
        private string descriptionField;
        private int percent;
        private Command createTestCommand;
        EmtyStringValidator esv = new EmtyStringValidator();
        private Command addQuestionsAnswers;
        private Command closeWindow;
        public Command CreateTestCommand => createTestCommand ?? (createTestCommand = new Command(createTest));
        public Command AddQuestionsAnswers => addQuestionsAnswers ?? (addQuestionsAnswers = new Command(OpenQuestionAnswerWindow));
        public Command CloseWindow => closeWindow ?? (closeWindow = new Command(Closewindow));
        public List<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        public string TestNameField
        {
            get
            {
                return testNameField;
            }
            set
            {
                testNameField = value;
                OnPropertyChanged("TestNameField");
            }
        }
        public string SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public string DescriptionField
        {
            get
            {
                return descriptionField;
            }
            set
            {
                descriptionField = value;
                OnPropertyChanged("DescriptionField");
            }
        }
        public int Percent
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
        public CreateTestWindowViewModel(User user, List<Category> categories)
        {
            this.user = user;
            this.categories=categories;
        }
        private void createTest()
        {
            if (esv.ValidateText(testNameField) && esv.ValidateText(selectedCategory) && esv.ValidateText(descriptionField) && this.percent > 0)
            {


                string name = testNameField.Trim();
                string category = selectedCategory;
                string description = descriptionField.Trim();
                double percent = Convert.ToDouble(this.percent);
                //adds new test instance to xml file 
                XDocument document = XDocument.Load("Tests.xml");
                XElement root = document.Element("Tests");
                var lastId = (from r in root.Elements("Test") select r.Element("ID")).Last();
                int testId = Convert.ToInt32(lastId.Value) + 1;

                Test test = new Test() { Id = testId.ToString(), Name = name, Category = category, Description = description, Percent = percent, Created = DateTime.Now, Creator = user.Name };
                this.test = test;
                if (testManager.Create(test))
                {
                    MessageBox.Show("Your test was successully created");
                }
                else
                {
                    MessageBox.Show("Something went wrong try again later");
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields");
            }
        }
        private void OpenQuestionAnswerWindow()
        {
            if(test!=null)
            {
                QuestionAnswerWindow questionAnswerWindow = new QuestionAnswerWindow(this.test);
                questionAnswerWindow.Show();
            }
            else
            {
                MessageBox.Show("Test was not created");
            }
        }
        void Closewindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }

    }
}
