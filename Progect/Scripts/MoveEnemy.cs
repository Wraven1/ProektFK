using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public float lerysik;
    public Vector2 dir;
    public float speed2;
    public Vector2 dir2;
    public GameObject Kristal;
    public GameObject KristalUTR;
    public Transform SpawnPos;
    public GameObject Sard;
    public Transform Pos;
    public bool Boss;
    public bool Band;
    public int Time2;
    public GameObject ULTSard;
    public int SH;
    public int pidor;
    public int Esli;
    public bool canYron;
    public bool pedro;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float step;
    private float progress;
    public Transform SeichasPos;
    public bool gika;
    public int melanhplia;
    private int Tiki;
    private Animator anim;
    public int keliga;
    public float fulHels;
    public GameObject HelsPoll;
    public GameObject FHelsPoll;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    private UnityEngine.Object explosion;
    private int i;
    public AudioSource SmertSong;
    public GameObject SmertBox;
    public GameObject SmertNaga;
    public bool star;
    public int Zacl;
    public int ep;
    public int ep2;
    public int cotik;
    public static int smert = 0;


    void Start()
    {
        StartCoroutine(Zizn());
        startPosition = new Vector2(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(-4, 3));
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        explosion = Resources.Load("Explosion");
        cotik = PlayerPrefs.GetInt("c");

        if (cotik == 0)
        {
            ep2 = PlayerPrefs.GetInt("Atak");
            ep = 1 + ep2;
            
        }
        if (cotik == 1)
        {
            ep2 = PlayerPrefs.GetInt("Atak1");
            ep = 1 + ep2;
        }
        if (cotik == 2)
        {
            ep2 = PlayerPrefs.GetInt("Atak2");
            ep = 1 + ep2;
        }
        if (cotik == 3)
        {
            ep2 = PlayerPrefs.GetInt("Atak3");
            ep = 1 + ep2;
        }
        if (cotik == 4)
        {
            ep2 = PlayerPrefs.GetInt("Atak4");
            ep = 1 + ep2;
        }
        if (cotik == 5)
        {
            ep2 = PlayerPrefs.GetInt("Atak5");
            ep = 1 + ep2;
        }
        if (cotik == 6)
        {
            ep2 = PlayerPrefs.GetInt("Atak6");
            ep = 1 + ep2;
        }

    }
    void FixedUpdate()
    {


        if (Band == false)
        {
            transform.Translate(dir * speed, Space.World);
            if (lerysik < 0.2f && keliga < 1)
            {
                speed = speed + lerysik;
                keliga += 1;
            }

        }
        if (Band == true && gika == false)
        {
            StartCoroutine(Peremeshenie());
           
            
        }
        if(Band == true && SH > 0)
        {
            transform.position = Vector2.Lerp(transform.position, startPosition, 0.03f);
        }
        
        if(gameObject.transform.position.x < -11)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y > 7)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < -7)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < -7 && Boss == true)
        {
            
            Destroy(gameObject);
        }

        if (SH <= 0 && Boss == false && melanhplia == 0)
        {
            melanhplia++;
            GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(Jivotnoe());
        }
        if(SH == 5 && pidor == 0 )
        {
            anim.SetTrigger("Aktiv");
            pidor++;
            canYron = false;
            StartCoroutine(Shild());
        }

        if(SH <= 0 && Boss == true)
        {
            if (Zacl < 1)
            {
                Instantiate(KristalUTR, SpawnPos.position, Quaternion.identity);
                Instantiate(Kristal, SpawnPos.position, Quaternion.identity);
                Destroy(gameObject);
                Zacl = 3;
            }
            
        }
        
        if (SH >= 0)
        {
            HelsPoll.transform.localScale = new Vector2(SH / fulHels, 1);
            
        }
        if (smert > 0 && Boss == true)
        {
            if (Zacl < 1)
            {
                Instantiate(KristalUTR, SpawnPos.position, Quaternion.identity);
                Destroy(gameObject);
                Zacl = 3;
            }

        }
    }

    private IEnumerator Zizn()
    {
       
        yield return new WaitForSeconds(60);
        SH = 0;

    }

    private IEnumerator Peremeshenie()
    {
        gika = true;
        yield return new WaitForSeconds(7);
        startPosition = new Vector2(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(-4, 3));
        gika = false;

    }

    private IEnumerator Shild()
    {
        yield return new WaitForSeconds(4);
        canYron = true;
    }
    private IEnumerator Jivotnoe()
    {
        Instantiate(SmertBox, SpawnPos.position, Quaternion.identity);
        Instantiate(SmertNaga, SpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(Kristal, SpawnPos.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D S)
    {
        if (Boss == true)
        {
            if (S.gameObject.tag.Equals("Plaer") && pedro == true)
            {
                StartCoroutine(SpawnSard());
                Band = true;
                pedro = false;
            }
        }
        else
        {
            if (S.gameObject.tag.Equals("Plaer"))
            {
                if (i < 1)
                {
                    Instantiate(Sard, Pos.position, Quaternion.identity);
                    i++;
                }
                
            }
            
        }
        if (S.gameObject.name.Equals("Suka(Clone)"))
        {
            Destroy(S.gameObject);
        }


    }
    void Repeat()
    {
        StartCoroutine(SpawnSard());
    }
    IEnumerator SpawnSard()
    {
        yield return new WaitForSeconds(Time2);
        Instantiate(ULTSard, Pos.position, Quaternion.identity);
        Repeat();
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plaer" && star == true)
        {
            
            Destroy(gameObject);
        }
        if (canYron == true)
        {
            if (collision.gameObject.tag == "Charge")
            {
                SH = SH - ep;
                Destroy(collision.gameObject);
                spriteRend.material = matBlink;
            }

            if (SH >= 0)
            {
                Invoke("RestMaterial", 0.2f);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Charge")
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Plaer" && Boss == false)
        {
            Instantiate(SmertBox, SpawnPos.position, Quaternion.identity);
            Instantiate(Kristal, SpawnPos.position, Quaternion.identity);
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }
       


        if (collision.gameObject.tag == "BHC")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Instantiate(SmertBox, SpawnPos.position, Quaternion.identity);
            Instantiate(Kristal, SpawnPos.position, Quaternion.identity);
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }

    }
    void RestMaterial()
    {
        spriteRend.material = matDefault;
    }

}
