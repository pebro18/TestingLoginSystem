using UnityEngine;
using UnityEngine.UI;
using PasswordSecurity;
using PHPConnection;

public class RegistratieController : MonoBehaviour
{  
    private string InlogName;
    private string Wachtwoord;
    private string CheckWW;

    public InputField InlogField;
    public InputField WWField;
    public InputField CheckWWField;

    public Text Meldingen;

    // Start is called before the first frame update
    void Start()
    {
        InlogField.onValueChanged.AddListener(delegate { InsertInlog(); });
        WWField.onValueChanged.AddListener(delegate { InsertWW(); });
        CheckWWField.onValueChanged.AddListener(delegate { InsertCheckWW(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendInfo()
    {
        if (Wachtwoord == CheckWW)
        {
            string Hashed = PasswordHasherAndSalt.PasswordHasher(Wachtwoord);

            string[] Data = { InlogName, Wachtwoord };

            PHPInteraction.SendAndRetrieveAction("insert_account", Data);
            // terug sturen naar inlog menu
        }
        else
        {
            //Melden in meldingen
        }
    }

    private void InsertInlog()
    {
        InlogName = InlogField.text;
    }
    private void InsertWW()
    {
        Wachtwoord = WWField.text;
    }
    private void InsertCheckWW()
    {
        CheckWW = CheckWWField.text;
    }
}
