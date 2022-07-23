using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour

{
    public float Playerspeed = 10;
    public Rigidbody2D Controller;
    public float jumpS;
    public bool Gr;
    public Transform CheckGr;
    public float GroundRadius;
    public LayerMask WhatGround;
    private Animator Anim;
    public Vector3 respawn;
    public GameObject Playerr;


    public AudioClip JumpSound;
    public AudioClip RollingSound;
    private AudioSource Effects;

    bool movementD = true;
    

    void Start()
    {
        Controller = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Effects = GetComponent<AudioSource>();
        transform.position = respawn;
    }

    void Update()
    {
        Movement();
       
        Jump();
        Duck();
        Roll();
        LookUP();
        Spin();

    }
    
   void Movement()
    {
        if (movementD)
        {
            //if (Input.GetAxis("Horizontal") > 0f)
            //{

            //    Controller.velocity = new Vector2(Playerspeed, Controller.velocity.y);
            //    transform.localScale = new Vector3(5.0012f, 5.0012f, 5.0012f);
            //}
            //else if (Input.GetAxis("Horizontal") < 0f)
            //{
            //    Controller.velocity = new Vector2(-Playerspeed, Controller.velocity.y);
            //    transform.localScale = new Vector3(-5.0012f, 5.0012f, -5.0012f);
            //}

            var horizontal_movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontal_movement, 0, 0) * Time.deltaTime * Playerspeed;

            if (!Mathf.Approximately(0, horizontal_movement))
            {
                transform.rotation = horizontal_movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                
            }
        }
    }

    void Jump()
    {
      
        Gr = Physics2D.OverlapCircle(CheckGr.position, GroundRadius, WhatGround);
        
            if (Input.GetButtonDown("Jump") && Gr)
            {

                Effects.PlayOneShot(JumpSound); 
                Controller.velocity = new Vector3(Controller.velocity.x, jumpS, 0f);
                Anim.SetBool("Ground", false);
            }
        
        Anim.SetFloat("Speed", Mathf.Abs(Controller.velocity.x));
        Anim.SetBool("Ground", Gr);
    }
    void Duck()
    {

        if (Input.GetButton("Fire1"))
        {

            Anim.SetBool("Duck", true);
            movementD = false;
            
        }
        else
        {

            Anim.SetBool("Duck", false);
            movementD = true;
        }
    }
    void Roll()
    {
        
        if (Input.GetButtonDown("Fire1") && Gr)
        {
           
            Anim.SetBool("Roll", true);
           
        }
        else
        {
            
            Anim.SetBool("Roll", false);
            
        }

    }
    void LookUP()
    {

        if (Input.GetButton("Fire2"))
        {
            
            //transform.localScale = new Vector3(Playerr.transform.localScale.x, Playerr.transform.localScale.y, Playerr.transform.localScale.z);
            Anim.SetBool("LookUp", true);
        
        }
        else
        {
            Anim.SetBool("LookUp", false);
          
        }
    }
    void Spin()
    {
        
        if (Input.GetButton("Fire3"))
        {
            Anim.SetBool("Spin",true);
           
        }
        else
        {
            Anim.SetBool("Spin", false);
          
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "KillPlane")
        {
            transform.position = respawn;
            transform.position = new Vector3(Playerr.transform.position.x, Playerr.transform.position.y, 0f);
        }
        if (other.tag == "CheckpointRe")
        {
            respawn = other.transform.position;
            transform.position = new Vector3(Playerr.transform.position.x, Playerr.transform.position.y, 0f);
        }

    }
    
}//class
