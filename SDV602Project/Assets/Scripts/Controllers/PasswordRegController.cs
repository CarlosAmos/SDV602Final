using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class PasswordRegController : MonoBehaviour
{

    public InputField Playername;
    public InputField Password;
    public Text lblStatus;
    public string status;
    public string playerName;
    private int userCount = 0;

    #region OfflineLogin
    public void CheckPassword()
    {


        switch (GameModel.CheckPassword(Playername.text, Password.text))
        {
            case GameModel.PasswdMode.OK:
                SceneManager.LoadScene(1); ;
                break;
            case GameModel.PasswdMode.NeedName:
                break;
            case GameModel.PasswdMode.NeedPassword:
                break;

        }
        
    }

    public void RegisterPlayer()
    {
        GameModel.RegisterPlayer(Playername.text, Password.text);
        SceneManager.LoadScene(1);
    }


    // Used for to check login, if player exists and if password is correct
    public void Login()
    {

        status = lblStatus.text;
        playerName = Playername.text;

        switch (GameModel.CheckPlayer(Playername.text))
        {
            case GameModel.PlayerMde.NotExists:
                GameModel.RegisterPlayer(Playername.text, Password.text);
                SceneManager.LoadScene(1);
                break;
            case GameModel.PlayerMde.Exists:
                switch (GameModel.CheckPassword(Playername.text, Password.text))
                {
                    case GameModel.PasswdMode.OK:
                        SceneManager.LoadScene(1);
                        lblStatus.text = "Player Exists";

                        break;
                    case GameModel.PasswdMode.NeedName:
                        break;
                    case GameModel.PasswdMode.NeedPassword:
                        lblStatus.text = "Password incorrect";
                        break;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region OnlineLogin

    #region Register
    PlayerManager playerManager = new PlayerManager();

    //Will check to see if player exists on every value change in input textbox.
    public void PlayerExists()
    {
        playerManager.onlineCheckPlayer(Playername.text);
    }


    //Used to store the new player in database
    public void OnlineRegister()
    {
        if (playerManager.playerCount == 1)
        {
            Debug.Log("Exists");
        }
        else
        {
            playerManager.RegisterPlayer(Playername.text, Password.text, 1);
            RegisterPlayer();
        }
    }

    #endregion

    #region Login


    sceneManager scenemanager = new sceneManager();
    //Used to login player in, and if player doesn't exist, it will call the register function.
    public void OnlineLogin()
    {
        if (playerManager.playerCount == 1)
        {
            playerManager.Login(Playername.text, Password.text);
            if(playerManager.LoggedIn)
            {
                scenemanager.ToMenu();
                Login();
            }
            else
            {
                lblStatus.text = "Password incorrect";
            }
        }
        else
        {
            OnlineRegister();
        }
    }

    #endregion

    #endregion


}
