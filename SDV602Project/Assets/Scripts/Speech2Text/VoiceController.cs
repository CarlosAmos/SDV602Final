using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    public GameObject btnTurnMicOn;
    


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

    void CheckPermission()
    {
#if UNITY_ANDROID
    if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)) {
        Permission.RequestUserPermission(Permission.Microphone);
    }
#endif
    }

    #region Speech to Text

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

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        lblSpeechToText.text = result;
        Debug.Log("Final Speech");
        
    }

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
