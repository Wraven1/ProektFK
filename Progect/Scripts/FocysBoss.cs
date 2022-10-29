using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocysBoss : MonoBehaviour
{
    public float speed;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Disol").transform;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Disol").transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
