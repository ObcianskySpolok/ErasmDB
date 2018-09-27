using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelPerson: modelData
    {
        //public long ID { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Facebook { get; set; }
        public long Role { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            Title = "";
            Gender = "";
            FirstName = "Person";
            LastName = "New";
            Email = "";
            Telephone = "";
            Facebook = "";
            Role = Program.GData.dataLOV.getRoles.ElementAt(0).ID;
        }

        public override string GetModelName()
        {
            return "Person";
        }

        public override string GetTitleInfo()
        {
            return LastName + " " + FirstName;
        }
    }
}









