using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erasmDB
{
    public static class ExtensionMethods
    {
        // Deep clone
        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    static class Program
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// https://stackoverflow.com/a/45620698/2390270
        /// Compare a source and target datatables and return the row that are the same, different, added, and removed
        /// </summary>
        /// <param name="dtOld">DataTable to compare</param>
        /// <param name="dtNew">DataTable to compare to dtOld</param>
        /// <param name="dtSame">DataTable that would give you the common rows in both</param>
        /// <param name="dtDifferences">DataTable that would give you the difference</param>
        /// <param name="dtAdded">DataTable that would give you the rows added going from dtOld to dtNew</param>
        /// <param name="dtRemoved">DataTable that would give you the rows removed going from dtOld to dtNew</param>
        public static void GetTableDiff(DataTable dtOld, DataTable dtNew, ref DataTable dtSame, ref DataTable dtDifferences, ref DataTable dtAdded, ref DataTable dtRemoved)
        {
            try
            {
                dtAdded = dtOld.Clone();
                dtAdded.Clear();
                dtRemoved = dtOld.Clone();
                dtRemoved.Clear();
                dtSame = dtOld.Clone();
                dtSame.Clear();
                if (dtNew.Rows.Count > 0) dtDifferences.Merge(dtNew.AsEnumerable().Except(dtOld.AsEnumerable(), DataRowComparer.Default).CopyToDataTable<DataRow>());
                if (dtOld.Rows.Count > 0) dtDifferences.Merge(dtOld.AsEnumerable().Except(dtNew.AsEnumerable(), DataRowComparer.Default).CopyToDataTable<DataRow>());                
                    
                if (dtOld.Rows.Count > 0 && dtNew.Rows.Count > 0)
                {
                    var data = dtOld.AsEnumerable().Intersect(dtNew.AsEnumerable(), DataRowComparer.Default);
                    if(data.Count()>0)
                        dtSame = data.CopyToDataTable<DataRow>();
                }
                    
                foreach (DataRow row in dtDifferences.Rows)
                {
                    if (dtOld.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray))
                        && !dtNew.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray)))
                    {
                        dtRemoved.Rows.Add(row.ItemArray);
                    }
                    else if (dtNew.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray))
                        && !dtOld.AsEnumerable().Any(r => Enumerable.SequenceEqual(r.ItemArray, row.ItemArray)))
                    {
                        dtAdded.Rows.Add(row.ItemArray);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Boolean IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true; // or throw an exception
            return !source.Any();
        }

        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> s, Func<T, U> f)
        {
            foreach (var item in s)
                yield return f(item);
        }

        public static void ForEach<T>(this IEnumerable<T> pEnumerable, Action<T> pAction)
        {
            foreach (var item in pEnumerable)
                pAction(item);
        }

        public static bool Compare<T>(T Object1, T object2)
        {
            //Get the type of the object
            Type type = typeof(T);

            //return false if any of the object is false
            if (object.Equals(Object1, default(T)) || object.Equals(object2, default(T)))
                return false;

            //Loop through each properties inside class and get values for the property from both the objects and compare
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "ExtensionData")
                {
                    string Object1Value = string.Empty;
                    string Object2Value = string.Empty;
                    if (type.GetProperty(property.Name).GetValue(Object1, null) != null)
                        Object1Value = type.GetProperty(property.Name).GetValue(Object1, null).ToString();
                    if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                        Object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                    if (Object1Value.Trim() != Object2Value.Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static gdata GData;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string configFile = Application.StartupPath + "\\config.ini";

            GData = new gdata();
            Program.GData.CFGFolderLocal = Application.StartupPath;

            GData.InitParams(configFile);

            Program.GData.CFGisAdmin = false;
            if (args.Count() > 0)
            {
                if (args.Count(c => c.ToUpper().Contains("ADMIN")) > 0)
                {
                    Program.GData.CFGisAdmin = true;
                }

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new formMain());
            Application.Run(new formStart());
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            string logMessage = FlattenException(e.Exception);
            LogData(logMessage);
        }

        public static string FlattenException(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(DateTime.Now.ToString() + " : ---------------------------------------------------------------");
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);
                stringBuilder.AppendLine(exception.Source);
                //stringBuilder.AppendLine(exception.TargetSite.Name);

                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }

        public static void FlattenExceptionInfo(string info, string data = "")
        {
            var stringBuilder = new StringBuilder();


            stringBuilder.AppendLine(DateTime.Now.ToString() + " : ---------------------------------------------------------------");
            stringBuilder.AppendLine(info);
            if (data != "") stringBuilder.AppendLine(data);

            LogData(stringBuilder.ToString());

        }

        static public void LogData(string logmsg)
        {
            string logFileName = Program.GData.CFGFolderLocal + "\\AppLog.txt";
            System.IO.File.AppendAllText(logFileName, logmsg);
        }

        public static bool ShowMessageBox(string info, bool ShowYesNo = true, string YesButtonText = "Áno", string NoButtonText = "Nie", bool ShowInLowerLeftCorner = false, int AutoCloseInterval = -1)
        {
            formMessageBox frmmsgbox = new formMessageBox(info, ShowYesNo, false, YesButtonText, NoButtonText, "", AutoCloseInterval);
            frmmsgbox.TopMost = true;
            //if (ShowInLowerLeftCorner)
            //{
            //    frmmsgbox.StartPosition = FormStartPosition.Manual;
            //    frmmsgbox.Location = new Point(Program.termform.Left, Program.termform.Top + Program.termform.Height - frmmsgbox.Height - 20);
            //}
            frmmsgbox.ShowDialog();
            return frmmsgbox.returnValue;
        }

        public static string ShowInputBox(string info, string defaultText)
        {
            formMessageBox frmmsgbox = new formMessageBox(info, false, true, "", "", defaultText, -1);
            frmmsgbox.TopMost = true;
            frmmsgbox.ShowDialog();
            return frmmsgbox.returnText;
        }

        public static string CurrentVersion
        {
            get
            {
                var ver = Assembly.GetExecutingAssembly().GetName().Version;
                DateTime dt = new DateTime(2000, 1, 1).AddDays(ver.Build).AddSeconds(ver.Revision * 2);

                string den = "0";
                if (dt.Day < 10)
                    den = dt.Day.ToString();
                else
                {
                    int d = (int)'A' + dt.Day - 10;
                    den = new string((char)d, 1);

                }
                //return ver.Major + "." + ver.Minor + " / " + (dt.Year - 2010).ToString("X") + dt.Month.ToString("X") +
                //       den + "-" + dt.Hour.ToString("00") + (dt.Minute / 10).ToString();

                return ver.Major + "." + ver.Minor + " / " + dt.ToString("yyyyMMddHHmm");

                //return ApplicationDeployment.IsNetworkDeployed
                //       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                //       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static int SelectPerson()
        {
            int ID = -1;
            formSelect select = new formSelect("PERSON:");

            var dataArray = from person in Program.GData.dataPerson.getPersons
                            select new
                            {
                                person.ID,
                                person.LastName,
                                person.FirstName,
                                person.Telephone,
                                person.Email,
                                person.Active
                            };
            if (dataArray.IsEmpty())
                return -1;

            SortableBindingList<Object> dataSortable = new SortableBindingList<Object>(dataArray.ToArray());

            select.grid.DataSource = dataSortable;
            select.grid.Columns["ID"].Visible = false;
            select.grid.Columns["Active"].Visible = false;

            select.grid.Columns["LastName"].Width = 250;
            select.grid.Columns["FirstName"].Width = 180;
            select.grid.Columns["Telephone"].Width = 180;
            select.grid.Columns["Email"].Width = 180;

            select.ShowDialog();

            int rowIndex = select.SelectedRow;
            if (rowIndex != -1)
            {
                ID = int.Parse(select.grid.Rows[rowIndex].Cells["ID"].Value.ToString());
            }

            return ID;
        }

        public static List<long> SelectOrganization()
        {
            formSelectOrganization select = new formSelectOrganization("ORGANIZATION:");
            select.ShowDialog();
            return select.SelectedRows;
        }

        public static int SelectCountry()
        {
            int ID = -1;
            formSelect select = new formSelect("COUNTRY:");

            var dataArray = from countries in Program.GData.dataLOV.getCountries
                            select new
                            {
                                countries.ID,
                                countries.Country,
                                countries.Code,
                                countries.Active
                            };
            if (dataArray.IsEmpty())
                return -1;

            SortableBindingList<Object> dataSortable = new SortableBindingList<Object>(dataArray.ToArray());

            select.grid.DataSource = dataSortable;
            select.grid.Columns["ID"].Visible = false;
            select.grid.Columns["Active"].Visible = false;

            select.grid.Columns["Country"].Width = 750;
            select.grid.Columns["Code"].Width = 100;

            select.ShowDialog();

            int rowIndex = select.SelectedRow;
            if (rowIndex != -1)
            {
                ID = int.Parse(select.grid.Rows[rowIndex].Cells["ID"].Value.ToString());
            }

            return ID;
        }
    }
}
