using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager
{
    //JSON token for send JSNdrop to the network
    JSONDropService jsDrop = new JSONDropService { Token = "b17dceb4-636b-4c07-ad47-1139b1c87a91" };

    //Used for connecting to the database
    private DataService ds = new DataService("OneManStanding.db");

    public bool LoggedIn = false;
    public int playerCount = 0;

    public DataService DS
    {
        get
        {
            return ds;
        }
    }

    public PlayerManager()
    {
        DS.CreateDB(new[]
        {
            typeof(Player),
        });
    }
    //Used for handling the online login 
    #region OnlineLogin


    #region CheckPlayer
    public void onlineCheckPlayer(string pUsername)
    {
        jsDrop.Select<Player, JsnReceiver>("Username = '" + pUsername + "'", jsnPlayerExistsReceiverDel, jsnPlayerExistsReceiverDelFail);
    }

    public void jsnPlayerExistsReceiverDel(List<Player> pReceivedList)
    {
        playerCount = pReceivedList.Count();
    }

    public void jsnPlayerExistsReceiverDelFail(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
    }
    #endregion
    
    #region RegisterPlayer

    public void RegisterPlayer(string pUsername, string pPassword, int pStatus)
    {
        onlineCheckPlayer(pUsername);
            jsDrop.Store<Player, JsnReceiver>(new List<Player>
            {
                new Player{Username = pUsername, Password = pPassword, Status = pStatus}
            }, jsnRegisterReceiverDel);

        jsDrop.Select<Player, JsnReceiver>("Username = '" + pUsername + "'", jsnListReceiverDel, jsnReceiverDel);
    }

    public void jsnRegisterReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
    }

    #endregion

    #region Login

    public void Login(string pUsername, string pPassword)
    {
        jsDrop.Select<Player, JsnReceiver>($"Username = '{pUsername}' AND Password = '{pPassword}'", jsnListReceiverDel, jsnReceiverDel);
    }

    public void jsnLoginReceiverDel(List<Player> pReceivedList)
    {
        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Player lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.Username + "," + lcReceived.Password + "," + lcReceived.Status + "}");
        }
    }


    public void jsnReceiverDelLoginFail(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);

    }
    #endregion

    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);

    }

    public void jsnListReceiverDel(List<Player> pReceivedList)
    {
        

        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Player lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.Username + "," + lcReceived.Password + "," + lcReceived.Status + "}");
            //lcReceived.Username = GameModel.currentPlayer.Username;
            LoggedIn = true;
        }
    }

    #endregion


}
