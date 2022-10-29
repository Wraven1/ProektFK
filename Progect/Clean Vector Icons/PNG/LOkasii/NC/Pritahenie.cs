using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pritahenie : MonoBehaviour
{
    public float speed;
    Transform player;
    public static int smert = 0;

    void FixedUpdate()
    {
        if(smert > 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Boss").transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
