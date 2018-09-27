using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelOrganization: modelData
    {
        //public long ID { get; set; }
        public int PIC { get; set; }
        public string LegalName { get; set; }
        public string LegalNameLatinChar { get; set; }
        public string EnglishName { get; set; }
        public string FriendlyName { get; set; }
        public string Acronym { get; set; }
        public string LegalForm { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public long Country { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public long TypeOfOrganization { get; set; }
        public bool PublicBody { get; set; }
        public bool NonProfit { get; set; }
        public string Accreditation { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public string RepresentativeFunction { get; set; }
        public string LegalStatus { get; set; }
        public string RegistrationNumber { get; set; }
        public string VAT { get; set; }
        public string GeneralDescription { get; set; }
        public string Description { get; set; }
        public string Activities { get; set; }
        public string KeyStaff { get; set; }
        public string ContractNumber { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            PIC = 1111111;
            LegalName = "New Organization";
            LegalNameLatinChar = "";
            EnglishName = "";
            FriendlyName = "";
            Acronym = "";
            LegalForm = "";
            Address = "";
            PostCode = "";
            City = "";
            Country = Program.GData.dataLOV.getCountries.ElementAt(0).ID;
            Email = "";
            Website = "";
            TypeOfOrganization = Program.GData.dataLOV.getOrganizationTypes.ElementAt(0).ID;
            Phone = "";
            PublicBody = false;
            NonProfit = false;
            Accreditation = "";
            Address = "";
            FirstName = "";
            SurName = "";
            Gender = "";
            RepresentativeFunction = "";
            LegalStatus = "";
            RegistrationNumber = "";
            VAT = "";
            GeneralDescription = "";
            Description = "";
            Activities = "";
            KeyStaff = "";
            ContractNumber = "";
        }
        public string Representative()
        {
            return FirstName + " " + SurName + ", " + RepresentativeFunction;
        }
        public string getCountry()
        {
            if (Country == 0) return "";

            var country = Program.GData.dataLOV.getCountries.First(c => c.ID == Country);
            return country.Country;
        }
        public string getCountryCode()
        {
            if (Country == 0) return "";
            var country = Program.GData.dataLOV.getCountries.First(c => c.ID == Country);
            return country.Code;
        }

        public override string GetModelName()
        {
            return "Organization";
        }

        public override string GetTitleInfo()
        {
            return LegalName;
        }
    }

    public class OrganizationSelect
    {
        public bool Selected { get; set; }
        public string Code { get; set; }
        public long ID { get; set; }
        public string LegalName { get; set; }
        public string Acronym { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}
