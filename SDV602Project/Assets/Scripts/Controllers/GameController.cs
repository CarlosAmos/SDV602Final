using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public GameObject canvas;
    public GameObject canvasMiniGame;
    public GameObject canvasLeaderboard;
    public GameObject WallHolder;
    public GameObject ToMiniGame;
    public Text MinigameScore;
    public Text MinigameStatus;
    public Text Status;
    public GameObject btnStartMini;
    public Text Score;
    public InputAction[] inputActions;

    [HideInInspector] public AreaNavigation areaNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInArea = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;


    List<string> actionLog = new List<string>();

    void Awake ()
    {
        ToMiniGame.SetActive(false);
        canvasMiniGame.SetActive(false);
        canvasLeaderboard.SetActive(false);
        interactableItems = GetComponent<InteractableItems>();
        areaNavigation = GetComponent<AreaNavigation>();
    }      

    void Start()
    {
        //x`LoadExistGame();
        DisplayAreaText();
        DisplayLoggedText();
        
    }

    //Display Text
    #region Display Text
    //Used to display the text the user has entered
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    //Used to display the text for the story
    public void DisplayAreaText()
    {
        ClearCollectionsForNewArea();

        UnpackArea();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInArea.ToArray());

        string combindedText = areaNavigation.currentArea.description + "\n";

        LogStringWithReturn(combindedText);
    }

    void UnpackArea()
    {
        areaNavigation.UnpackExitsInArea();
        PrepareObjectsToTakeOrExamine(areaNavigation.currentArea);
    }

    void PrepareObjectsToTakeOrExamine(Areas currentArea)
    {
        for (int i = 0; i < currentArea.interactableObjectsInArea.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentArea, i);
            if(descriptionNotInInventory != null)
            {
                interactionDescriptionsInArea.Add(descriptionNotInInventory);
            }
        }
    }

    void ClearCollectionsForNewArea()
    {
        interactionDescriptionsInArea.Clear();
        areaNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    #endregion

    //Loadgame code
    #region Loadgame
    public Areas currentArea;

    
    public void LoadExistGame()
    {
        switch (GameModel.CheckLocation(GameModel.currentPlayer.ID))
        {
            case GameModel.CharacterMde.Exists:
                currentArea.areaName = GameModel.currentCharacter.Location;
                break;
            case GameModel.CharacterMde.NotExists:
                
                break;
            case GameModel.CharacterMde.AllBad:
                break;
        }
    }

    #endregion

    #region GameOver

    #endregion

    #region ToPuzzle
   

    public void HideCanvas()
    {
        canvas.SetActive(false);
        canvasMiniGame.SetActive(true);

    }

    public void ShowCanvas()
    {

            canvas.SetActive(true);

    }


    public Text DisplayAreaName;
    public Text btnMenu;

    public void PuzzleTrigger()
    {
        if (DisplayAreaName.text == "1.6UsePhone")
        {
            ToMiniGame.SetActive(true);
        }
        else
        {
            ToMiniGame.SetActive(false);
        }
    }

    public void ChangeToAndFromPuzzle()
    {
        HideCanvas();
    }

    //Used to start the score decliner(Score will decrease while player plays minigame)
    public void PuzzleScoreCount()
    {

        if(MinigameStatus.text == "Go!!!")
        {
            befscore = MinigameScore.text;

            aftscore = int.Parse(befscore) - 1;

            MinigameScore.text = "" + aftscore;
        }

        
    }

    //To start the minigame
    public void StartMinigame()
    {
        WallHolder.SetActive(false);
        btnStartMini.SetActive(false);
        MinigameStatus.text = "Go!!!";
    }

    //To end the minigame
    public void endMinigame()
    {
        DisplayAreaName.text = "";
        ShowCanvas();
        PuzzleTrigger();
    }
    #endregion

    #region SaveGame
    public string befscore;
    public int aftscore;

    public void UpdateLoc()
    {
        befscore = Score.text;

        aftscore = int.Parse(befscore);

        switch (GameModel.CheckLocation(GameModel.currentPlayer.ID))
        {
            case GameModel.CharacterMde.Exists:
                  GameModel.updateLocation(GameModel.currentPlayer.ID, DisplayAreaName.text, aftscore);
                break;
            case GameModel.CharacterMde.NotExists:
                GameModel.newLocation(GameModel.currentPlayer.ID, DisplayAreaName.text, aftscore);
                break;
            case GameModel.CharacterMde.AllBad:
                break;
        }
        ;
    }

    #endregion

    //Used to show and hide chat box
    #region ChatBox
    public void ShowChat()
    {
        canvas.SetActive(false);
        canvasMiniGame.SetActive(false);
        canvasLeaderboard.SetActive(true);
    }

    public void HideChat()
    {
        canvas.SetActive(true);
        canvasMiniGame.SetActive(false);
        canvasLeaderboard.SetActive(false);
    }



    #endregion
    // Update is called once per frame
    void Update()
    {
        PuzzleTrigger();
        PuzzleScoreCount();
    }
}

