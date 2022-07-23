using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy2 : MonoBehaviour
{
    public float speed;
    private bool moveleft;
    private bool Canmove;
    public Rigidbody2D BeeC;
    private Animator Eanim;
    
    public Transform DetectcollR;
    public LayerMask player;
    
    public GameObject Bee;
    public Transform DetectT;
    


void Start()
{
    BeeC = GetComponent<Rigidbody2D>();
    Eanim = GetComponent<Animator>();
    moveleft = true;
    Canmove = true;
}
void Update()
{
    EnemyMove();

    HitDetect();
}
void EnemyMove()
{
    if (Canmove)
    {
        if (moveleft)
        {
            BeeC.velocity = new Vector2(-speed, BeeC.velocity.y);
        }
        else
        {
            BeeC.velocity = new Vector2(speed, BeeC.velocity.y);
        }
    }
}
//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.tag == "SideCol")
//    {
//        if (Physics2D.Raycast(DetectcollL.position, Vector2.left, 0.1f))
//        {
//            moveleft = !moveleft;
//        }

//        if (Physics2D.Raycast(DetectcollR.position, Vector2.right, 0.1f))
//        {
//            moveleft = true;
//        }
//    }
//}


void HitDetect()
{
        
    
    Collider2D Top = Physics2D.OverlapCircle(DetectT.position, 0.3f, player);
    

    if (Top != null) //meaning that if it detects a collision
    {
        if (Top.gameObject.tag == "Player")
        {
            Top.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Top.GetComponent<Rigidbody2D>().velocity.x, 8f); //Bounce to the top 
            Canmove = false;
            BeeC.velocity = new Vector2(0f, 0f);
            Eanim.Play("Destroyed");
            StartCoroutine(Up());
        }
    }
        //if (Circule != null)
        {
            //    if (Circule.gameObject.tag == "Player")
            //    {
            //        //Canmove = false;
            //        //BeeC.velocity = new Vector2(0f, 0f);
            //        //Eanim.Play("Destroyed");
            //        //StartCoroutine(Up());
            //    }
        }
}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D Circule = Physics2D.OverlapCircle(DetectcollR.position, 0.65f);
        
        if (collision.tag == "Player")
        {
            if(Circule.tag == "Player")
            {
                Canmove = false;
                BeeC.velocity = new Vector2(0f, 0f);
                Eanim.Play("Destroyed");
                StartCoroutine(Up());
            }
        }
       
    }
    
    
    IEnumerator Up()
{
    yield return new WaitForSecondsRealtime(0.4f);
        Bee.SetActive(false);
}
}//Class
