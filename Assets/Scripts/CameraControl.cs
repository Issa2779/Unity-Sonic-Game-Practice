using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public bool Following;


    void Start()
    {

    }

    
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

    }
}
