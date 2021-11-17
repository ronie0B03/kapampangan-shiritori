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
    private string levelSelection, playerName;
    private int gameTimeSelection, bonusCounter, score = 0, aiScore = 0;

    private string currentWord;
    private int currentWordLength;
    private int easyCounter = 0; //Use this to check if the word starts with the end letter of the current word

    // Start is called before the first frame update
    void Start()
    {
        levelSelection = PlayerPrefs.GetString("LevelSelection");
        gameTimeSelection = PlayerPrefs.GetInt("GameTimeSelection");
        playerName = PlayerPrefs.GetString("PlayerName");

    }

    // Update is called once per frame
    void Update()
    {
        //Check if text is empty
        if(wordText.text.ToString() == ""){
            checkWorkButton.interactable = false;
        }
        else{
            if(easyCounter > 0){
            //Check if current Word not match with the text input last letter
            if(wordText.text.ToString()[0] != currentWord[currentWordLength]){
                checkWorkButton.interactable = false;
            }
            else{
                checkWorkButton.interactable = true;
                }
            }
            else{
                checkWorkButton.interactable = true;
            }
        }

    }

    public void CheckWord(){
        string _wordText;
        _wordText = wordText.text.ToString();
        _wordText.ToLower();
        if(levelSelection == "Easy"){
            if(easyLevel.Contains(_wordText))
            {
                easyLevel = easyLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(1, _wordText);
                AIChooseLevel();
            }
            else if(mediumLevel.Contains(_wordText)){
                mediumLevel = mediumLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(2, _wordText);
                AIChooseLevel();
            }
            else if(hardLevel.Contains(_wordText)){
                hardLevel = hardLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(3, _wordText);
                AIChooseLevel();
            }
            else{
                // PlayerPrefs.SetInt("isShake", 1);
                errorText.text = $"{errorText.text}\n\nNo word found in the list! Please try again.";
            }
            
        }
        easyCounter++;
    }

    //Add Method for Dry approach
    public void ScoreWord(int bonusCounter, string _wordText){
        int wordLength = _wordText.Length;
        score = (wordLength * bonusCounter)+score;
        scoreText.text = $"Score: {score.ToString()}";
        errorText.text = $"{errorText.text}\n\n {playerName}: {_wordText}";
        currentWord = _wordText;
    }

    public void AIChooseLevel(){
        int listLength, i;

        if(levelSelection == "Easy"){
            listLength = easyLevel.Length;
            listLength -=1; 
            
            currentWordLength = currentWord.Length;
            currentWordLength -=1;
            char _lastCharacter = currentWord[currentWordLength];
            Debug.Log(easyLevel.Length);
            List<string> newEasyLevel = new List<string>();
            for(i = 0; i<easyLevel.Length; i++){
                string word = easyLevel[i];
                if(word[0] == _lastCharacter){
                    newEasyLevel.Add(word);
                }
            }

            string[] arrayEasyLevel = newEasyLevel.ToArray();
            if(arrayEasyLevel.Length == 0){
                errorText.text = $"{errorText.text}\n\n No more words! You win!";
            }
            else{
                i = Random.Range(0, arrayEasyLevel.Length);
                string aiWord = arrayEasyLevel[i];
                easyLevel = easyLevel.Where(val => val != aiWord).ToArray();

                bonusCounter = 1;
                int wordLength = aiWord.Length;
                aiScore = (wordLength * bonusCounter)+aiScore;
                aiScoreText.text = $"AI Score: {aiScore.ToString()}";
                currentWord = aiWord;
                errorText.text = $"{errorText.text}\n\n AI: {aiWord}";
                currentWordLength = currentWord.Length;
                currentWordLength -=1;
            }
        }
    }
}
