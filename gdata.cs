using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB
{
    class gdata {
        public int CFG_DB_USE;
        public string SqlSOURCE;
        public string AccessSOURCE;
        public string AzureSOURCE;
        public string CFGFolderLocal;
        public int CFGStationID;
        public bool CFGisAdmin;
        public domainPerson dataPerson;
        public domainOrganization dataOrganization;
        public domainListOfValues dataLOV;
        public domainProject dataProject;
        public domainActivity dataActivity;

        public List<modelProjectCall> projectCalls;

        private IniFile settingsFile;

        public string getINIValue(IniFile settingsFile, string section, string key, string defaulValue)
        {
            string cfgval = settingsFile.Read(key, section);
            if (String.IsNullOrEmpty(cfgval))
            {
                cfgval = defaulValue;
            }

            return cfgval;
        }
        public int getINIValueInt(IniFile settingsFile, string section, string key, int defaulValue)
        {
            string cfgval = settingsFile.Read(key, section);
            if (String.IsNullOrEmpty(cfgval))
            {
                cfgval = defaulValue.ToString();
            }
            int newval = defaulValue;
            int.TryParse(cfgval, out newval);
            return newval;
        }
        void putINIValue(IniFile settingsFile, string section, string key, string value)
        {
            settingsFile.Write(key, value, section);
        }
        void putINIValueInt(IniFile settingsFile, string section, string key, int value)
        {
            settingsFile.Write(key, value.ToString(), section);
        }

        public void InitParams(string configFile)
        {
            CFG_DB_USE = -1;

            settingsFile = new IniFile(configFile);

            SqlSOURCE = Program.GData.getINIValue(settingsFile, "Global", "DB", "");
            AzureSOURCE = Program.GData.getINIValue(settingsFile, "Global", "Azure", "");
            AccessSOURCE = Program.GData.getINIValue(settingsFile, "Global", "Access", "");
            //Random r = new Random();
            //int randomStationID = r.Next(0, int.MaxValue); 
            //CFGStationID = Program.GData.getINIValueInt(settingsFile, "Global", "StationID", randomStationID);

        }

        public void InitData()
        {
            dataLOV = new domainListOfValues();
            dataLOV.LoadData();

            dataPerson = new domainPerson();
            dataPerson.LoadData();

            dataOrganization = new domainOrganization();
            dataOrganization.LoadData();

            dataProject = new domainProject();
            dataProject.LoadData();

            dataActivity = new domainActivity();
            dataActivity.LoadData();

            string computerName = SystemInformation.ComputerName;
            var client = dataLOV.getClients.FirstOrDefault(c => c.ComputerName.ToUpper() == computerName.ToUpper());
            if (client != null)
            {
                CFGStationID = client.ComputerID;
            }
            else
            {
                CFGStationID = dataLOV.getClients.Max(c => c.ComputerID)+1;
                var clnt = new modelClient(computerName,CFGStationID);
                dataLOV.Insert(clnt);
            }
           
            projectCalls = new List<modelProjectCall>();
            projectCalls.Add(new modelProjectCall("2017-1", new DateTime(2017, 5, 1)));
            projectCalls.Add(new modelProjectCall("2017-2", new DateTime(2017, 8, 1)));
            projectCalls.Add(new modelProjectCall("2017-3", new DateTime(2018, 1, 1)));
            projectCalls.Add(new modelProjectCall("2018-1", new DateTime(2018, 5, 1)));
            projectCalls.Add(new modelProjectCall("2018-2", new DateTime(2018, 8, 1)));
            projectCalls.Add(new modelProjectCall("2018-3", new DateTime(2019, 1, 1)));
            projectCalls.Add(new modelProjectCall("2019-1", new DateTime(2019, 5, 1)));
            projectCalls.Add(new modelProjectCall("2019-2", new DateTime(2019, 8, 1)));
        }

        private long last_msec = 0;
        public long LongID()
        {            
            long msec = (long)(DateTime.Now - new DateTime(2018, 1, 1)).TotalMilliseconds;
            if (last_msec == msec) msec = last_msec + 1;
            last_msec = msec;

            long res = msec;
            res = (res << 16);
            UInt16 id = (UInt16)CFGStationID;
            res = res | (long)id;

            return res;
        }

        //private UInt32 GetNowInt()
        //{
        //    return (UInt32)(DateTime.Now - new DateTime(2018, 1, 1)).TotalSeconds;
        //}

        //private long MakeLong(UInt32 left, UInt32 right)
        //{
        //    //implicit conversion of left to a long
        //    long res = left;

        //    //shift the bits creating an empty space on the right
        //    // ex: 0x0000CFFF becomes 0xCFFF0000
        //    res = (res << 32);

        //    //combine the bits on the right with the previous value
        //    // ex: 0xCFFF0000 | 0x0000ABCD becomes 0xCFFFABCD
        //    res = res | (long)(uint)right; //uint first to prevent loss of signed bit

        //    //return the combined result
        //    return res;
        //}

        //public void fillDictionary(ref Dictionary<string,string> data, object objitem, string prefix) {
        //    string[] excludedProperties = {
        //                "ID", "Active", "CreatedDate","CreatedBy","UpdatedDate","UpdatedBy" };


        //    foreach (var prop in objitem.GetType().GetProperties())
        //    {
        //        if (!excludedProperties.Contains(prop.Name))
        //        {
        //            string propvalue = prop.GetValue(objitem, null)==null? "" : prop.GetValue(objitem, null).ToString();
        //            data.Add("@" + prefix + "-" + prop.Name, propvalue);
        //        }                    
        //    }            
        //}

        public IDatabase GetDB()
        {
            switch (CFG_DB_USE)
            {
                case 0:
                    return GetAccessDB();
                case 1:
                    return GetSQLDB();
                case 2:
                    return GetAzureDB();
                default:
                    return GetAccessDB();
            }
        }

        public IDatabase ChooseDB(bool? overideLocal = null)
        {
            if (overideLocal == null)
            {
                if (CFG_DB_USE == 0)
                    return Program.GData.GetAccessDB();
                if (CFG_DB_USE == 1)
                    return Program.GData.GetSQLDB();
                if(CFG_DB_USE == 2)
                    return Program.GData.GetAzureDB();
            }                
            if (overideLocal == true)
            {
                return Program.GData.GetAccessDB();
            }

            if (CFG_DB_USE == 0)
                return Program.GData.GetAccessDB();
            if (CFG_DB_USE == 1)
                return Program.GData.GetSQLDB();
            else
                return Program.GData.GetAzureDB();
        }

        public IDatabase GetSQLDB()
        {
            return DatabaseConfiguration.Build()
                        .UsingConnectionString(Program.GData.SqlSOURCE)
                        .UsingProvider<SqlServerDatabaseProvider>()
                        .Create();
        }

        public IDatabase GetAzureDB()
        {
            return DatabaseConfiguration.Build()
                        .UsingConnectionString(Program.GData.AzureSOURCE)
                        .UsingProvider<SqlServerDatabaseProvider>()
                        .Create();
        }
        public IDatabase GetAccessDB()
        {
            return DatabaseConfiguration.Build()
                        .UsingConnectionString(Program.GData.AccessSOURCE)
                        .UsingProvider<MsAccessDbDatabaseProvider>()
                        .Create();
        }
    }
}
