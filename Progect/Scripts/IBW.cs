using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IBW : MonoBehaviour
{
    public GameObject Magiccharge;
    public bool Kyr;
    public bool canShoot;
    public float Kuldaun;
    public float fulMana;
    public float UsedMana;
    public float OstMana;
    public GameObject ManaPoll;
    public Transform SpawnPos;
    public Image abilityImega1;
    public bool Gotovo;
    public float jyldayn;
    private float gohan;
    public int Pshag;
    public AudioSource ManaSong;

    void Start()
    {
        canShoot = true;
        OstMana = fulMana;
    }

    
    void Update()
    {
        if (Kyr == true && canShoot == true)
        {
            StartCoroutine(Shoot());
            Kyr = false;
        }
        ManaPoll.transform.localScale = new Vector2(OstMana / fulMana, 1);
        if (Gotovo == true && abilityImega1.fillAmount < 1)
        {
            gohan = 1 / Kuldaun;
            abilityImega1.fillAmount += gohan * Time.deltaTime;
        }
    }
    private IEnumerator Shoot()
    {
        canShoot = false;
        OstMana -= UsedMana;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(Kuldaun);
        canShoot = true;

    }
    public void ChargeStraike()
    {
        if (OstMana >= UsedMana)
        {
            Kyr = true;
        }
    }
    private IEnumerator Popolnen()
    {
        while (Pshag < 20 && OstMana < fulMana)
        {
            OstMana += 1;
            Pshag++;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D S)
    {

        if (S.gameObject.name.Equals("mana(Clone)"))
        {
            if (OstMana < fulMana)
            {
                ManaSong.Play();
                Pshag = 0;
                StartCoroutine(Popolnen());
                Destroy(S.gameObject);
            }
            else
            {
                Destroy(S.gameObject);
            }

        }
        if (S.gameObject.name.Equals("mana"))
        {
            if (OstMana < fulMana)
            {
                ManaSong.Play();
                Pshag = 0;
                StartCoroutine(Popolnen());
                Destroy(S.gameObject);
            }
            else
            {
                Destroy(S.gameObject);
            }

        }




    }
}
