using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip slideClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playJumpSFX(){
        // sound effect
        audioSource.PlayOneShot(jumpClip,1);
    }

    public void playSlideSFX(){
        // sound effect
        audioSource.PlayOneShot(slideClip,1);
    }
}
