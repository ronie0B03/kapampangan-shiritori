using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAndTimeSelection : MonoBehaviour
{
    public string levelSelection;
    public int gameTimeSelection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelection(){
        PlayerPrefs.SetString("LevelSelection",levelSelection);
    }
    
    public void GameTimeSelection(){
        PlayerPrefs.SetInt("GameTimeSelection",gameTimeSelection);
    }
}
