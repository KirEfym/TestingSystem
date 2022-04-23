using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.ViewModel;

namespace WPFTestingSystem.Model
{
   public class Statistics:ViewModelBase
    {
        private string userName;
        private string testName;
        private DateTime date;
        private double passPercent;
        private bool isPassed;
        public string UserName 
        { 
            get
            {
                return userName;
            }
            set 
            {
                userName = value;
                OnPropertyChanged("UserName");
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
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public double PassPercent
        {
            get
            {
                return passPercent;
            }
            set
            {
                passPercent = value;
                OnPropertyChanged("PassPercent");
            }
        }
        public bool IsPassed
        {
            get
            {
                return isPassed;
            }
            set
            {
                isPassed = value;
                OnPropertyChanged("IsPassed");
            }
        }

        public object this[int index]
        {
            get
            {
                switch (index)
                {

                    case 1:
                        return this.UserName;
                    case 2:
                        return this.TestName;
                    case 3:
                        return this.Date;
                    case 4:
                        return this.PassPercent;
                    case 5:
                        return this.IsPassed;

                    default:
                        return null;

                }
            }
        }
    }
}
