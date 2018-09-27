using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace erasmDB
{
    class SQLConn
    {
        private SqlConnection SQLcon;
        private SqlTransaction SQLTran;

        public SQLConn(string sqlstr)
        {
            SQLcon = new SqlConnection(sqlstr);
            SQLTran = null;
            try
            {
                SQLcon.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //public void Reconnect(){
        //    if (SQLcon.State != ConnectionState.Open) SQLcon.Open();
        //}
        public bool Reconnect()
        {
            if (SQLcon.State != ConnectionState.Open)
            {
                SQLcon.Open();
                return false;
            }
            return true;
        }


        public SqlCommand NewSQLCommand(string sqlString)
        {
            var cmd = new SqlCommand(sqlString, SQLcon);
            if (SQLTran != null)
                cmd.Transaction = SQLTran;

            return cmd;
        }

        public void BeginTrans()
        {
            SQLTran = SQLcon.BeginTransaction();
        }

        public void CommitTrans()
        {
            SQLTran.Commit();
            SQLTran = null;
        }

        public void RollbackTrans()
        {
            SQLTran.Rollback();
            SQLTran = null;
        }
    }
}
