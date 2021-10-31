using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{

    public GameObject mainMenuScreen, menuOptionsScreen, quitScreen, playerNameScreen, levelSelectionScreen;
    public Text playerName;
    public Button confirmPlayerName, easyButton, mediumButton, hardButton, _60Button, _90Button, _120Button, proceedGameButton;

    private int levelSelectCounter = 0, gameTimeSelectCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        HideAllScreen();
        mainMenuScreen.SetActive(true);   
        playerName.text  = "";
    }

    // Update is called once per frame
    void Update()
    {        
        //Name Enter
        if(playerName.text.ToString() == ""){
            confirmPlayerName.interactable = false;
        }
        else{
            confirmPlayerName.interactable = true;
        }

        if(levelSelectCounter == 1 && gameTimeSelectCounter == 1){
           proceedGameButton.interactable = true; 
        }
        else{
           proceedGameButton.interactable = false;
        }
    }

    public void MainMenuScreen()
    {
        HideAllScreen();
        menuOptionsScreen.SetActive(true);
    }

    public void SinglePlayerScreen(){
        HideAllScreen();
        playerNameScreen.SetActive(true);
    }

    public void ConfirmPlayerName(){
        string _playerName = playerName.text.ToString();
        PlayerPrefs.SetString("PlayerName",_playerName);
        HideAllScreen();
        levelSelectionScreen.SetActive(true);
    }

    public void InitiateQuitScreen(){
        HideAllScreen();
        quitScreen.SetActive(true);
    }

    public void DeInitiateQuitScreen(){
        HideAllScreen();
        menuOptionsScreen.SetActive(true);
    }    

    public void QuitApplication(){
        Application.Quit();
    }

    void HideAllScreen(){
        mainMenuScreen.SetActive(false);
        menuOptionsScreen.SetActive(false);
        quitScreen.SetActive(false);
        playerNameScreen.SetActive(false);
        levelSelectionScreen.SetActive(false);
    }

    //Level Selection
    public void SelectLevel(){
        Debug.Log(PlayerPrefs.GetString("LevelSelection"));
        levelSelectCounter = 1;
        easyButton.interactable = true;
        mediumButton.interactable = true;
        hardButton.interactable = true;
        if(PlayerPrefs.GetString("LevelSelection") == "Easy"){
            easyButton.interactable = false;
        }
        else if(PlayerPrefs.GetString("LevelSelection") == "Medium"){
            mediumButton.interactable = false;
        }
        else{
            hardButton.interactable = false;
        }
    }

    //Set Game Time
    public void SetGameTime(){
        Debug.Log(PlayerPrefs.GetInt("GameTimeSelection"));
        gameTimeSelectCounter = 1;
        _60Button.interactable = true;
        _90Button.interactable = true;
        _120Button.interactable = true;

        if(PlayerPrefs.GetInt("GameTimeSelection") == 60){
            _60Button.interactable = false;
        }
        else if(PlayerPrefs.GetInt("GameTimeSelection") == 90){
            _90Button.interactable = false;
        }
        else{
            _120Button.interactable = false;
        }
    }

    //Proceed Game
}
