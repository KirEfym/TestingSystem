using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestingSystem.Interface
{
    interface IRefreshable
    {
        Action Refresh { get; set; }
    }
}
