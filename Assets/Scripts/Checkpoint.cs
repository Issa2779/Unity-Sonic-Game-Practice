using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator Checked;
    public AudioClip CheckedS;
    private AudioSource Effects;
 
    void Start()
    {
        Checked = GetComponent<Animator>();
        Effects = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Effects.PlayOneShot(CheckedS);
            Checked.Play("Checked");
            
            
        }

    }
  
}
