﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    [Serializable]
    public class modelProjectVariationOrganization: modelData
    {
        //public long ID { get; set; }
        public long ProjectVariation { get; set; }
        public long Organization { get; set; }
        public int OrganizationOrder { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public bool Active { get; set; }

        public override string GetModelName()
        {
            return "Languages";
        }

        public override string GetTitleInfo()
        {
            return "PRJVARORG";
        }
    }
}









