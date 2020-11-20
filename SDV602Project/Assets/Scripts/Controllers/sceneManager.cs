    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//used for controlling the scenes in the game
public class sceneManager : MonoBehaviour
{
    //This is used to change screens to the menu screen
    public void ToMenu()
    {
        SceneManager.LoadScene(1);
    }

    //This is used to change screens to the login/register screen
    public void ToOfflineLogin()
    {
        SceneManager.LoadScene(2);
    }

    //This is used to change screens to the gameplay screen
    public void ToGame()
    {
        SceneManager.LoadScene(3);
    }

    //This is used to change screens to the game selector screen
    public void SelectGame()
    {
        SceneManager.LoadScene(4);
    }

    //This is used to change screens to the game options screen
    public void ToOptions()
    {
        SceneManager.LoadScene(5);
    }

    //This is used to change screens to the game options screen
    public void ToOnlineLogin()
    {
        SceneManager.LoadScene(6);
    }

    //This is used to quit the game
    public void ExitGame()
    {

    }



}
