using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelField
    {
        public string Field;
        public int Index;

        public modelField(string fld, int idx)
        {
            Field = fld;
            Index = idx;
        }
    }
}
