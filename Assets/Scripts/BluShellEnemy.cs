using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluShellEnemy : MonoBehaviour
{
    public float speed;
    private bool moveleft;
    private bool Canmove;
    public Rigidbody2D BlueShell;
    private Animator Eanim;
    public Transform DetectcollL;
    public Transform DetectcollR;
    public LayerMask player;
    public Vector3 Leftcollision, Rightcollision;
    public GameObject Blue;
    public Transform DetectT;
    private bool Stunned;
    
    void Start()
    {
        BlueShell = GetComponent<Rigidbody2D>();
        Eanim = GetComponent<Animator>();
        moveleft = true;
        Canmove = true;
    }
    void Update()
    {
        EnemyMove();
        ScaleDirection();
        HitDetect();
    }
    void EnemyMove()
    {
        if (Canmove)
        {
            if (moveleft)
            {
                BlueShell.velocity = new Vector2(-speed, BlueShell.velocity.y);
            }
            else
            {
                BlueShell.velocity = new Vector2(speed, BlueShell.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SideCol")
        {
            if (Physics2D.Raycast(DetectcollL.position, Vector2.left, 0.1f))
            {
                moveleft = !moveleft;
            }
            
             if(Physics2D.Raycast(DetectcollR.position, Vector2.right, 0.1f))
            {
                moveleft = true;
            }
        }
    }
    
    void ScaleDirection()
    {
        Vector3  tempscale = transform.localScale;
        if (moveleft)
        {
            tempscale.x = Mathf.Abs(tempscale.x);
        }
        else
        {
            tempscale.x = -Mathf.Abs(tempscale.x);
        }
        transform.localScale = tempscale;

    }
    void HitDetect()
    {
        RaycastHit2D Left = Physics2D.Raycast(DetectcollL.position, Vector2.left, 0.1f, player); //damage
        RaycastHit2D Right = Physics2D.Raycast(DetectcollR.position, Vector2.right, 0.1f, player);//damage
        Collider2D Top = Physics2D.OverlapCircle(DetectT.position, 0.1f, player);//hitting on his shell

        if (Top != null) //meaning that if it detects a collision
        {
            if (Top.gameObject.tag == "Player") {
                
                    Top.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Top.GetComponent<Rigidbody2D>().velocity.x, 8f); //Bounce to the top 
                    Canmove = false;
                    BlueShell.velocity = new Vector2(0f, 0f);
                    Eanim.Play("Stunned");
                    StartCoroutine(Up());
            }
        }
        
    }
    IEnumerator Up()
    {
        yield return new WaitForSeconds (4f);
        Canmove = true;
        if (Canmove)
        {
            if (moveleft)
            {
                BlueShell.velocity = new Vector2(-speed, BlueShell.velocity.y);
            }
            else
            {
                BlueShell.velocity = new Vector2(speed, BlueShell.velocity.y);
            }
        }
    }
   
}//Class
