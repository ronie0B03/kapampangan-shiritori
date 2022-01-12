using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{

    public GameObject mainMenuScreen, menuOptionsScreen, quitScreen, playerNameScreen, levelSelectionScreen, proceedText;
    public Text playerName;
    public Button confirmPlayerName, easyButton, mediumButton, hardButton, _60Button, _90Button, _120Button, proceedGameButton;

    public AudioSource clickSound;

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
        clickSound.Play();
    }

    public void SinglePlayerScreen(){
        HideAllScreen();
        playerNameScreen.SetActive(true);
        clickSound.Play();
    }

    public void ConfirmPlayerName(){
        string _playerName = playerName.text.ToString();
        Debug.Log(_playerName);
        PlayerPrefs.SetString("PlayerName",_playerName);
        HideAllScreen();
        levelSelectionScreen.SetActive(true);
        clickSound.Play();
    }

    public void InitiateQuitScreen(){
        HideAllScreen();
        quitScreen.SetActive(true);
        clickSound.Play();
    }

    public void DeInitiateQuitScreen(){
        HideAllScreen();
        menuOptionsScreen.SetActive(true);
        clickSound.Play();
    }    

    public void QuitApplication(){
        Application.Quit();
        clickSound.Play();
    }

    void HideAllScreen(){
        mainMenuScreen.SetActive(false);
        menuOptionsScreen.SetActive(false);
        quitScreen.SetActive(false);
        playerNameScreen.SetActive(false);
        levelSelectionScreen.SetActive(false);
         proceedText.SetActive(false);
         clickSound.Play();
    }

    //Level Selection
    public void SelectLevel(){
        clickSound.Play();
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
        clickSound.Play();
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
    
    // public void backFromLevelSelection(){

    // }
    
    //Proceed Game
    public void ProceedGame(){
        clickSound.Play();
        HideAllScreen();
        proceedText.SetActive(true);
        Invoke("LoadMainGame",2f);
    }

    private void LoadMainGame(){
        clickSound.Play();
        // SceneManager.LoadScene("MainGame");
        SceneManager.LoadScene("HowToPlay");
    }

    public void ProceedLearnShitori(){
        clickSound.Play();
        HideAllScreen();
        proceedText.SetActive(true);
        Invoke("LoadLearnShitori",2f);
    }

    private void LoadLearnShitori(){
        clickSound.Play();
        SceneManager.LoadScene("LearnKapampangan");
    }

    public void goToSettings(){
        clickSound.Play();
        HideAllScreen();
        proceedText.SetActive(true);
        Invoke("LoadSettings",1f);
    }

    private void LoadSettings(){
        clickSound.Play();
        SceneManager.LoadScene("Settings");
    }

}
