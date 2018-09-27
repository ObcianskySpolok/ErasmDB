using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelData
    {
        public long ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }

        public virtual string GetModelName()
        {
            return "--";
        }

        public virtual string  GetTitleInfo()
        {
            return "UNDEF";
        }
    }
}
