using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    class modelDistanceBand: modelData
    {
        //public long ID { get; set; }
        public string DistanceBand { get; set; }
        public float Price { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            DistanceBand = "0-1km";
        }

        public override string GetModelName()
        {
            return "DistanceBand";
        }

        public override string GetTitleInfo()
        {
            return DistanceBand;
        }
    }
}









