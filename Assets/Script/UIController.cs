using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject mainMenuScreen, menuOptionsScreen, quitScreen;
    // Start is called before the first frame update
    void Start()
    {
        HideAllScreen();
        mainMenuScreen.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuScreen()
    {
        HideAllScreen();
        menuOptionsScreen.SetActive(true);
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
    }
}
