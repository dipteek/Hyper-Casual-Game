using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public adsManager adManager;
    public bool isGameStart = false;
    public bool gameDefeat = false;
    public bool gameLevelFinished = false;

    public GameObject playCanvas;
    public GameObject gameOverCanvas;

    public GameObject button;

    public Text text;

    public Text scoreText;
    [SerializeField] Button playBtn;
    [SerializeField] GameObject moveTutorial;

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

     public Text mainMenuNextLevelTextBtn;
      public Text mainMenuLevelText;

     public bool isNextLevelPlay = false;

     public Material[] skyMaterial = new Material[3];
     public GameObject[] playerList = new GameObject[2];

     public GameObject musicControlPanel;
    // Start is called before the first frame update
    void Start()
    {
        adManager.LoadBanner();
        adManager.LoadInterstitial();
        int randomModel =Random.Range(0,9);
        print("sky "+randomModel);
        RenderSettings.skybox = skyMaterial[randomModel];
        isNextLevelPlay = false;
       gameLevelFinished = false;
        mainMenuPanel.SetActive(true);
        playerSelecter =  PlayerPrefs.GetInt("selectedCharater",0);
        if (playerSelecter == 0)
        {
            //gameObject = GameObject.Find("Players/Breathing Idle1"); 
            gameObject = playerList[0].gameObject;
            gameObject.gameObject.SetActive(true);
            //GameObject gameObject2 =GameObject.Find("Players/untitlemixama3");
            //gameObject2.SetActive(false);
            playerList[1].gameObject.SetActive(false);
        }else if(playerSelecter == 1)
        {
            //gameObject = GameObject.Find("Players/untitlemixama3");
            gameObject = playerList[1];
            gameObject.SetActive(true);
            //GameObject gameObject2 =GameObject.Find("Players/Breathing Idle1");
            playerList[0].SetActive(false);
        }else{
            //gameObject = GameObject.Find("Players/Breathing Idle1");
            gameObject =playerList[0];
            gameObject.SetActive(true);
            //GameObject gameObject2 =GameObject.Find("Players/untitlemixama3");
            playerList[1].SetActive(false);
        }
        gameOverCanvas.SetActive(false);
        playCanvas.SetActive(true);
        isGameStart = false;
        int tempLevelTxt =PlayerPrefs.GetInt("Level",1);
        if (tempLevelTxt>102000)
        {
            text.text = "Level 102000+";
        }else{
            text.text = "Level "+PlayerPrefs.GetInt("Level",1).ToString();
        }
        
        //scoreText.text = PlayerPrefs.GetInt("CoinCount").ToString();
        scoreText.text = "0";
        adManager. LoadBanner();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (winPanelTextScore.activeInHierarchy)
        {
            
        }*/
        if(mainMenuPanel.activeInHierarchy){
            // 
             int tempCoinTxt =PlayerPrefs.GetInt("CoinCount",0);
             if (tempCoinTxt>1234060000000)
             {
                mainMenuText.text = "1234060000000+";
             }else{
                mainMenuText.text = PlayerPrefs.GetInt("CoinCount",0).ToString();
             }

             mainMenuLevelText.text = PlayerPrefs.GetInt("Level",1).ToString();
            
        }
    }

    public void playGame(){
        adManager.LoadInterstitial();
        FindObjectOfType<SoundManager>().playSFX();
        isGameStart = true;
        playBtn.enabled = false;
        moveTutorial.SetActive(false);
        button.SetActive(false);
        adManager. LoadBanner();
    }

    public void gameOverUI(){
        adManager.LoadInterstitial();
        FindObjectOfType<SoundManager>().playGameoverSFX();
        gameDefeat = true;
        playCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        gameLevelFinished = true;
    }

    public void Replay(){
        adManager.ShowInterstitial();
        FindObjectOfType<SoundManager>().playSFX();
        SceneManager.LoadScene("leveld");
    }

    public void coinCollect(){
        score = score +1;
        scoreText.text = score.ToString();
        //PlayerPrefs.SetInt("CoinCount",score);
        // ButtonController
    }

    public void winlevel(){
         adManager. LoadRewarded();
        gameLevelFinished = true;
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
        mainMenuNextLevelTextBtn.text = "Next";
        isNextLevelPlay = true;
        winPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void winDoubleBtnlevel(){
        int totalCoinCheck = PlayerPrefs.GetInt("CoinCount",0);
        int coinDouble = score * 2;        
        countCoint = totalCoinCheck + coinDouble;
        
        PlayerPrefs.SetInt("CoinCount",countCoint);
        int level = PlayerPrefs.GetInt("Level",1);
        PlayerPrefs.SetInt("Level",level+1);
        mainMenuNextLevelTextBtn.text = "Next";
        isNextLevelPlay = true;
        winPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        
    }

   public void winDoubleBtnAds(){
         adManager.ShowRewarded();
   }

    public void mainMenuPlayButton(){
        FindObjectOfType<SoundManager>().isPlayButtonClick = true;
        FindObjectOfType<SoundManager>().playSFX();
        if(isNextLevelPlay){
            SceneManager.LoadScene("leveld");
        }else{
            mainMenuPanel.SetActive(false);
            playPanel.SetActive(true);
        }
        
    }

    public void choosePlayerScene(){
        SceneManager.LoadScene("MainMenu");
    }

    public void musicControllerUiEnabled(){
        musicControlPanel.SetActive(true);
    }

    public void musicControllerUiClose(){
        musicControlPanel.SetActive(false);
    }
}
