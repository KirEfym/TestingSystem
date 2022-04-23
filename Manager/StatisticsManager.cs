using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WPFTestingSystem.Model;

namespace WPFTestingSystem.Manager
{
    class StatisticsManager
    {
        public bool AddStatisticsItem(Statistics statistics)
        {
            if (File.Exists("Statistics.xml"))
            {
                XDocument document = XDocument.Load("Statistics.xml");
                XElement root = document.Element("Statistics");
                XElement statistic = new XElement("Statistic");
                XElement userName = new XElement("UserName", statistics.UserName.Trim());
                XElement testName = new XElement("TestName", statistics.TestName.Trim());
                XElement date = new XElement("Date", statistics.Date);
                XElement passPercent = new XElement("PassPercent", statistics.PassPercent);
                XElement isPassed = new XElement("IsPassed", statistics.IsPassed);
                root.Add(statistic);
                statistic.Add(userName);
                statistic.Add(testName);
                statistic.Add(date);
                statistic.Add(passPercent);
                statistic.Add(isPassed);
                document.Save("Statistics.xml");
                return true;
            }
            else
            { return false; }
        }
        public List<Statistics> GetAllStatistics()
        {
            List<Statistics> statistics = new List<Statistics>();
            if (File.Exists("Statistics.xml"))
            {
                XDocument document = XDocument.Load("Statistics.xml");
                XElement root = document.Element("Statistics");
                IEnumerable<Statistics> enumTest = from r in root.Elements("Statistic")
                                                   select new Statistics
                                                   {
                                                       UserName= r.Element("UserName").Value,
                                                       Date = Convert.ToDateTime(r.Element("Date").Value),
                                                       IsPassed = Convert.ToBoolean(r.Element("IsPassed").Value),
                                                       PassPercent = Convert.ToDouble(r.Element("PassPercent").Value),
                                                       TestName = r.Element("TestName").Value
                                                   };
                statistics.AddRange(enumTest);
            }
            return statistics;
        }

    }
}
