using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brownie : MonoBehaviour
{ private GameControl gameControl;
    public AudioClip collectSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameControl = GameObject.Find("GameController").GetComponent<GameControl>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlaySound(collectSound);
        gameControl.UpdateScore(1); // changes score text
        
        Destroy(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}


   
   
   
