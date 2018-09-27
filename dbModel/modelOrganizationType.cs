using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelOrganizationType: modelData
    {
        //public long ID { get; set; }
        public string OrganizationType { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }


        public override string GetModelName()
        {
            return "OrganizationType";
        }

        public override string GetTitleInfo()
        {
            return OrganizationType;
        }
    }

}
