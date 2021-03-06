﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour {

    //Variables
    private bool faceRight = true;
    public int mcSpeed = 10;
    public int mcJumpPower = 1250;
    private float moveX;
    public bool falling = false;
    public PotionGun potiongun;
    public Inventory inv;
    Rigidbody2D rb;
    public bool slowed = false;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        McMove();
        if (Input.GetMouseButtonDown(0))
        {
            
                potiongun.Shoot();
            
        }
    }

    //Limit jumps
    private void OnCollisionStay2D()
    {
        falling = false;
    }

    //Moving
    void McMove()
    {   
        //Controls
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && (falling == false))
        {
            Jump();
        }
        falling = true;
        //Animations
        //Player direction
        if (moveX < 0.0f && faceRight == false)
        {
             FlipPlayer();
        }
        else if (moveX > 0.0f && faceRight == true)
        {
             FlipPlayer();
        }
         //Physics
         gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * mcSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * mcJumpPower);
    }

    void FlipPlayer()
    {
        faceRight = !faceRight;
        //transform.Rotate(0, 180, 0);
        Vector3 localScale = gameObject.transform.localScale;
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            rb.gravityScale = -5;
        }
        if (collision.CompareTag("NatureBoi"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            rb.gravityScale = 5;
        }
    }
}
