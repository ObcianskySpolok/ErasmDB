using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelOrganizationDescription: modelData
    {
        //public long ID { get; set; }
        public long Organization { get; set; }
        public long Type { get; set; }
        public string BackgroundAndExperience { get; set; }
        public string BriefDescription { get; set; }
        public string BriefActivities { get; set; }
        public string StaffInvolved { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

    }
}
