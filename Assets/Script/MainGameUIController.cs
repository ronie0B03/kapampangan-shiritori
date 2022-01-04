using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainGameUIController : MonoBehaviour
{   
    public GameObject quitPanel;

    public AudioSource clickSound;

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
        clickSound.Play();
        quitPanel.SetActive(true);
    }

    //close Panel
    public void cancelInitiateQuit(){
        clickSound.Play();
         quitPanel.SetActive(false);
    }

    //Go back to menu
    public void goBackMenu(){
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
