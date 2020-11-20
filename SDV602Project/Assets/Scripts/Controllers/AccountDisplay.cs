using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//used for testing //Display the account of user on a label
public class AccountDisplay : MonoBehaviour
{
    public Text Button;
    public Text Account;
    private string playerName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame // used to get the name of the player
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

    //used to change the text in the login button if user is logged in
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
