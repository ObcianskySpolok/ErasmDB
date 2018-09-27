using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace erasmDB
{
    class domainOrganization
    {
        IEnumerable<modelOrganization> tableOrganization;
        //IEnumerable<modelOrganizationDescription> tableOrganizationDescription;
        //IEnumerable<modelOrganizationPerson> tableOrganizationPerson;

        PetaPoco.IDatabase db;

        public void Update(modelOrganization organization, bool reload = true)
        {
            if (organization.CreatedDate.Year < 2000) organization.CreatedDate = new DateTime(2000, 1, 1);
            organization.UpdatedDate = DateTime.Now;
            db.Update("tblOrganization", "ID", organization);
            if (reload) LoadOrganizations();
        }
        public void Write(modelOrganization organization, bool reload = true)
        {
            db.Update("tblOrganization", "ID", organization);
            if (reload) LoadOrganizations();
        }
        public void Insert(modelOrganization organization, bool reload = true)
        {
            if (organization.ID == 0)
            {
                organization.ID = Program.GData.LongID();
                organization.CreatedDate = DateTime.Now;
                organization.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblOrganization", "ID", false, organization);
            if (reload) LoadOrganizations();
        }
        public void Delete(modelOrganization organization, bool reload = true)
        {
            db.Delete("tblOrganization", "ID", organization);
            if (reload) LoadOrganizations();
        }
        private void LoadOrganizations()
        {
            tableOrganization = db.Query<modelOrganization>("SELECT * FROM tblOrganization");
        }

        public IEnumerable<modelOrganization> getOrganizations
        {
            get { return tableOrganization; }
        }
        public modelOrganization getOrganization(long ID)
        {
            return getOrganizations.First(c => c.ID == ID);
        }

        public void LoadData(bool? overideLocal = null)
        {
            db = Program.GData.ChooseDB(overideLocal);

            LoadOrganizations();
            //LoadOrganizationPersons();
            //LoadOrganizationDescriptions();
        }
    }
}
