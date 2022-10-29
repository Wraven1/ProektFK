using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jasic : MonoBehaviour
{
    public float speed;
    Rigidbody2D rd;
    public Joystick joystick;
    private Vector2 Movevelocity;
    
    void Start()
    {
        rd = GetComponent <Rigidbody2D>();
    }

    
    void Update()
    {   
        
        Vector2 moveImput = new Vector2(joystick.Horizontal, joystick.Vertical);
        Movevelocity = moveImput.normalized * speed;
    }
    private void FixedUpdate()
    {
        rd.MovePosition(rd.position + Movevelocity * Time.deltaTime);
    }
}
