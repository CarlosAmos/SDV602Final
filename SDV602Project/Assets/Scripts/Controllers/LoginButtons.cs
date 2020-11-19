using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        btnOfflineLogin.SetActive(false);
        btnOnlineLogin.SetActive(false);
        btnCancel.SetActive(false);
        btnLoadGame.SetActive(false);
        btnLogin.SetActive(true);
        btnStartGame.SetActive(true);
    }

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

    public void CancelLogin()
    {
        btnLogin.SetActive(true);
        btnOfflineLogin.SetActive(false);
        btnOnlineLogin.SetActive(false);
        btnCancel.SetActive(false);
        btnStartGame.SetActive(true);
    }
}
