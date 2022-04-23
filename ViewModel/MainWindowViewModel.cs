using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFTestingSystem.CommandFolder;
using WPFTestingSystem.Interface;
using WPFTestingSystem.Manager;
using WPFTestingSystem.Model;
using WPFTestingSystem.View;

namespace WPFTestingSystem.ViewModel
{
    class MainWindowViewModel:ViewModelBase, IRefreshable
    {
        private Command statisticsWindowCommand;
        private User currentUser;
        private Command searchCommand;
        private ObservableCollection<Category> categories=new ObservableCollection<Category>();
        private string searchTexBox;
        private Command createTestWindowCommand;
        private Command questionAnswerWindowCommand;
        private Command doTestWindowCommand;
        private Command refreshCommand;
        private Test selectedDataGridItem;
        private TreeViewFormatTest selectedItemTreeview;
        private List<Test> tests = new List<Test>();
        TestManager tm = new TestManager();
        //List<Test> tests = new List<Test>();
        public Object SelectedItemTreeview
        {
            get
            {
                return (object)selectedItemTreeview;
            }
            
            set
            {
                if(value.ToString()== typeof(TreeViewFormatTest).FullName)
                {
                    if (value != null)
                    {
                        selectedItemTreeview = (TreeViewFormatTest)value;
                        OnPropertyChanged("SelectedItemTreeview");
                        SearchTexBox = selectedItemTreeview.TestName;
                    }
                }
                
                
            }
        }
        public Test SelectedDataGridItem
        {
            get
            {
                return selectedDataGridItem;
            }
            set
            {
                selectedDataGridItem = value;
                OnPropertyChanged("SelectedDataGridItem");
            }
        }
        public string SearchTexBox
        {
            get
            {
                return searchTexBox;
            }
            set
            {
                searchTexBox = value;
                OnPropertyChanged("SearchTexBox");
            }
        }
        public List<Test> Tests
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
        public ObservableCollection<Category> Categories
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
        public Command SearchCommand => searchCommand ?? (searchCommand = new Command(Search));
        public Command CreateTestCommand => createTestWindowCommand ?? (createTestWindowCommand = new Command(OpenCreateTestWindow));
        public Command StatisticsWindowCommand => statisticsWindowCommand ?? (statisticsWindowCommand = new Command(OpenStatisticsWindow));
        public Command QuestionAnswerWindowCommand => questionAnswerWindowCommand ?? (questionAnswerWindowCommand = new Command(OpenQuestionAnswerWindow));
        public Command DoTestWindowCommand => doTestWindowCommand ?? (doTestWindowCommand = new Command(DoTestWindow));
        public Command RefreshCommand => refreshCommand ?? (refreshCommand = new Command(refresh));
        
        public Action Refresh { get ; set ; }


        public MainWindowViewModel()
        {
            tests.AddRange(tm.GetAllTests());
            initTreeViwe();
        }
        public MainWindowViewModel(User currentUser)
        {
            this.currentUser = currentUser;
            tests.AddRange(tm.GetAllTests());
            initTreeViwe();
        }
        public void Search()
        {
            Tests.Clear();
            Tests.AddRange(tm.GetAllTests().FindAll(x => x.Name.Contains(searchTexBox)));
            OnPropertyChanged("Tests");
            Refresh?.Invoke();
        }
        public void OpenCreateTestWindow()
        {
            CreateTestWindow createTestWindow = new CreateTestWindow(currentUser,new List<Category>(categories));
            createTestWindow.Show();
        }
        public void OpenStatisticsWindow()
        {
            StatisticsWindow statisticWindow = new StatisticsWindow(tests);
            statisticWindow.Show();
        }
        public void OpenQuestionAnswerWindow()
        {
            
             if(searchTexBox != null)
            {
                QuestionAnswerWindow questionAnswerWindow = new QuestionAnswerWindow(tests.First(t => t.Name == searchTexBox));
                questionAnswerWindow.Show();
            }
            else
            {
                MessageBox.Show("Test is not selected");
            }
        }
        public void DoTestWindow()
        {
            DoTestWindow doTestWindow = new DoTestWindow(SelectedDataGridItem,currentUser);
            doTestWindow.Show();
        }
        private bool selctedItemCheck(string text)
        {
            foreach(Test t in tests)
            {
                if(t.Name==text)
                {
                    return true;
                }
            }
            return false;
        }
        void initTreeViwe()
        {
            categories.Clear();
            foreach (var t in tests.Select(ts => ts.Category).Distinct())
            {
                Category temp = new Category(t);
                categories.Add(temp);
                OnPropertyChanged("Categories");
                foreach (var item in tests.FindAll(x => x.Category == t && x.Questions.Count > 0))
                {
                   temp.Tests.Add(new TreeViewFormatTest(item.Name,item.Description,item.Id));
                }
            }
        }
        private void refresh()
        {
            Tests.Clear();
            Tests.AddRange(tm.GetAllTests());
            initTreeViwe();
        }
        
    }
}
