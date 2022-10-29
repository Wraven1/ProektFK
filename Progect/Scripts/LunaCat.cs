using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaCat : MonoBehaviour
{
    public GameObject Sard;
    public GameObject Verhyhka;
    public Transform Pos;
    public int taimer;
    public bool verh;
    public GameObject HelsPoll;
    public GameObject BossBar;
    public GameObject EFFECT;
    public GameObject EF;
    public float HP;
    public float fulHels;
    public int ip;
    private UnityEngine.Object exp;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    public GameObject Rib;
    public int p;
    public Vector2 startPosition;
    public int pg;
    public int toget;
    

    void Start()
    {
        StartCoroutine(Opred());
        exp = Resources.Load("ZvezdaHkval");
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        
        
    }


    void FixedUpdate()
    {
        if (HP > -1)
        {
            HelsPoll.transform.localScale = new Vector2(HP / fulHels, 1);
        }
        if(HP <= 0 && p <= 0)
        {
            BossBar.SetActive(false);
            StartCoroutine(SpawnRib());
            p = 1;
        }
         if (HP < 55 && ip == 0 )
        {
            Repeat();
            ip = 1;
        }
        if (HP < 45 && ip == 1 )
        {
            toget = 10;
            ip = 2;
            
        }
        if (HP < 15 && ip == 2)
        {
            toget = 20;
            taimer = taimer - 5;
            ip = 3;
        }
        if(HP > 0)
        {
        transform.position = Vector2.Lerp(transform.position, startPosition, 0.09f);
        }
    }
    
    void Repeat()
    {  
        if(HP > 0)
        {
        pg = 0;
        StartCoroutine(PredAtaka());
        }
    }
    void RetOp()
    {
        StartCoroutine(Opred());
    }
    IEnumerator SpawnSard()
    {
        while (pg < toget)
        {
        pg++;      
        yield return new WaitForSeconds(0.3f);
        float rand = Random.Range(-9f, 6f);
        Instantiate(Sard, new Vector3(rand, 5, 0), Quaternion.identity);
        }
        Invoke("Repeat",taimer);
    }
    IEnumerator PredAtaka()
    {
        GameObject explosionRef = (GameObject)Instantiate(exp);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnSard());
    }
    IEnumerator retra()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRend.material = matDefault;
    }
    IEnumerator SpawnRib()
    {
        while(p < 50)
        {
        p++;
        Instantiate(Rib, Pos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        }
        Instantiate(EFFECT, Pos.position, Quaternion.identity);
        yield return new WaitForSeconds(4.7f);
        Destroy(gameObject); 
    }
    IEnumerator Opred()
    {
        yield return new WaitForSeconds(3.22f);
        startPosition = new Vector2(6, 3);
        yield return new WaitForSeconds(3.22f);
        startPosition = new Vector2(6, 0);
        yield return new WaitForSeconds(3.22f);
        startPosition = new Vector2(6, -2);
        RetOp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Charge")
        {
            HP = HP - 1;
            spriteRend.material = matBlink;
            StartCoroutine(retra());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Unit")
        {
            if (HP < fulHels)
            {
                HP = HP + 1;
                
            }

        }

    }
    
}
