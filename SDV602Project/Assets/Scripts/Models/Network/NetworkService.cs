using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Not in use
public class NetworkService : MonoBehaviour
{
    JSONDropService jsDrop = new JSONDropService { Token = "b17dceb4-636b-4c07-ad47-1139b1c87a91" };

    void Start()
    {
        #region Test jsn drop

        // Store player records
        jsDrop.Store<Player, JsnReceiver>(new List<Player>
        {
            new Player{Username = "Player2", Password ="Test"}

         }, jsnReceiverDel);

        jsDrop.All<Player, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);
        jsDrop.Select<Player, JsnReceiver>("Player = Amdin", jsnListReceiverDel, jsnReceiverDel);

        #endregion
    }


    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public void jsnListReceiverDel(List<Player> pReceivedList)
    {
        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Player lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.Username + "," + lcReceived.Password + "}");
        }// for

        // To do: produce an appropriate response
    }
}
