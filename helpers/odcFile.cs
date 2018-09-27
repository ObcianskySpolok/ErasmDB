using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace erasmDB
{
    class odcFile
    {
        /// <summary> 
        /// Index from where tag begins 
        /// </summary>

        private static int sourceIndex = 0;

        /// <summary> 
        /// Index from where tag ends 
        /// </summary>

        private static int destinationIndex = 0;



        // Provide values for following patameters that will be changed in the ODC file.
        string databaseName = "<your database name>";
        string serverName = "<your server name>";
        string SSOApplicationID = "<application ID>"; string provider = "<Provider>";
        string integratedSecurity = "<integrated security>";
        string persistSecurityInfo = "<persist security info>";
        string useProcedure = "<use procedure>";
        string autoTranslate = "<auto translate>";
        string packetSize = "<packet size>";
        string workSatationID = "<workstation ID>";
        string encryptionData = "<encryption data>";
        string tagWithCollation = "<tag with column collation>";

        public void Process(string odcTemplateFilePath, string destinationFilePath, string sqlcommand)
        {
            //// You can keep the source an destination file path same if you want to 
            //// overwrite the existing file with new values.
            //string odcFilePath = @"C:ReportsConnection.odc";
            //string destinationFilePath = @"C:ReportsConnection.odc";

            string xmlConnection = GetConnectionString(odcTemplateFilePath);
            XmlDocument odcXmlConnection = new XmlDocument();
            odcXmlConnection.LoadXml(xmlConnection);
            XmlNamespaceManager nameManager = new XmlNamespaceManager(odcXmlConnection.NameTable);
            nameManager.AddNamespace("odc", odcXmlConnection.DocumentElement.NamespaceURI);
            XmlNodeList nodelistConnectionString = odcXmlConnection.SelectNodes("//odc:Connection/odc:ConnectionString", nameManager);
            XmlNodeList nodelistCommands = odcXmlConnection.SelectNodes("//odc:Connection/odc:CommandText", nameManager);

            //StringBuilder finalConnectionString = CreateNewConnectionString(databaseName, serverName, provider, integratedSecurity, persistSecurityInfo, useProcedure, autoTranslate, packetSize, workSatationID, encryptionData, tagWithCollation, nodelistConnectionString);
            //nodelistConnectionString[0].InnerText = finalConnectionString.ToString();

            nodelistCommands[1].InnerText = sqlcommand;

            //XmlNodeList nodelistSSOApplicationID = odcXmlConnection.SelectNodes("//odc:Connection/odc:SSOApplicationID", nameManager);
            //nodelistSSOApplicationID[0].InnerText = SSOApplicationID;


            SaveConnectionString(odcTemplateFilePath, destinationFilePath, odcXmlConnection.OuterXml);
        }

        /// <summary> 
        /// Finds the connection string in the ODC file 
        /// </summary>

        /// <param name="filePath">path of ODC file</param> 
        /// <returns>office data connection xml</returns>

        public static string GetConnectionString(string filePath)
        {
            string xmlConnection = string.Empty;
            System.IO.StreamReader myFile = new System.IO.StreamReader(filePath);
            string myString = myFile.ReadToEnd();
            sourceIndex = myString.IndexOf("<odc:OfficeDataConnection");
            destinationIndex = myString.IndexOf("</odc:OfficeDataConnection");
            xmlConnection = myString.Substring(sourceIndex, destinationIndex - sourceIndex + 27);
            myFile.Close();

            return xmlConnection;

        }


        /// <summary> 
        /// save the changed ODC file 
        /// </summary>

        /// <param name="filePath">path at which you want to read the ODC file</param> 
        /// <param name="newFilePath">path at which you want to save</param> 
        /// <param name="connectionString">new data connection string to be changed</param>

        public static void SaveConnectionString(string filePath, string newFilePath, string connectionString)
        {
            string xmlConnection = string.Empty;
            System.IO.StreamReader myFile = new System.IO.StreamReader(filePath);
            string myString = myFile.ReadToEnd();
            myFile.Close();
            string lessString = myString.Remove(sourceIndex, destinationIndex - sourceIndex + 27);
            myString = lessString.Insert(sourceIndex, connectionString);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(newFilePath);
            writer.Write(myString);
        }


        /// <summary> 
        /// Function to replace the old values with new one. 
        /// </summary>

        /// <param name="databaseName">database Name</param> 
        /// <param name="serverName">server Name</param> 
        /// <param name="provider">provider</param> 
        /// <param name="integratedSecurity">integrated Security</param> 
        /// <param name="persistSecurityInfo">persist Security Info</param> 
        /// <param name="useProcedure">use Procedure</param> 
        /// <param name="autoTranslate">auto Translate</param> 
        /// <param name="packetSize">packet Size</param> 
        /// <param name="workSatationID">work Satation ID</param> 
        /// <param name="encryptionData">encryption Data</param> 
        /// <param name="tagWithCollation">tag With Collation</param> 
        /// <param name="nodelistConnectionString">nodelist Connection String</param> 
        /// <returns>final connection string</returns>
        private static StringBuilder CreateNewConnectionString(string databaseName, string serverName, string provider, string integratedSecurity, string persistSecurityInfo, string useProcedure, string autoTranslate, string packetSize, string workSatationID, string encryptionData, string tagWithCollation, XmlNodeList nodelistConnectionString)
        {
            string[] connectionStringArray = nodelistConnectionString[0].InnerText.Split(';');
            StringBuilder finalConnectionString = new StringBuilder();
            foreach (string connections in connectionStringArray.ToList())
            {
                string[] splitOnEqual = connections.Split('=');
                switch (splitOnEqual[0])
                {
                    case "Initial Catalog":
                        splitOnEqual[1] = databaseName;
                        break;

                    case "Data Source":
                        splitOnEqual[1] = serverName;
                        break;

                    case "Provider":
                        splitOnEqual[1] = provider;
                        break;

                    case "Integrated Security":
                        splitOnEqual[1] = integratedSecurity;
                        break;

                    case "Persist Security Info":
                        splitOnEqual[1] = persistSecurityInfo;
                        break;

                    case "Use Procedure for Prepare":
                        splitOnEqual[1] = useProcedure;
                        break;

                    case "Auto Translate":
                        splitOnEqual[1] = autoTranslate;
                        break;

                    case "Packet Size":
                        splitOnEqual[1] = packetSize;
                        break;

                    case "Workstation ID":
                        splitOnEqual[1] = workSatationID;
                        break;

                    case "Use Encryption for Data":
                        splitOnEqual[1] = encryptionData;
                        break;

                    case "Tag with column collation when possible":
                        splitOnEqual[1] = tagWithCollation;
                        break;

                }

                finalConnectionString = finalConnectionString.Append(splitOnEqual[0]);
                finalConnectionString = finalConnectionString.Append("=");
                finalConnectionString = finalConnectionString.Append(splitOnEqual[1]);
                finalConnectionString = finalConnectionString.Append(";");

            }

            finalConnectionString = finalConnectionString.Remove((finalConnectionString.Length - 1), 1);
            return finalConnectionString;
        }
    }
}
