using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountDisplay : MonoBehaviour
{
    public Text Button;
    public Text Account;
    private string playerName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AccountName();
        if (GameModel.currentPlayer.Username == null)
        {

        }
        else
        {
            Account.text = GameModel.currentPlayer != null ? "" + GameModel.currentPlayer.Username + "" : "";
        }
    }

    public void AccountName()
    {
        if(string.IsNullOrEmpty(Account.text))
        {
            Button.text = "Login";
        }
        else
        {
            Button.text = "Logout";
        }
    }

    
}
