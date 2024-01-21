using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip audioClip;

    public AudioClip audioMainMenuPlayBtnClip;
    public AudioClip audioGameOverClip;

    public AudioClip audioCoinCollider;

    
    public bool isPlayButtonClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(){
        // sound effect
        audioSource.PlayOneShot(audioClip,1);
            isPlayButtonClick = false;
        if (isPlayButtonClick)
        {
            
        }
    }

    public void playGameoverSFX(){
        // sound effect
        audioSource.PlayOneShot(audioGameOverClip,1);
    }

    public void playCoinColliderSFX(){
        // sound effect
        audioSource.PlayOneShot(audioCoinCollider,1);
    }

    
}
