using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class SettingsController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backFromSettings(){
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }
}
