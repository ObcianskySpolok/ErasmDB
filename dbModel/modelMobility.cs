using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelMobility: modelData
    {
        //public long ID { get; set; }
        public long ActivityVariation { get; set; }
        public long CountryOfOrigin { get; set; }
        public long DistanceBand { get; set; }
        public int TravelDays { get; set; }
        public int Participants { get; set; }
        public int FewerOpportunities { get; set; }
        public int GroupLeaders { get; set; }
        public int Trainers { get; set; }
        public int Facilitators { get; set; }
        public int Others { get; set; }
        public int MobilityOrder { get; set; }
        public float Rate { get; set; }
        public float Price { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public override string GetModelName()
        {
            return "Mobility";
        }

        public override string GetTitleInfo()
        {
            return "MOB";
        }
    }
}









