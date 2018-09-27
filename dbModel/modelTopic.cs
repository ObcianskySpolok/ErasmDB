using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    class modelTopic: modelData
    {
        //public long ID { get; set; }
        public string Topic { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public void CreateNewEmpty()
        {
            Topic = "NewTopic";
        }

        public override string GetModelName()
        {
            return "Topic";
        }

        public override string GetTitleInfo()
        {
            return Topic;
        }

    }

}









