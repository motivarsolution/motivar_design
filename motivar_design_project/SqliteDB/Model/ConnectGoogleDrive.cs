using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqliteDB.Model
{
    public static class ConnectGoogleDrive
    {
        public static void Connect()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile};
            var clientId = "[Client ID]"; 
            var clientSecret = "xxx"; 
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets {
                ClientId = clientId,
                ClientSecret = clientSecret}, 
                scopes, 
                Environment.UserName, 
                CancellationToken.None, 
                new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;


        }

               

    }
}
