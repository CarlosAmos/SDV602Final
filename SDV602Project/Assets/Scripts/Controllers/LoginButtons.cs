using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used for displaying correct login buttons on menu page
public class LoginButtons : MonoBehaviour
{
    public GameObject btnOnlineLogin;
    public GameObject btnOfflineLogin;
    public GameObject btnLogin;
    public GameObject btnCancel;
    public GameObject btnStartGame;
    public GameObject btnLoadGame;
    public Text Loginbtn;
    public Text Account;


    public string Login = "Login";
    public string Logout = "Logout";

    //Hides and shows buttons on startup
    void Start()
    {
        btnOfflineLogin.SetActive(false);
        btnOnlineLogin.SetActive(false);
        btnCancel.SetActive(false);
        btnLoadGame.SetActive(false);
        btnLogin.SetActive(true);
        btnStartGame.SetActive(true);
    }

    //Hides and shows buttons if user presses login button or if it says logout
    public void ShowLoginButtons()
    {
        string btnText = Loginbtn.text;



        if(btnText == Logout)
        {
            Loginbtn.text = "Login";
            GameModel.currentPlayer.Username = "";
            btnLoadGame.SetActive(false);
        }
        else
        {
            btnLogin.SetActive(false);
            btnOfflineLogin.SetActive(true);
            btnOnlineLogin.SetActive(true);
            btnCancel.SetActive(true);
            btnStartGame.SetActive(false);
        }

    }

    //Used to check if the player has an existing game, if they do it will show the load button
    public void CheckCharacter()
    {
        switch(GameModel.CheckLocation(GameModel.currentPlayer.ID))
        {
            case GameModel.CharacterMde.Exists:
                btnLoadGame.SetActive(true);
                break;
            case GameModel.CharacterMde.NotExists:
                btnLoadGame.SetActive(false);
                break;
            case GameModel.CharacterMde.AllBad:
                btnLoadGame.SetActive(false);
                break;
        }
    }

    void Update()
    {
        CheckCharacter();
    }

    //If the user presses cancel button in menu
    public void CancelLogin()
    {
        btnLogin.SetActive(true);
        btnOfflineLogin.SetActive(false);
        btnOnlineLogin.SetActive(false);
        btnCancel.SetActive(false);
        btnStartGame.SetActive(true);
    }
}
