using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiberBoos : MonoBehaviour
{
    public GameObject Sard;
    public Transform Pos;
    public int taimer;
    public float speed;
    public GameObject HelsPoll;
    public GameObject BossBar;
    public GameObject ShildBar;
    public GameObject ShildPoll;
    public int HPS;
    public GameObject Klon;
    public float HP;
    public float fulHels;
    private UnityEngine.Object exp;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    public GameObject Rib;
    public int p ;
    public bool gika;
    public Vector2 startPosition;
    private Animator anim;
    public bool cebyron;
    public int Anton;
    public bool zapon;
    public int ryt;
    public int tr;
    void Start()
    {
        p = 0;
        StartCoroutine(SpawnSard());
        exp = Resources.Load("Exp");
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (gika == false)
        {
            StartCoroutine(Peremeshenie());

        }

        if (HP > -1)
        {
            HelsPoll.transform.localScale = new Vector2(HP / fulHels, 1);
        }
        if (HPS > 0)
        {
            ShildPoll.transform.localScale = new Vector2(HPS / 50f, 1);
        }
        if (cebyron == true && HPS  <= 0)
        {
            ShildBar.SetActive(false);
            cebyron = false;
        }

        if (HP <= 0 && p == 2)
        {
            BossBar.SetActive(false);
            StartCoroutine(SpawnRib());
            MoveEnemy.smert++;
            Pritahenie.smert++;
            p = 4;
    
        }
        if (HP <= 80 && p == 0 )
        {
            StartCoroutine(SpawnKlon());
            p = 3;
            
        }
        if (HP <= 10 && p == 3)
        {
            cebyron = true;
            Bliznes();
            p = 2;
        }
        if(tr == ryt)
        {
            Destroy(gameObject);
        }
        if (p < 4)
        {
            transform.position = Vector2.Lerp(transform.position, startPosition, 0.09f);
        }
    }
    private void Bliznes()
    {
        ShildBar.SetActive(true);
        StartCoroutine(Zapolnenie());
        anim.SetTrigger("Aktiv");
    }
    IEnumerator Zapolnenie()
    {
        while (HPS < 45)
        {
            HPS++;
            yield return new WaitForSeconds(0.1f);
        }
        anim.SetBool("Held", true);
        zapon = true;

    }
   

    IEnumerator SpawnRib()
    {
        while (tr < ryt)
        {
            Instantiate(Rib, Pos.position, Quaternion.identity);
            GameObject explosionRef = (GameObject)Instantiate(exp);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    
    private IEnumerator Peremeshenie()
    {
        gika = true;
        yield return new WaitForSeconds(7);
        startPosition = new Vector2(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(-4, 3));
        gika = false;

    }

    void Repeat()
    {
        StartCoroutine(SpawnSard());
        
    }
    void Reper()
    {
        StartCoroutine(SpawnKlon());
        
    }

    IEnumerator SpawnSard()
    {
        yield return new WaitForSeconds(taimer);
        Instantiate(Sard, Pos.position, Quaternion.identity);
        Repeat();
    }
    IEnumerator SpawnKlon()
    {
        yield return new WaitForSeconds(Anton);
        Instantiate(Klon, Pos.position, Quaternion.identity);
        Reper();
    }
    IEnumerator retra()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRend.material = matDefault;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Charge")
        {
            if (cebyron == false)
            {
                HP = HP - 1;
                spriteRend.material = matBlink;
                StartCoroutine(retra());
                Destroy(collision.gameObject);
            }
            if(cebyron == true && zapon == true)
            {   HPS = HPS - 1;
                StartCoroutine(retra());
                Destroy(collision.gameObject);
                
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Unit")
        {
            if (HP < 45)
            {
                HP = HP + 5;
                Destroy(collision.gameObject);
               
            }
            else
            {
                Destroy(collision.gameObject);
            }
            
        }

    }
    private void OnTriggerEnter2D(Collider2D S)
    {
        
        if (S.gameObject.name.Equals("SollK(Clone)"))
        {
            if (HP < 45)
            {
                HP = HP + 5;
                Destroy(S.gameObject);
               
            }
            else
            {
                Destroy(S.gameObject);
            }
            
        }


    }
    

}
