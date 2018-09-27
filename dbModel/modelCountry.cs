using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelCountry : modelData
    {
        //public long ID { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public float Rate { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public string CountryCode()
        {
            return Code + " " + Country;
        }

        public void CreateNewEmpty()
        {
            Code = "AA";
            Country = "NewCountry";
        }

        public override string GetModelName()
        {
            return "Countries";
        }

        public override string GetTitleInfo()
        {
            return Country;
        }
    }
}









