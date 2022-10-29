using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molnia : MonoBehaviour
{
    public float speed;
    public bool trans;
    public Vector2 dir;
    Transform player;

    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSeed = 2f;
    float positionX, positionY, angle = 0;
    public int timer; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Plaer").transform;
        center = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    void FixedUpdate()
    {
        timer++;
        if (timer < 360)
        {
            positionX = center.position.x + Mathf.Cos(angle) * radius;
            positionY = center.position.y + Mathf.Sin(angle) * radius;
            transform.position = new Vector2(positionX, positionY);
            angle = angle + Time.deltaTime * angularSeed;
           
        }
        
        if(transform.position.x < - 11)
        {
          Destroy(gameObject);
        }

        if (timer >= 360)
        {
            if (trans == false)
            {
                player = GameObject.FindGameObjectWithTag("Plaer").transform;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                speed = 0.05f;
                transform.Translate(dir * speed, Space.World);
            }
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plaer")
        {
            Destroy(gameObject);
        }

  
        
        if (collision.gameObject.tag.Equals("Charge"))
        {
            Destroy(collision.gameObject);
        }

    }
    IEnumerator Kek()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
