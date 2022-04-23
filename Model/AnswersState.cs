using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestingSystem.Model
{
    class AnswersState
    {
        Answer answer { get; set; }
        bool isChecked { get; set; }
        public AnswersState(Answer a, bool c)
        {
            answer = a;
            isChecked = c;
        }
    }
}
