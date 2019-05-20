using UnityEngine;
using UnityEngine.UI;
using PHPConnection;


public class LoginController : MonoBehaviour
{
    private string LoginName;
    private string Wachtwoord;

    public InputField InlogField;
    public InputField WWField;

    public bool Succes;
    public GameObject[] fieldObject;
    public InputField[] field;

    public Text Meldingen;
    // Start is called before the first frame update
    void Start()
    {
        InlogField.onValueChanged.AddListener(delegate { InsertInlog(); });
        WWField.onValueChanged.AddListener(delegate { InsertWW(); });
        //fieldObject = GameObject.FindGameObjectsWithTag("LoginFields");

        for (int i = 0; i < fieldObject.Length; i++)
        {
            field[i] = fieldObject[i].GetComponent<InputField>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            for (int i = 0; i < field.Length ; i++)
            {
                field[i].ActivateInputField();
            } 
        }        
    }

    public void LoginCheck()
    {
        string[] Data = { LoginName, Wachtwoord };

        if (!string.IsNullOrEmpty(PHPInteraction.SendAndRetrieveAction("check_account", Data)))
        {
            Succes = true;
        }
        else
        {
            // meldingen fout WW
        }
    }

    private void InsertInlog()
    {
        LoginName = InlogField.text;
    }
    private void InsertWW()
    {
        Wachtwoord = WWField.text;
    }

}
