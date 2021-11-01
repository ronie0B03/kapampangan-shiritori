using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class MainGameController : MonoBehaviour
{
    public string[] easyLevel = {"abak", "abe","abut","abyas"};
    public string[] mediumLevel = {"abukadu", "abugadu","abusadu","alikabuk"};
    public string[] hardLevel = {"abak", "abe","abut","abyas"};

    public Text wordText, errorText, scoreText, aiScoreText;
    public Button checkWorkButton;
    private string levelSelection;
    private int gameTimeSelection, bonusCounter, score = 0, aiScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelSelection = PlayerPrefs.GetString("LevelSelection");
        gameTimeSelection = PlayerPrefs.GetInt("GameTimeSelection");
        Debug.Log(levelSelection);
        Debug.Log(gameTimeSelection);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if text is empty
        if(wordText.text.ToString() == ""){
            checkWorkButton.interactable = false;
        }
        else{
            checkWorkButton.interactable = true;
        }
    }

    public void CheckWord(){

        string _wordText;
        _wordText = wordText.text.ToString();
        _wordText.ToLower();


        if(levelSelection == "Easy"){
            if(easyLevel.Contains(_wordText))
            {
                bonusCounter = 1;
                easyLevel = easyLevel.Where(val => val != _wordText).ToArray();
                Debug.Log(easyLevel.Length);
                int wordLength = _wordText.Length;
                score = (wordLength * bonusCounter)+score;
                scoreText.text = $"Score: {score.ToString()}";
                errorText.text = $"{errorText.text}\n\n Player: {_wordText}";
                AIChooseLevel();
            }
            else if(mediumLevel.Contains(_wordText)){
                bonusCounter = 2;
                mediumLevel = mediumLevel.Where(val => val != _wordText).ToArray();
                Debug.Log(mediumLevel.Length);
                int wordLength = _wordText.Length;
                score = (wordLength * bonusCounter)+score;
                scoreText.text = $"Score: {score.ToString()}";
                errorText.text = $"{errorText.text}\n\n Player: {_wordText}";
                AIChooseLevel();
            }
            else if(hardLevel.Contains(_wordText)){
                bonusCounter = 3;
                hardLevel = hardLevel.Where(val => val != _wordText).ToArray();
                Debug.Log(hardLevel.Length);
                int wordLength = _wordText.Length;
                score = (wordLength * bonusCounter)+score;
                scoreText.text = $"Score: {score.ToString()}";
                errorText.text = $"{errorText.text}\n\n Player: {_wordText}";
                AIChooseLevel();
            }
            else{
                // PlayerPrefs.SetInt("isShake", 1);
                errorText.text = $"{errorText.text}\n\nNo word found in the list! Please try again.";
            }
            
        }
    }

    public void AIChooseLevel(){
        int listLength, i;

        if(levelSelection == "Easy"){
            listLength = easyLevel.Length;
            listLength -=1;
            i = Random.Range(0, easyLevel.Length);
            string aiWord = easyLevel[i];
            easyLevel = easyLevel.Where(val => val != aiWord).ToArray();
            bonusCounter = 1;
            int wordLength = aiWord.Length;
            aiScore = (wordLength * bonusCounter)+aiScore;
            aiScoreText.text = $"AI Score: {aiScore.ToString()}";
            errorText.text = $"{errorText.text}\n\n AI: {aiWord}";
        }
    }
}
