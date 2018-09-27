using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProjectActivityVariation: modelData
    {
        //public long ID { get; set; }
        public long ProjectVariation { get; set; }
        public long ProjectActivity { get; set; }
        public long CountryOfDestination { get; set; }
        public string StudyVisit { get; set; }
        public string CityOfDestination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string PeriodDates { get; set; }
        public int ParticipantsPerCountry { get; set; }
        public int ParticipantsTotal { get; set; }
        public int FewerOpportunitieTotal { get; set; }
        public int FewerOpportunitiePerCountry { get; set; }
        public int GTFTotal { get; set; }
        public int GTFPerCountry { get; set; }
        public float OrgSupport { get; set; }
        public float Travel { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public override string GetModelName()
        {
            return "ActivityVariation";
        }

        public override string GetTitleInfo()
        {
            return StudyVisit + " " + CityOfDestination;
        }
    }
}









