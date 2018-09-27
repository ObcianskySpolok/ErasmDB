using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelRole: modelData
    {
        //public long ID { get; set; }
        public string Role { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            Role = "NewRole";
        }

        public override string GetModelName()
        {
            return "Role";
        }

        public override string GetTitleInfo()
        {
            return Role;
        }

    }

}









