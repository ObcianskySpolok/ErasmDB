using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erasmDB
{
    public class ChangesInfo
    {
        public long ID;
        public string Abbrev;
        public string DescriptionAccess;
        public string DescriptionSQL;
        public DateTime TimeChangedAccess;
        public DateTime TimeChangeSQL;
        public bool syncAccessToSQL;
        public bool newAccess;
        public bool newSQL;

        public ChangesInfo(long id, string abbrev, string descAcc,string descSql, DateTime access, DateTime sql, bool synAcc2SQL, bool newacc, bool newsql)
        {
            ID = id;
            Abbrev = abbrev;
            DescriptionAccess = descAcc;
            DescriptionSQL = descSql;
            TimeChangedAccess = access;
            TimeChangeSQL = sql;
            syncAccessToSQL = synAcc2SQL;
            newAccess = newacc;
            newSQL = newsql;
        }
    }
}
