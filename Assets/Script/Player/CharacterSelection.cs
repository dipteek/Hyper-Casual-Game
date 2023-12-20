using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;

    public int[] price;

    public int[] checkLock;
    public int selectedCharater =0;
    private int totalCharacter;

    public GameObject lockGameObject;

    public Button buyBtn;
    public Text priceShow;

    public Button startBtn;
    public PlayerBlueprint[] playerLists;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayerBlueprint playerItem in playerLists)
        {
            if (playerItem.price == 0)
               playerItem.isUnlock = true;
            else
               playerItem.isUnlock = PlayerPrefs.GetInt(playerItem.name,0) ==0 ? false : true;
              
        }
        totalCharacter = characters.Length;
        for (int i = 0; i < totalCharacter; i++)
        {
            if (i == 0)
            {
                
            }
        }
    }

    public void NextCharecter(){
        characters[selectedCharater].SetActive(false);
        selectedCharater = (selectedCharater + 1)%characters.Length;
        /*if (checkLock[selectedCharater] == 1)
        {
            lockGameObject.SetActive(true);
            startBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(true);
            priceShow.text = price[selectedCharater].ToString();
        }else{
            lockGameObject.SetActive(false);
            startBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
        }*/
        characters[selectedCharater].SetActive(true);
         
        
    }

    public void PreviousCharecter(){
        characters[selectedCharater].SetActive(false);
        selectedCharater--;
        if (selectedCharater < 0)
        {
            selectedCharater += characters.Length;
        }
        //selectedCharater = (selectedCharater + 1)%characters.Length;
       /* if (checkLock[selectedCharater] == 1)
        {
            lockGameObject.SetActive(true);
            startBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(true);
            priceShow.text = price[selectedCharater].ToString();
        }else{
            lockGameObject.SetActive(false);
            startBtn.gameObject.SetActive(true);
            buyBtn.gameObject.SetActive(false);
        }*/
        characters[selectedCharater].SetActive(true);

    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharater",selectedCharater);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
         UpdateUI();
    }

    private void UpdateUI(){
        PlayerBlueprint p = playerLists[selectedCharater];
        if (p.isUnlock)
        {
            lockGameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            startBtn.gameObject.SetActive(true);
        }else{
            startBtn.gameObject.SetActive(false);
            lockGameObject.SetActive(true);
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<Text>().text ="Buy "+p.price;
            if (PlayerPrefs.GetInt("CoinCount",0) >= p.price)
            {
                buyBtn.interactable = true;
            }else{
                buyBtn.interactable = false;
            }
        }
    }

    public void unlockPlayer(){
         PlayerBlueprint p = playerLists[selectedCharater];
          PlayerPrefs.SetInt(p.name,1);
          PlayerPrefs.SetInt("selectedCharater",selectedCharater);
          int currentCoin = PlayerPrefs.GetInt("CoinCount",0);
          PlayerPrefs.SetInt("CoinCount",currentCoin - p.price);
          p.isUnlock = true;
          UpdateUI();
    }
}
