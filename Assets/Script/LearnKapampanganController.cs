using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LearnKapampanganController : MonoBehaviour
{
    public string[] title = {};
    public string[] noun = {};
    public string[] verb = {};
    public string[] adjective = {};
    public string[] qual = { };
    public string[] pron = {};

    public Text textTitle, textNoun, textVerb, textAdjective, textQual, textPron;

    public AudioSource nextPageLKW, backButton;

    // Start is called before the first frame update
    void Start()
    {
        nextWord();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextWord(){
        nextPageLKW.Play();
        int _length = title.Length-1;
        int i = Random.Range(0, title.Length);
        textTitle.text = title[i].ToString();
        textNoun.text = noun[i].ToString();
        textVerb.text = verb[i].ToString();
        textAdjective.text = adjective[i].ToString();
        textQual.text = qual[i].ToString();
        textPron.text = pron[i].ToString();
    }

    public void back(){
        backButton.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
