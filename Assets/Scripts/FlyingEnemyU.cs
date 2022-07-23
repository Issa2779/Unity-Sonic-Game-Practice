using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyU : MonoBehaviour
{
    public float speed;
    public Rigidbody2D FlyingUnleashed;
    private bool Canmove;
    private bool leftmove;
    public Transform DetectTop;
    public Transform DetectDown;
    public LayerMask Playerrr;
    void Start()
    {
        FlyingUnleashed = GetComponent<Rigidbody2D>();
        Canmove = true;
        leftmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        TopDetector();
    }

    void Movement()
    {
        if (Canmove){
            if (leftmove)
            {
                FlyingUnleashed.velocity = new Vector2(-speed, FlyingUnleashed.velocity.y);
            }
            else
            {
                FlyingUnleashed.velocity = new Vector2(speed, FlyingUnleashed.velocity.y);
            }

        }
    }
    void TopDetector()
    {
        Collider2D Top = Physics2D.OverlapCircle(DetectTop.position,0.09f, Playerrr);

        if(Top != null)
        {
            if(Top.gameObject.tag == "Player")
            {
                Top.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Top.GetComponent<Rigidbody2D>().velocity.x, 8f);
                Canmove = false;
                gameObject.SetActive(false); 
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D Down = Physics2D.OverlapCircle(DetectDown.position, 0.09f, Playerrr);
        if(collision.tag == "Player")
        {
            if(Down.tag == "Player")
            {
                Canmove = false;
                gameObject.SetActive(false);
            }
        }
    }
    



}//class
