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
    class hostWWWPing
    {
        public bool DeviceStatus { get; set; }
        private string urlSite;

        private Timer timer;
        private int _timeout;
        private SqlConnection conSQL;

        public hostWWWPing(string urlsite, int timeout)
        {
            this.urlSite = urlsite;
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
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlSite);
                request.Timeout = _timeout;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    DeviceStatus = true;
                }
            }
            catch
            {
                DeviceStatus = false;
            }
        }
    }
}
