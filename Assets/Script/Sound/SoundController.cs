using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public float volume;
    //AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetFloat("musicVolume",0.5f);
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",0.5f);
        }else{

            volumeSlider.value = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(){
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume",volumeSlider.value);
    }
}
