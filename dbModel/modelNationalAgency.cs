using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelNationalAgency: modelData
    {
        //public long ID { get; set; }
        public long Country { get; set; }
        public string NACode { get; set; }
        public string AgencyName { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            NACode = "";
            AgencyName = "NewAgency";
            Country = Program.GData.dataLOV.getCountries.ElementAt(0).ID;
        }

        public string getCountry()
        {
            var country = Program.GData.dataLOV.getCountries.First(c => c.ID == Country);
            return country.Country;
        }
        public string getCountryCode()
        {
            var country = Program.GData.dataLOV.getCountries.First(c => c.ID == Country);
            return country.Code;
        }

        public override string GetModelName()
        {
            return "NationalAgency";
        }

        public override string GetTitleInfo()
        {
            return AgencyName + " " + NACode;
        }
    }
}









