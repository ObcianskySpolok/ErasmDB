using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProjectVariation: modelData
    {
        //public long ID { get; set; }
        public long ProjectID { get; set; }
        public string Call { get; set; }
        public string Title { get; set; }
        public string Acronym { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public DateTime EndDate { get; set; }
        public long Language { get; set; }
        public long ApplicantOrganization { get; set; }
        public long NationalAgency { get; set; }
        public long PartnerOrganization { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string Phase { get; set; }
        public string CustomVariable1 { get; set; }
        public string CustomVariable2 { get; set; }
        public string CustomVariable3 { get; set; }
        public string CustomVariable4 { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public string getProjectTitle()
        {
            var prj = Program.GData.dataProject.getProjects.First(c => c.ID == ProjectID);
            return prj.Title;
        }

        public override string GetModelName()
        {
            return "ProjectVariation";
        }

        public override string GetTitleInfo()
        {
            return Title;
        }
    }
}









