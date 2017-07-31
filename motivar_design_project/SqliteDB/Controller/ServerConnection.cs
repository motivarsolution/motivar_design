using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteDB.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SqliteDB.Controller
{
    public static class ServerConnection
    {
        public static DatabaseVersionModel ServerDatabaserVersion = new DatabaseVersionModel();

        public static bool Connect()
        {
            string URL = "http://localhost/slimapp/public/database_version.php/api/dbversion/checked";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("MOTIVAR"));
            request.PreAuthenticate = true;

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string jsonString = reader.ReadToEnd();
                    List<DatabaseVersionModel> resultList = JsonConvert.DeserializeObject<List<DatabaseVersionModel>>(jsonString);
                    ServerDatabaserVersion = resultList.FirstOrDefault();
                }
                return true;
            }
            catch (WebException we)
            {
                Debug.WriteLine(we.Message.ToString());
                return false;
            }
     

        }

        public static void testCon() //Test Connect to Account Database
        {
            string URL = "http://localhost/slimapp/public/account.php/api/account/all";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            request.PreAuthenticate = true;

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    string jsonString = reader.ReadToEnd();
                    List<AccountModel> resultList = JsonConvert.DeserializeObject<List<AccountModel>>(jsonString);
                }
            }
            catch (WebException we)
            {
                Debug.WriteLine(we.Message.ToString());
            }


        }
    }
}
