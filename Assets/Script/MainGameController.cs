using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameController : MonoBehaviour
{
    public string[] easyLevel = {"abak", "abe","abut","abyas"};
    public string[] mediumLevel = {"abukadu", "abugadu","abusadu","alikabuk"};
    public string[] hardLevel = {"abak", "abe","abut","abyas"};

    public AudioSource checkWord;

    // public Text errorText, scoreText, aiScoreText;
    public TextMeshProUGUI errorText;
    public Text scoreText, aiScoreText, screenTime, difficultyText;
    public InputField wordText;
    public Button checkWorkButton;
    private string levelSelection, playerName;
    private int gameTimeSelection, bonusCounter, score = 0, aiScore = 0;
    private float gameTime;
    private string currentWord;
    private int currentWordLength;
    private int easyCounter = 0; //Use this to check if the word starts with the end letter of the current word

    // Start is called before the first frame update
    void Start()
    {
        levelSelection = PlayerPrefs.GetString("LevelSelection");
        gameTimeSelection = PlayerPrefs.GetInt("GameTimeSelection");
        playerName = PlayerPrefs.GetString("PlayerName");
        scoreText.text = $"{playerName}: 0";
        gameTime = (float)gameTimeSelection;
        // gameTime = 10f;
        difficultyText.text = levelSelection;
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

        //Check time
        if(gameTime > 0){
            gameTime -= Time.deltaTime;
            int newGameTime = (int)gameTime;
            screenTime.text = newGameTime.ToString();
        }
        else{
            int _userGameOverScore = score;
            int _aiGameOverScore = aiScore;
            if(_userGameOverScore > _aiGameOverScore){
                errorText.text = $"Game over! Time has run out! {playerName} wins!";
            }
            else if(_userGameOverScore < _aiGameOverScore){
                errorText.text = $"Game over! Time has run out! AI wins!";
            }
            else{
                errorText.text = $"Game over! Time has run out! It is a tie!";
            }
            wordText.interactable = false;
            checkWorkButton.interactable = false;
        }

    }

    public void CheckWord(){
        checkWord.Play();
        string _wordText;
        _wordText = wordText.text.ToString();
        _wordText.ToLower();
        //Easy
        if(levelSelection == "Easy"){
            if(easyLevel.Contains(_wordText))
            {
                easyLevel = easyLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(1, _wordText);
                AIChooseLevel();
                easyCounter++;
            }
            else if(mediumLevel.Contains(_wordText)){
                mediumLevel = mediumLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(2, _wordText);
                easyCounter++;
                AIChooseLevel();
            }
            else if(hardLevel.Contains(_wordText)){
                hardLevel = hardLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(3, _wordText);
                AIChooseLevel();
                easyCounter++;
            }
            else{
                errorText.text = $"{errorText.text}\nNo word found in the list! Please try again.";
            }
        }

        //Medium
        if(levelSelection == "Medium"){
            if(easyLevel.Contains(_wordText))
            {
                easyLevel = easyLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(1, _wordText);
                AIChooseLevel();
                easyCounter++;
            }            
            else if(mediumLevel.Contains(_wordText)){
                mediumLevel = mediumLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(2, _wordText);
                AIChooseLevel();
                easyCounter++;
            }
            else if(hardLevel.Contains(_wordText)){
                hardLevel = hardLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(3, _wordText);
                AIChooseLevel();
                easyCounter++;
            }
            else{
                errorText.text = $"{errorText.text}\n\nNo word found in the list! Please try again.";
            }
        }

        //Hard
        if(levelSelection == "Hard"){
            if(easyLevel.Contains(_wordText))
            {
                easyLevel = easyLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(1, _wordText);
                AIChooseLevel();
                easyCounter++;
            }            
            else if(mediumLevel.Contains(_wordText)){
                mediumLevel = mediumLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(2, _wordText);
                AIChooseLevel();
                easyCounter++;
            }            
            else if(hardLevel.Contains(_wordText)){
                hardLevel = hardLevel.Where(val => val != _wordText).ToArray();
                ScoreWord(3, _wordText);
                AIChooseLevel();
                easyCounter++;
            }
            else{
                errorText.text = $"{errorText.text}\n\nNo word found in the list! Please try again.";
            }
        }
    }

    //Add Method for Dry approach
    public void ScoreWord(int bonusCounter, string _wordText){
        checkWord.Play();
        int wordLength = _wordText.Length;
        string lastCharacter = _wordText[wordLength-1].ToString();
        int tempScore = wordLength * bonusCounter;
        score = tempScore+score;
        scoreText.text = $"{playerName}: {score.ToString()}";
        // errorText.text = $"{errorText.text}\n\n {playerName}: {_wordText}";
        errorText.text = $"{errorText.text}\n\n+{tempScore}\t {_wordText} \t{lastCharacter}";
        currentWord = _wordText;
        wordText.text = "";
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
                int tempScore = wordLength * bonusCounter;
                aiScore = tempScore + aiScore;
                aiScoreText.text = $"AI: {aiScore.ToString()}";
                currentWord = aiWord;
                currentWordLength = currentWord.Length;
                currentWordLength -=1;
                string currentCharacter = aiWord[currentWordLength].ToString();
                errorText.text = $"{errorText.text}\n+{tempScore}\t{aiWord}\t{currentCharacter}";
            }
        }

        //Medium
        if(levelSelection == "Medium"){
            listLength = mediumLevel.Length;
            listLength -=1; 
            
            currentWordLength = currentWord.Length;
            currentWordLength -=1;
            char _lastCharacter = currentWord[currentWordLength];
            Debug.Log(mediumLevel.Length);
            List<string> newMediumLevel = new List<string>();
            for(i = 0; i<mediumLevel.Length; i++){
                string word = mediumLevel[i];
                if(word[0] == _lastCharacter){
                    newMediumLevel.Add(word);
                }
            }

            string[] arrayMediumLevel = newMediumLevel.ToArray();
            if(arrayMediumLevel.Length == 0){
                errorText.text = $"{errorText.text}\n\n No more words! You win!";
            }
            else{
                i = Random.Range(0, arrayMediumLevel.Length);
                string aiWord = arrayMediumLevel[i];
                mediumLevel = mediumLevel.Where(val => val != aiWord).ToArray();

                bonusCounter = 2;
                int wordLength = aiWord.Length;
                int tempScore = wordLength * bonusCounter;
                aiScore = tempScore + aiScore;
                aiScoreText.text = $"AI: {aiScore.ToString()}";
                currentWord = aiWord;
                string currentCharacter = aiWord[currentWordLength].ToString();
                errorText.text = $"{errorText.text}\n+{tempScore}\t{aiWord}\t{currentCharacter}";
                currentWordLength = currentWord.Length;
                currentWordLength -=1;
            }
        }

        //Hard
        if(levelSelection == "Hard"){
            listLength = hardLevel.Length;
            listLength -=1; 
            
            currentWordLength = currentWord.Length;
            currentWordLength -=1;
            char _lastCharacter = currentWord[currentWordLength];
            Debug.Log(hardLevel.Length);
            List<string> newHardLevel = new List<string>();
            for(i = 0; i<hardLevel.Length; i++){
                string word = hardLevel[i];
                if(word[0] == _lastCharacter){
                    newHardLevel.Add(word);
                }
            }

            string[] arrayHardLevel = newHardLevel.ToArray();
            if(arrayHardLevel.Length == 0){
                errorText.text = $"{errorText.text}\n\n No more words! You win!";
            }
            else{
                i = Random.Range(0, arrayHardLevel.Length);
                string aiWord = arrayHardLevel[i];
                hardLevel = hardLevel.Where(val => val != aiWord).ToArray();

                bonusCounter = 3;
                int wordLength = aiWord.Length;
                int tempScore = wordLength * bonusCounter;
                aiScore = tempScore + aiScore;
                aiScoreText.text = $"AI: {aiScore.ToString()}";
                currentWord = aiWord;
                string currentCharacter = aiWord[currentWordLength].ToString();
                errorText.text = $"{errorText.text}\n+{tempScore}\t{aiWord}\t{currentCharacter}";
                currentWordLength = currentWord.Length;
                currentWordLength -=1;
            }
        }


    }
}
