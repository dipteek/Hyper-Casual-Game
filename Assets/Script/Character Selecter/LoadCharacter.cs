using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterPrefabs;
    public Transform swanPoint;
    
    public TMP_Text label;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharater = PlayerPrefs.GetInt("selectedCharater");
        GameObject prefab = characterPrefabs[selectedCharater];
        GameObject clone = Instantiate(prefab,swanPoint.position,Quaternion.identity);
        label.text = prefab.name;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
