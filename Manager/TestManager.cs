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
    class TestManager
    {
        public bool Create(Test _test)
        {
            if (File.Exists("Tests.xml"))
            {
                XDocument document = XDocument.Load("Tests.xml");
                XElement root = document.Element("Tests");
                XElement test = new XElement("Test");
                XElement testId = new XElement("ID", _test.Id);
                XElement testName = new XElement("Name", _test.Name);
                XElement testCategory = new XElement("Category", _test.Category);
                XElement testCreator = new XElement("Creator", _test.Creator);
                XElement testCreated = new XElement("Created", _test.Created.ToShortTimeString());
                XElement testDescription = new XElement("Description", _test.Description);
                XElement testPercentage = new XElement("Percentage", _test.Percent);
                XElement testQuestions = new XElement("Questions");
                root.Add(test);
                test.Add(testId);
                test.Add(testName);
                test.Add(testCategory);
                test.Add(testDescription);
                test.Add(testPercentage);
                test.Add(testQuestions);
                test.Add(testCreator);
                test.Add(testCreated);
                document.Save("Tests.xml");
                return true;
            }
            else
            { return false; }
        }
        public bool Delete(int id)
        {
            return false;
        }
        public List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();
            if (File.Exists("Tests.xml"))
            {
                XDocument document = XDocument.Load("Tests.xml");
                XElement root = document.Element("Tests");
                IEnumerable<Test> enumTest = from r in root.Elements("Test")
                                             select new Test
                                             {
                                                 Id = r.Element("ID").Value,
                                                 Name = r.Element("Name").Value,
                                                 Category = r.Element("Category").Value,
                                                 Created = Convert.ToDateTime(r.Element("Created").Value),
                                                 Creator = r.Element("Creator").Value,
                                                 Description = r.Element("Description").Value,
                                                 Percent = Convert.ToDouble(r.Element("Percentage").Value),
                                                 Questions = ConvertQuest(from q in r.Element("Questions").Elements("Question") select new Question { Text = q.Element("Text").Value, Answers = ConvertAnswer(from a in q.Element("Answers").Elements("Answer") select new Answer { IsCorrect = Convert.ToBoolean(a.Element("IsCorrect").Value), Text = a.Element("Test").Value }) })
                                             };
                tests.AddRange(enumTest);
            }
            return tests;
        }
        public Test GetTest(int id)
        {
            return null;
        }
        public bool AddQuestion(string testId, string body)
        {
            if (File.Exists("Tests.xml"))
            {
                XDocument document = XDocument.Load("Tests.xml");
                XElement root = document.Element("Tests");
                XElement test = root.Elements("Test").First(t => t.Element("ID").Value == testId);
                test.Element("Questions").Add(new XElement("Question", new XElement("Text", body), new XElement("Answers")));
                document.Save("Tests.xml");
                return true;
            }
            return false;
        }
        public bool AddAnswer(string testId, string question, string body, bool isCorrect)
        {
            if (File.Exists("Tests.xml"))
            {
                XDocument document = XDocument.Load("Tests.xml");
                XElement root = document.Element("Tests");
                XElement test = root.Elements("Test").First(t => t.Element("ID").Value == testId);
                XElement getQuestion = test.Element("Questions").Elements("Question").First(q => q.Element("Text").Value == question);
                getQuestion.Element("Answers").Add(new XElement("Answer", new XElement("Test", body), new XElement("IsCorrect", isCorrect)));
                document.Save("Tests.xml");
                return true;
            }
            return false;
        }
        public bool DeleteQuestion(Question question)
        {
            return false;
        }
        public bool GetTestQuestions(Test test)
        {
            if (test != null)
                if (File.Exists("Tests.xml"))
                {
                    XDocument document = XDocument.Load("Tests.xml");
                    XElement root = document.Element("Tests");
                    var questions = from r in root.Elements("Test")
                                    where r.Element("ID").Value == test.Id
                                    select r.Element("Questions");
                    Question quest;
                    foreach (var q in questions)
                    {
                        if (q.Element("Question") != null)
                        {
                            quest = new Question()
                            {
                                Text = q.Element("Question").Element("Text").Value,
                                Answers = (from a in q.Element("Question").Element("Answers").Elements("Answer")
                                           select new Answer()
                                           {
                                               Text = a.Element("Test").Value,
                                               IsCorrect = Convert.ToBoolean(a.Element("IsCorrect").Value)
                                           }).ToList()
                            };
                            test.Questions.Add(quest);
                        }
                    }
                }


            //дозагрузить вопросы в тест
            return false;
        }
        List<Question> ConvertQuest(IEnumerable<Question> questions)
        {
            List<Question> temp = new List<Question>();
            foreach (var v in questions)
            {
                temp.Add(v);
            }
            return temp;
        }
        List<Answer> ConvertAnswer(IEnumerable<Answer> answers)
        {
            List<Answer> temp = new List<Answer>();
            foreach (var v in answers)
            {
                temp.Add(v);
            }
            return temp;
        }
    }
}
