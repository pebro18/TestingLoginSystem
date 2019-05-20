using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PasswordSecurity;
using PHPConnection;
using DBConnection;

public class TestScript : MonoBehaviour
{
   
    
    string Key = "";

    [SerializeField]
    public Text Test;
    [SerializeField]
    private bool Succes = false;

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
    }

    public static void Debugging(string ex)
    {
        Debug.Log(ex);      
    }

    public void Onclick()
    {

        string passwordHass = PasswordHasherAndSalt.PasswordHasher(Test.text);
        Succes = PasswordHasherAndSalt.PasswordCompare(passwordHass, Test.text);
        //DBInteraction.SendDataLogin("Reeee", passwordHass, "itu_accounts");
        //Test.text = passwordHass;
        string[] Sending = { "657920", "" };

        //StartCoroutine(PHPInteraction.RetrieveAction("check_account", Sending));
        Debugging(PHPInteraction.SendAndRetrieveAction("check_account", Sending).ToString());
    }

    public void InsertData(string Password)
    {

        string CreateURL = "";
        
        //string testingSHit = SHA256Encryption.Encrypt(DateTimeOffset.UtcNow.ToUnixTimeSeconds() + Alteration + "/insert_account/" + "31" + "/"+ Password);
        
       // CreateURL += testingSHit;
        Debug.Log(CreateURL);
       // WWWForm form = new WWWForm();
       //// form.AddField("PasswordPost", Password);
       //
    }

    void deleteAcc(string Pass)
    {
        //Debugging(PHPInteraction.RetrieveAction());
    }
}
