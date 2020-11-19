using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    #region ChatSystem1
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;


    [SerializeField]
    List<Message> messageList = new List<Message>();
    
    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat("Admin" + ": " + chatBox.text);
                chatBox.text = "";
            }

        }
    }


    //Chat System
        public void SendMessageToChat(string text)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }

    #endregion
}

[System.Serializable]
//Used for chat system
public class Message
{
    public string text;
    public Text textObject;

}
