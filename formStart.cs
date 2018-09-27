using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace erasmDB
{
    public partial class formStart : Form
    {

        private hostSQLPing checkSQL = null;
        private hostSQLPing checkAzure = null;

        public formStart()
        {
            InitializeComponent();

            checkSQL = new hostSQLPing(Program.GData.SqlSOURCE, 2000);
            checkAzure = new hostSQLPing(Program.GData.AzureSOURCE, 2000);

            if (Program.GData.AccessSOURCE == "")
                ibuttonLocal.Visible = false;
            else
            {
                CheckOK(ibuttonLocal, false);
            }

            if (Program.GData.SqlSOURCE == "")
                ibuttonStdSQL.Visible = false;
            else
            {
                CheckOK(ibuttonStdSQL, false);
                Thread thrdSQLping = new Thread(new ThreadStart(checkSQL.ThreadStart));
                thrdSQLping.Name = "SQL check";
                thrdSQLping.Start();
            }

            if (Program.GData.AzureSOURCE == "")
                ibuttonAzure.Visible = false;
            else
            {
                CheckOK(ibuttonAzure, false);
                Thread thrdAzureping = new Thread(new ThreadStart(checkAzure.ThreadStart));
                thrdAzureping.Name = "Azure check";
                thrdAzureping.Start();
            }

            timerRefresh.Interval = 1000;
            timerRefresh.Start();
        }

        private void CheckOK(IconButton btn, bool status)
        {
            if (status)
            {
                btn.Enabled = true;
                btn.BackColor = Color.White;
                btn.ActiveColor = Color.DarkGreen;
                btn.InActiveColor = Color.Green;
            }
            else
            {
                btn.Enabled = false;
                btn.BackColor = Color.WhiteSmoke;
                btn.ActiveColor = Color.DarkGray;
                btn.InActiveColor = Color.DarkGray;
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            CheckOK(ibuttonLocal, true);
            if (checkSQL.DeviceStatus)
                CheckOK(ibuttonStdSQL, true);
            else
                CheckOK(ibuttonStdSQL, false);

            if (checkAzure.DeviceStatus)
                CheckOK(ibuttonAzure, true);
            else
                CheckOK(ibuttonAzure, false);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ibuttonLocal_Click(object sender, EventArgs e)
        {
            StartApp(0);
        }

        private void StartApp(int use_db)
        {
            Program.GData.CFG_DB_USE = use_db;
            Program.GData.InitData();

            var frm = new formMain();
            frm.Show();

            this.Hide();
        }

        private void ibuttonStdSQL_Click(object sender, EventArgs e)
        {
            StartApp(1);
        }

        private void ibuttonAzure_Click(object sender, EventArgs e)
        {
            StartApp(2);
        }
    }

}
