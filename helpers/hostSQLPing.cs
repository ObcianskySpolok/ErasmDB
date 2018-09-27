using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Timers;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace erasmDB
{
    class hostSQLPing
    {
        public bool DeviceStatus { get; set; }
        private string connString;

        private Timer timer;
        private int _timeout;
        private SqlConnection conSQL;

        public hostSQLPing(string constr, int timeout)
        {
            this.connString = constr;
            this._timeout = timeout;

            this.DeviceStatus = false;
        }

        public void ThreadStart()
        {
            timer = new Timer(_timeout);
            timer.Elapsed += new ElapsedEventHandler(timer_Interval);
            timer.Enabled = true; // Enable it
        }

        void timer_Interval(object sender, ElapsedEventArgs e)
        {
            CheckStatus();
        }

        private void CheckStatus()
        {
            conSQL = new SqlConnection(connString);
            try
            {
                conSQL.Open();
                DeviceStatus = true;
                conSQL.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                DeviceStatus = false;
            }
        }
    }
}
