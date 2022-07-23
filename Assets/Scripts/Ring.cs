using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Animator Spark;
    // Start is called before the first frame update
    void Start()
    {
        Spark = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Spark.Play("Collected");
            StartCoroutine(Instant());
        }
        
    }
    IEnumerator Instant()
    {

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }
}
