using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelProjectCall
    {
        public string Call;
        public DateTime Date;

        public modelProjectCall(string call,DateTime date)
        {
            Call = call;
            Date = date;
        }
    }
}
