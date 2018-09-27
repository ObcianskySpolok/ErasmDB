using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProjectTopic: modelData
    {
        //public long ID { get; set; }
        public long Project { get; set; }
        public long Topic { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public override string GetModelName()
        {
            return "ProjectTopic";
        }

        public override string GetTitleInfo()
        {
            return "PRJTOP";
        }
    }
}









