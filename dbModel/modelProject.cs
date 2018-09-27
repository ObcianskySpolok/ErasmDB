using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProject : modelData
    {
        //public long ID { get; set; }
        public string Title { get; set; }
        public string KeyAction { get; set; }
        public string Action { get; set; }
        public int ActionType { get; set; }
        public string WrittenBy { get; set; }
        public string Topic { get; set; }
        public string Topic2 { get; set; }
        public string Topic3 { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            Title = "New Project";
            KeyAction = "";
            Action = "";
            ActionType = 0;
            WrittenBy = "";
            Description = "";
            Comments = "";
            Topic = "";
        }

        public override string GetModelName()
        {
            return "Project";
        }

        public override string GetTitleInfo()
        {
            return Title;
        }
    }
}









