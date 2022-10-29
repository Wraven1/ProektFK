using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float speed;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Plaer").transform;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Plaer").transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position,speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plaer")
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D S)
    {
        if (S.gameObject.tag.Equals("Plaer"))
        {
            StartCoroutine(Kek()); 
        }

    }
    IEnumerator Kek()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}

