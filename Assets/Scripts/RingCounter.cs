using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingCounter : MonoBehaviour
{
    private Text Ring;
    private int RingCount = 0;
    
    public AudioClip RingSound;
    private AudioSource Effects;
    private Animator One;


    void Start()
    {
        Ring = GameObject.Find("Numbers").GetComponent<Text>();
        Effects = GetComponent<AudioSource>();
        One = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Rings")
        {
           
            Effects.PlayOneShot(RingSound);
            RingCount++;
            Ring.text = "" + RingCount;
            One.Play("Ringss");

        }
        if(other.tag == "HitL")
        {
            RingCount--;
            
        }
    }
   
}
