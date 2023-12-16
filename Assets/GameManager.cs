using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameStart = false;
    public bool gameDefeat = false;

    public GameObject playCanvas;
    public GameObject gameOverCanvas;

    public GameObject button;

    public Text text;

    public Text scoreText;
    [SerializeField] Button playBtn;

    public int score = 0;

    
     int playerSelecter;

     public GameObject gameObject;
     int countCoint =0;

     public Text winPanelTextScore;

     public GameObject winPanel;

     public Text winPanelLevelText;
     public GameObject mainMenuPanel;
     public GameObject playPanel;

     public Text mainMenuText;

     public bool isNextLevelPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        isNextLevelPlay = false;
        mainMenuPanel.SetActive(true);
        playerSelecter =  PlayerPrefs.GetInt("selectedCharater");
        if (playerSelecter == 0)
        {
            gameObject = GameObject.Find("Players/Breathing Idle1");
            gameObject.SetActive(true);
            GameObject gameObject2 =GameObject.Find("Players/untitlemixama3");
            gameObject2.SetActive(false);
        }else if(playerSelecter == 1)
        {
            gameObject = GameObject.Find("Players/untitlemixama3");
            gameObject.SetActive(true);
            GameObject gameObject2 =GameObject.Find("Players/Breathing Idle1");
            gameObject2.SetActive(false);
        }else{
            gameObject = GameObject.Find("Players/Breathing Idle1");
            gameObject.SetActive(true);
            GameObject gameObject2 =GameObject.Find("Players/untitlemixama3");
            gameObject2.SetActive(false);
        }
        gameOverCanvas.SetActive(false);
        playCanvas.SetActive(true);
        isGameStart = false;
        text.text = "Level : "+PlayerPrefs.GetInt("Level",1).ToString();
        //scoreText.text = PlayerPrefs.GetInt("CoinCount").ToString();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       /* if (winPanelTextScore.activeInHierarchy)
        {
            
        }*/
        if(mainMenuPanel.activeInHierarchy){
            mainMenuText.text = PlayerPrefs.GetInt("CoinCount",0).ToString();
        }
    }

    public void playGame(){
        isGameStart = true;
        playBtn.enabled = false;
        button.SetActive(false);
    }

    public void gameOverUI(){
        gameDefeat = true;
        playCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void Replay(){
        SceneManager.LoadScene("SampleScene");
    }

    public void coinCollect(){
        score = score +1;
        scoreText.text = score.ToString();
        //PlayerPrefs.SetInt("CoinCount",score);
        // ButtonController
    }

    public void winlevel(){
        winPanel.SetActive(true);
        winPanelLevelText.text = PlayerPrefs.GetInt("Level",1).ToString();
        int totalCoin = 0;
        totalCoin = PlayerPrefs.GetInt("CoinCount",0);
        
        countCoint = totalCoin + score;
        //PlayerPrefs.SetInt("CoinCount",countCoint);
        winPanelTextScore.text = score.ToString();
    }

    public void winBtnlevel(){/*
        int totalCoin = 0;
        totalCoin = PlayerPrefs.GetInt("CoinCount");
        
        countCoint = totalCoin + score;
        //PlayerPrefs.SetInt("CoinCount",countCoint);
        winPanelTextScore.text = countCoint.ToString();*/
        PlayerPrefs.SetInt("CoinCount",countCoint);
        int level = PlayerPrefs.GetInt("Level",1);
        PlayerPrefs.SetInt("Level",level+1);
        isNextLevelPlay = true;
        winPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void mainMenuPlayButton(){
        if(isNextLevelPlay){
            SceneManager.LoadScene("SampleScene");
        }else{
            mainMenuPanel.SetActive(false);
            playPanel.SetActive(true);
        }
        
    }
}
