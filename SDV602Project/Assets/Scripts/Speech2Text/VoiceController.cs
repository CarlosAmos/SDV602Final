using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    public GameObject btnTurnMicOn;
    

    //Used to set the language for the text on phone
    const string LANG_CODE = "en-US";

    [SerializeField]    

    Text lblSpeechToText;
    


    private void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
    SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        CheckPermission();
    }

//Used to check if the microphone permissions is on
    void CheckPermission()
    {
#if UNITY_ANDROID
    if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)) {
        Permission.RequestUserPermission(Permission.Microphone);
    }
#endif
    }

    #region Speech to Text
    //Used to check if recording is on or off
    void Update()
    {
        if(btnTurnMicOn.activeInHierarchy == false)
        {
            StartListening();

        }
        else
        {
            StopListening();
        }
    }

    //Used for when the mic starts listening
    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    //used for when user wants to stop mic from listening
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    //Used for the result of the speech
    void OnFinalSpeechResult(string result)
    {
        lblSpeechToText.text = result;
        Debug.Log("Final Speech");
        
    }

    //used for the result of the speech //Sometimes android phones will use this
    void OnPartialSpeechResult(string result)
    {
        lblSpeechToText.text = result;
        Debug.Log("Partial");
    }

#endregion

    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }

}
