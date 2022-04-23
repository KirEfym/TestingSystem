using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.Manager;
using WPFTestingSystem.Model;

namespace WPFTestingSystem.ViewModel
{
    public class StatisticsViewModel : ViewModelBase
    {
        List<Test> tests;
        StatisticsManager sm = new StatisticsManager();
        List<Statistics> statistics = new List<Statistics>();
        private string testName;
        DateTime from=DateTime.Today;
        DateTime to= DateTime.Today;
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
                OnPropertyChanged("DiapasonStatisticsByName");
            }
        }
        public DateTime From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
                OnPropertyChanged("From");
                OnPropertyChanged("DiapasonStatistics");
                OnPropertyChanged("DiapasonStatisticsByName");
            }
        }
        public DateTime To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
                OnPropertyChanged("To");
                OnPropertyChanged("DiapasonStatistics");
                OnPropertyChanged("DiapasonStatisticsByName");
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
        public List<Statistics> Statistics
        {
            get
            {
                return statistics;
            }
            set
            {
                statistics = value;
                OnPropertyChanged("Statistics");
            }
        }
        public List<Statistics> DiapasonStatistics
        {
            get
            {
                return this.statistics.FindAll(x => x.Date >= from && x.Date <= to);
            }
        }
        public List<Statistics> DiapasonStatisticsByName
        {
            get
            {
                return this.statistics.FindAll(x => x.Date >= from && x.Date <= to && x.TestName == this.TestName);
            }
        }
        public StatisticsViewModel(List<Test> tests)
        {
            statistics.AddRange(sm.GetAllStatistics());
            this.tests = tests;
        }
    }
}
