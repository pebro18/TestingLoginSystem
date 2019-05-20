using System;
using UnityEngine;
using PasswordSecurity;

namespace PHPConnection
{
    public class PHPInteraction
    {
        // random number has to be the same at API site
       private protected const string Alteration = "";
        public static string SendAndRetrieveAction(string Action, string[] Data)
        {
            var UnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string DataString = string.Join("/", Data);
            WWW DataWWW = new WWW("http://jemx.nl/itapi/" + SHA256Encryption.Encrypt(UnixTime + Alteration + "/" + Action + "/" + DataString + "/"));
            while (!DataWWW.isDone)
            {
                
            }
            return DataWWW.text;
        }
    }
}
