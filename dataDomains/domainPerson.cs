using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace erasmDB
{
    class domainPerson
    {
        IEnumerable<modelPerson> tablePerson;

        PetaPoco.IDatabase db;

        public void Update(modelPerson person, bool reload = true)
        {
            if (person.CreatedDate.Year < 2000) person.CreatedDate = new DateTime(2000, 1, 1);
            person.UpdatedDate = DateTime.Now;
            db.Update("tblPerson", "ID", person);
            if (reload) LoadPersons();
        }
        public void Write(modelPerson person, bool reload = true)
        {
            db.Update("tblPerson", "ID", person);
            if (reload) LoadPersons();
        }
        public void Insert(modelPerson person, bool reload = true)
        {
            if(person.ID == 0)
            {
                person.ID = Program.GData.LongID();
                person.CreatedDate = DateTime.Now;
                person.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblPerson", "ID",false, person);
            if (reload) LoadPersons();
        }
        public void Delete(modelPerson person, bool reload = true)
        {
            db.Delete("tblPerson", "ID", person);
            if (reload) LoadPersons();
        }
        private void LoadPersons()
        {
            tablePerson = db.Query<modelPerson>("SELECT * FROM tblPerson");
        }

        public IEnumerable<modelPerson> getPersons
        {
            get { return tablePerson; }
        }
        public modelPerson getPerson(long ID)
        {
            return getPersons.First(c => c.ID == ID);
        }

        public void LoadData(bool? overideLocal = null)
        {
            db = Program.GData.ChooseDB(overideLocal);
            
            LoadPersons();
        }
    }
}
