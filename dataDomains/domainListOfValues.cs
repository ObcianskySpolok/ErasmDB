using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace erasmDB
{
    class domainListOfValues
    {
        IEnumerable<modelCountry> tableContry;
        IEnumerable<modelLanguage> tableLanguage;
        IEnumerable<modelOrganizationType> tableOrganizationType;
        IEnumerable<modelRole> tableRole;
        IEnumerable<modelNationalAgency> tableNationalAgency;
        IEnumerable<modelDistanceBand> tableDistanceBand;
        IEnumerable<modelTopic> tableTopic;
        IEnumerable<modelClient> tableClient;

        PetaPoco.IDatabase db;

        public void Update(modelRole role, bool reload = true)
        {
            if (role.CreatedDate.Year < 2000) role.CreatedDate = new DateTime(2000, 1, 1);
            role.UpdatedDate = DateTime.Now;
            db.Update("tblRole", "ID", role);
            if (reload) LoadRoles();
        }
        public void Write(modelRole role, bool reload = true)
        {
            db.Update("tblRole", "ID", role);
            if (reload) LoadRoles();
        }
        public void Insert(modelRole role, bool reload = true)
        {
            if(role.ID == 0)
            {
                role.ID = Program.GData.LongID();
                role.CreatedDate = DateTime.Now;
                role.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblRole","ID",false, role);
            if (reload) LoadRoles();
        }
        public void Delete(modelRole role, bool reload = true)
        {
            db.Delete("tblRole", "ID", role);
            if (reload) LoadRoles();
        }
        private void LoadRoles()
        {
            tableRole = db.Query<modelRole>("SELECT * FROM tblRole");
        }

        public void Update(modelTopic topic, bool reload = true)
        {
            if (topic.CreatedDate.Year < 2000) topic.CreatedDate = new DateTime(2000, 1, 1);
            topic.UpdatedDate = DateTime.Now;
            db.Update("tblTopic", "ID", topic);
            if (reload) LoadTopics();
        }
        public void Write(modelTopic topic, bool reload = true)
        {
            db.Update("tblTopic", "ID", topic);
            if (reload) LoadTopics();
        }
        public void Insert(modelTopic topic, bool reload = true)
        {
            if (topic.ID == 0)
            {
                topic.ID = Program.GData.LongID();
                topic.CreatedDate = DateTime.Now;
                topic.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblTopic", "ID", false, topic);
            if (reload) LoadTopics();
        }
        public void Delete(modelTopic topic, bool reload = true)
        {
            db.Delete("tblTopic", "ID", topic);
            if (reload) LoadTopics();
        }
        private void LoadTopics()
        {
            tableTopic = db.Query<modelTopic>("SELECT * FROM tblTopic");
        }

        public void Update(modelClient client, bool reload = true)
        {
            if (client.CreatedDate.Year < 2000) client.CreatedDate = new DateTime(2000, 1, 1);
            client.UpdatedDate = DateTime.Now;
            db.Update("tblClient", "ID", client);
            if (reload) LoadClients();
        }
        public void Write(modelClient client, bool reload = true)
        {
            db.Update("tblClient", "ID", client);
            if (reload) LoadClients();
        }
        public void Insert(modelClient client, bool reload = true)
        {
            if (client.ID == 0)
            {
                client.ID = Program.GData.LongID();
                client.CreatedDate = DateTime.Now;
                client.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblClient", "ID", false, client);
            if (reload) LoadClients();
        }
        public void Delete(modelClient client, bool reload = true)
        {
            db.Delete("tblClient", "ID", client);
            if (reload) LoadClients();
        }
        private void LoadClients()
        {
            tableClient = db.Query<modelClient>("SELECT * FROM tblClient");
        }

        public void Update(modelCountry country, bool reload = true)
        {
            if (country.CreatedDate.Year < 2000) country.CreatedDate = new DateTime(2000, 1, 1);
            country.UpdatedDate = DateTime.Now;
            db.Update("tblCountry", "ID", country);
            if (reload) LoadCountries();
        }
        public void Write(modelCountry country, bool reload = true)
        {
            db.Update("tblCountry", "ID", country);
            if (reload) LoadCountries();
        }
        public void Insert(modelCountry country, bool reload = true)
        {
            if (country.ID == 0)
            {
                country.ID = Program.GData.LongID();
                country.CreatedDate = DateTime.Now;
                country.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblCountry", "ID",false, country);
            if (reload) LoadCountries();
        }
        public void Delete(modelCountry country, bool reload = true)
        {
            db.Delete("tblCountry", "ID", country);
            if (reload) LoadCountries();
        }
        private void LoadCountries()
        {
            tableContry = db.Query<modelCountry>("SELECT * FROM tblCountry");
        }

        public void Update(modelOrganizationType orgtypes, bool reload = true)
        {
            if (orgtypes.CreatedDate.Year < 2000) orgtypes.CreatedDate = new DateTime(2000, 1, 1);
            orgtypes.UpdatedDate = DateTime.Now;
            db.Update("tblOrganizationType", "ID", orgtypes);
            if (reload) LoadOrganizationTypes();
        }
        public void Write(modelOrganizationType orgtypes, bool reload = true)
        {
            db.Update("tblOrganizationType", "ID", orgtypes);
            if (reload) LoadOrganizationTypes();
        }
        public void Insert(modelOrganizationType orgtypes, bool reload = true)
        {
            if(orgtypes.ID == 0)
            {
                orgtypes.ID = Program.GData.LongID();
                orgtypes.CreatedDate = DateTime.Now;
                orgtypes.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblOrganizationType", "ID",false, orgtypes);
            if (reload) LoadOrganizationTypes();
        }
        public void Delete(modelOrganizationType orgtypes, bool reload = true)
        {
            db.Delete("tblOrganizationType", "ID", orgtypes);
            if (reload) LoadOrganizationTypes();
        }
        private void LoadOrganizationTypes()
        {
            tableOrganizationType = db.Query<modelOrganizationType>("SELECT * FROM tblOrganizationType");
        }

        public void Update(modelNationalAgency agency, bool reload = true)
        {
            if (agency.CreatedDate.Year < 2000) agency.CreatedDate = new DateTime(2000, 1, 1);
            agency.UpdatedDate = DateTime.Now;
            db.Update("tblNationalAgency", "ID", agency);
            if (reload) LoadNationalAgencies();
        }
        public void Write(modelNationalAgency agency, bool reload = true)
        {
            db.Update("tblNationalAgency", "ID", agency);
            if (reload) LoadNationalAgencies();
        }
        public void Insert(modelNationalAgency agency, bool reload = true)
        {
            if (agency.ID == 0)
            {
                agency.ID = Program.GData.LongID();
                agency.CreatedDate = DateTime.Now;
                agency.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblNationalAgency", "ID",false, agency);
            if (reload) LoadNationalAgencies();
        }
        public void Delete(modelNationalAgency agency, bool reload = true)
        {
            db.Delete("tblNationalAgency", "ID", agency);
            if (reload) LoadNationalAgencies();
        }
        private void LoadNationalAgencies()
        {
            tableNationalAgency = db.Query<modelNationalAgency>("SELECT * FROM tblNationalAgency");
        }

        public void Update(modelLanguage language, bool reload = true)
        {
            if (language.CreatedDate.Year < 2000) language.CreatedDate = new DateTime(2000, 1, 1);
            language.UpdatedDate = DateTime.Now;
            db.Update("tblLanguage", "ID", language);
            if (reload) LoadLanguages();
        }
        public void Write(modelLanguage language, bool reload = true)
        {
            db.Update("tblLanguage", "ID", language);
            if (reload) LoadLanguages();
        }
        public void Insert(modelLanguage language, bool reload = true)
        {
            if(language.ID == 0)
            {
                language.ID = Program.GData.LongID();
                language.CreatedDate = DateTime.Now;
                language.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblLanguage", "ID", false, language);
            if (reload) LoadLanguages();
        }
        public void Delete(modelLanguage language, bool reload = true)
        {
            db.Delete("tblLanguage", "ID", language);
            if (reload) LoadLanguages();
        }
        private void LoadLanguages()
        {
            tableLanguage = db.Query<modelLanguage>("SELECT * FROM tblLanguage");
        }

        public void Update(modelDistanceBand band, bool reload = true)
        {
            if (band.CreatedDate.Year < 2000) band.CreatedDate = new DateTime(2000, 1, 1);
            band.UpdatedDate = DateTime.Now;
            db.Update("tblDistanceBand", "ID", band);
            if (reload) LoadDistanceBands();
        }
        public void Write(modelDistanceBand band, bool reload = true)
        {
            db.Update("tblDistanceBand", "ID", band);
            if (reload) LoadDistanceBands();
        }
        public void Insert(modelDistanceBand band, bool reload = true)
        {
            if(band.ID == 0)
            {
                band.ID = Program.GData.LongID();
                band.CreatedDate = DateTime.Now;
                band.UpdatedDate = DateTime.Now;
            }
            db.Insert("tblDistanceBand", "ID",false, band);
            if (reload) LoadDistanceBands();
        }
        public void Delete(modelDistanceBand band, bool reload = true)
        {
            db.Delete("tblDistanceBand", "ID", band);
            if (reload) LoadDistanceBands();
        }
        private void LoadDistanceBands()
        {
            tableDistanceBand = db.Query<modelDistanceBand>("SELECT * FROM tblDistanceBand");
        }


        public IEnumerable<modelCountry> getCountries
        {
            get { return tableContry; }
        }
        public modelCountry getCountry(long ID)
        {
            if(ID == 0) return null;
            return getCountries.First(c => c.ID == ID);
        }
        public IEnumerable<modelLanguage> getLanguages
        {
            get { return tableLanguage; }
        }
        public modelLanguage getLanguage(long ID)
        {
            return getLanguages.First(c => c.ID == ID);
        }
        public IEnumerable<modelOrganizationType> getOrganizationTypes
        {
            get { return tableOrganizationType; }
        }
        public modelOrganizationType getOrganizationType(long ID)
        {
            return getOrganizationTypes.First(c => c.ID == ID);
        }
        public IEnumerable<modelRole> getRoles
        {
            get { return tableRole; }
        }
        public modelRole getRole(long ID)
        {
            return getRoles.First(c => c.ID == ID);
        }
        public IEnumerable<modelNationalAgency> getNationalAgencies
        {
            get { return tableNationalAgency; }
        }
        public modelNationalAgency getNationalAgency(long ID)
        {
            if (ID == 0) return null;
            return getNationalAgencies.First(c => c.ID == ID);
        }
        public IEnumerable<modelDistanceBand> getDistanceBands
        {
            get { return tableDistanceBand; }
        }
        public modelDistanceBand getDistanceBand(long ID)
        {
            if (ID == 0) return null; 
            return getDistanceBands.First(c => c.ID == ID);
        }
        public IEnumerable<modelTopic> getTopics
        {
            get { return tableTopic; }
        }
        public modelTopic getTopic(long ID)
        {
            return getTopics.First(c => c.ID == ID);
        }
        public IEnumerable<modelClient> getClients
        {
            get { return tableClient; }
        }
        public modelClient getClient(long ID)
        {
            return getClients.First(c => c.ID == ID);
        }

        public void LoadData(bool? overideLocal = null)
        {
            db = Program.GData.ChooseDB(overideLocal);

            LoadCountries();
            LoadRoles();
            LoadClients();
            LoadTopics();
            LoadLanguages();            
            LoadNationalAgencies();            
            LoadDistanceBands();
            LoadOrganizationTypes();

        }
    }
}
