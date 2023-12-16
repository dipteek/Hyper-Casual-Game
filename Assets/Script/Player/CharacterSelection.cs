using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharater =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextCharecter(){
        characters[selectedCharater].SetActive(false);
        selectedCharater = (selectedCharater + 1)%characters.Length;
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
        characters[selectedCharater].SetActive(true);
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharater",selectedCharater);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
