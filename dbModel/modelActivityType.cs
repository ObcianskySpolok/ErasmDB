using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    class modelActivityType: modelData
    {
        //public long ID { get; set; }
        public string ActivityType { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            ActivityType = "New activity type";
        }

        public override string GetModelName()
        {
            return "ActivityType";
        }

        public override string GetTitleInfo()
        {
            return ActivityType;
        }
    }
}









