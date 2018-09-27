using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelClient: modelData
    {
        //public long ID { get; set; }
        public string ComputerName { get; set; }
        public int ComputerID { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public modelClient()
        {
        }

        public modelClient(string computername, int computerid)
        {
            ComputerID = computerid;
            ComputerName = computername;
        }

        public override string GetModelName()
        {
            return "Client";
        }

        public override string GetTitleInfo()
        {
            return ComputerName;
        }
    }

}









