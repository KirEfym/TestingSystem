using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingSystem.Model;

namespace WPFTestingSystem
{
    interface IGetable
    {
        Answer getAnswer();
        bool getCheced { get; }
        string getText { get; }
        bool setChecked { set; }
        bool IsCorrect { set; get; }
    }
}
