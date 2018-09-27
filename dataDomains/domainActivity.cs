using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace erasmDB
{
    class domainActivity
    {
        IEnumerable<modelActivityType> tableActivityType;
        IEnumerable<modelMobility> tableMobility;
        PetaPoco.IDatabase db;

        public void Update(modelActivityType activitytype, bool reload = true)
        {
            if (activitytype.CreatedDate.Year < 2000) activitytype.CreatedDate = new DateTime(2000, 1, 1);
            activitytype.UpdatedDate = DateTime.Now;
            db.Update("tblActivityType", "ID", activitytype);
            if (reload) LoadActivityTypes();
        }
        public void Insert(modelActivityType activitytype, bool reload = true)
        {
            if(activitytype.ID== 0)
            {
                activitytype.ID = Program.GData.LongID();
                activitytype.CreatedDate = DateTime.Now;
                activitytype.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblActivityType", "ID", false, activitytype);
            if (reload) LoadActivityTypes();
        }
        public void Write(modelActivityType activitytype, bool reload = true)
        {
            db.Update("tblActivityType", "ID", activitytype);
            if (reload) LoadActivityTypes();
        }
        public void Delete(modelActivityType activitytype, bool reload = true)
        {
            db.Delete("tblActivityType", "ID", activitytype);
            if (reload) LoadActivityTypes();
        }
        private void LoadActivityTypes()
        {
            tableActivityType = db.Query<modelActivityType>("SELECT * FROM tblActivityType");
        }


        public void Update(modelMobility mobility, bool reload = true)
        {
            if (mobility.CreatedDate.Year < 2000) mobility.CreatedDate = new DateTime(2000, 1, 1);
            mobility.UpdatedDate = DateTime.Now;
            db.Update("tblMobility", "ID", mobility);
            Console.WriteLine("mob:{0}", mobility.ID);
            if(reload) LoadMobility();
        }
        public void Insert(modelMobility mobility, bool reload = true)
        {
            if(mobility.ID == 0)
            {
                mobility.ID = Program.GData.LongID();
                mobility.CreatedDate = DateTime.Now;
                mobility.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblMobility", "ID", false, mobility);
            if (reload) LoadMobility();
        }
        public void Write(modelMobility mobility, bool reload = true)
        {
            db.Update("tblMobility", "ID",  mobility);
            if (reload) LoadMobility();
        }
        public void Delete(modelMobility mobility, bool reload = true)
        {
            db.Delete("tblMobility", "ID", mobility);
            if (reload) LoadMobility();
        }
        public void LoadMobility()
        {
            tableMobility = db.Query<modelMobility>("SELECT * FROM tblMobility");
        }

        //public IEnumerable<modelActivity> getActivities
        //{
        //    get { return tableActivity; }
        //}
        public IEnumerable<modelActivityType> getActivityTypes
        {
            get { return tableActivityType; }
        }
        public modelActivityType getActivityType(long ID)
        {
            return getActivityTypes.First(c => c.ID == ID);
        }
        public IEnumerable<modelMobility> getMobilities
        {
            get { return tableMobility; }
        }
        public modelMobility getMobility(long id)
        {
            return getMobilities.First(c => c.ID == id);
        }

        public void LoadData(bool? overideLocal = null)
        {
            db = Program.GData.ChooseDB(overideLocal);

            //LoadActivities();
            LoadActivityTypes();
            LoadMobility();
        }
    }
}
