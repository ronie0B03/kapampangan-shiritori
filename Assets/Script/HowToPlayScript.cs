using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    public GameObject one, two, three, nextGameObject, playNextObject;
    public Button previousBtn, nextBtn;
    int currentHelp = 1;
    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHelp == 1){
            previousBtn.interactable = false;
            nextBtn.interactable = true;
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
            nextGameObject.SetActive(true);
            playNextObject.SetActive(false);
        }
        else if(currentHelp == 2){
            previousBtn.interactable = true;
            nextBtn.interactable = true;
            one.SetActive(false);
            two.SetActive(true);
            three.SetActive(false);
            nextGameObject.SetActive(true);
            playNextObject.SetActive(false);

        }
        else if(currentHelp == 3){
            previousBtn.interactable = true;
            nextBtn.interactable = false;
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
            nextGameObject.SetActive(false);
            playNextObject.SetActive(true);
        }
    }

    //Next
    public void nextButton(){
        currentHelp++;
    }

    //Previous
    public void previousButton(){
        currentHelp--;
    }

    //Play
    public void playNow(){
        SceneManager.LoadScene("MainGame");
    }
}
