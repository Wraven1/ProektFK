using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tikva : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    Transform player;

    void Start()
    {
      
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        player = GameObject.FindGameObjectWithTag("Boss").transform;

    }


    void FixedUpdate()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
