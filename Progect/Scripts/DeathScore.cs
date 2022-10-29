using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathScore : MonoBehaviour
{
    public int score;
    public Text sukaYmirai;

    void Start()
    {
        sukaYmirai.text = score.ToString();
    }

    
    void Update()
    {
        score++;
        sukaYmirai.text = score.ToString();
    }
}
