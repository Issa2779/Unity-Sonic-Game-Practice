using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speed = 1f;
    public Rigidbody2D Platform;
    public Transform Darrow, Tarrow;
    private bool Canmove;
    private bool upmove;

    void Start()
    {
        Platform = GetComponent<Rigidbody2D>();
        Canmove = true;
        upmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
   

    void movement()
    {
        
            if (Canmove)
            {
                if (upmove)
                {
                    Platform.velocity = new Vector2(Platform.velocity.x, speed);
                }
                else
                {
                    Platform.velocity = new Vector2(Platform.velocity.x, -speed);
                }
            }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SideCol")
        {
            if(Physics2D.Raycast(Tarrow.position, Vector2.up, 0.1f))
            {
                upmove = !upmove;
                
            }
            if (Physics2D.Raycast(Darrow.position, Vector2.down, 0.1f))
            {
                upmove = true;
            }
        }
    }

}//class
