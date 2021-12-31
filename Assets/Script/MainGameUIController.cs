using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainGameUIController : MonoBehaviour
{   
    public GameObject quitPanel;
    // Start is called before the first frame update
    void Start()
    {
        quitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Initiate Panel
    public void initiateQuit(){
        quitPanel.SetActive(true);
    }

    //close Panel
    public void cancelInitiateQuit(){
         quitPanel.SetActive(false);
    }

    //Go back to menu
    public void goBackMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
