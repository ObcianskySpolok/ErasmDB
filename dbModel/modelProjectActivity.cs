using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProjectActivity : modelData
    {
        //public long ID { get; set; }
        public long ProjectID { get; set; }
        public long ActivityID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public override string GetModelName()
        {
            return "ProjectActivity";
        }

        public override string GetTitleInfo()
        {
            return "PRJACT";
        }
    }
}









