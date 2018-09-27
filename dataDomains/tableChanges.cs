using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    public class tableChanges<T> where T : modelData
    {
        public long[] commonIDs = new long[] { };
        public long[] newSQLIDs = new long[] { };
        public long[] newLocalIDs = new long[] { };
        public long[] changedIDs = new long[] { };

        IEnumerable<T> dataSQL;
        IEnumerable<T> dataLocal;
        public tableChanges(IEnumerable<T> dSQL, IEnumerable<T> dLocal)
        {
            dataSQL = dSQL;
            dataLocal = dLocal;

            CheckData();
        }

        private void CheckData() 
        {
            // check projects
            CheckDataIDs(
                dataSQL.Select(c => c.ID).ToArray(),
                dataLocal.Select(c => c.ID).ToArray(),
                ref commonIDs,
                ref newSQLIDs,
                ref newLocalIDs
                );

            var enumSQLchanges = from prjs in dataSQL
                                 join projids in commonIDs on prjs.ID equals projids
                                 orderby prjs.ID
                                 select prjs;

            var enumLocalChanges = from prjs in dataLocal
                                   join projids in commonIDs on prjs.ID equals projids
                                   orderby prjs.ID
                                   select prjs;

            changedIDs = CompareRows(enumSQLchanges.ToDataTable(), enumLocalChanges.ToDataTable());
        }

        private void CheckDataIDs(long[] fromSQL, long[] fromLocal, ref long[] common, ref long[] newSQL, ref long[] newLocal)
        {
            common = fromSQL.Intersect(fromLocal).ToArray();
            newSQL = fromSQL.Except(common).ToArray();
            newLocal = fromLocal.Except(common).ToArray();
        }

        private long[] CompareRows(DataTable table1, DataTable table2)
        {
            List<long> changedIDs = new List<long>();
            foreach (DataRow row1 in table1.Rows)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    if((long)row2["ID"] == (long)row1["ID"])
                    {
                        var array1 = row1.ItemArray;
                        var array2 = row2.ItemArray;

                        for(int idx =0; idx< array1.Length; idx++)
                        {
                            if(array1[idx].GetType() == typeof(System.DateTime))
                            {
                                var d1 = (DateTime)array1[idx];
                                var d2 = (DateTime)array2[idx];
                                var dif = d1 - d2;
                                if (dif.TotalSeconds>1)
                                {
                                    changedIDs.Add((long)row1["ID"]);
                                    break;
                                }

                            }
                            else
                                if (!array1[idx].Equals(array2[idx])){
                                    changedIDs.Add((long)row1["ID"]);
                                    break;
                                }
                        }

                    }
                }
            }

            return changedIDs.Distinct().ToArray();
        }

        public List<ChangesInfo> GetChangedData
        {
            get {
                var changeInfos = new List<ChangesInfo>();
                foreach(long changedid in changedIDs)
                {
                    T objacc = dataLocal.First(c => c.ID == changedid);
                    T objsql = dataSQL.First(c => c.ID == changedid);
                    var inf = new ChangesInfo(changedid, typeof(T).Name,objacc.GetTitleInfo(),objsql.GetTitleInfo(),objacc.UpdatedDate, objsql.UpdatedDate, objacc.UpdatedDate > objsql.UpdatedDate,false,false);
                    changeInfos.Add(inf);
                }
                return changeInfos;
            }
        }

        public List<ChangesInfo> GetNewData
        {
            get
            {
                var changeInfos = new List<ChangesInfo>();
                foreach (long changedid in newLocalIDs)
                {
                    T objacc = dataLocal.First(c => c.ID == changedid);
                    var inf = new ChangesInfo(changedid, typeof(T).Name, objacc.GetTitleInfo(), "", objacc.UpdatedDate, new DateTime(2018, 1, 1), false, true, false);
                    changeInfos.Add(inf);
                }
                foreach (long changedid in newSQLIDs)
                {
                    T objsql = dataSQL.First(c => c.ID == changedid);
                    var inf = new ChangesInfo(changedid, typeof(T).Name, "", objsql.GetTitleInfo(), new DateTime(2018, 1, 1), objsql.UpdatedDate, false, false, true);
                    changeInfos.Add(inf);
                }

                return changeInfos;
            }
        }
    }
}
