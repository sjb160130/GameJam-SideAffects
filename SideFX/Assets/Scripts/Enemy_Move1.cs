using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move1 : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    private bool scared = true;
    private bool done = false;
    public Collider2D bear_Collider;

    public float max_health = 10;
    public float cur_Health;
    public GameObject healthBar;
    public bool dead = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cur_Health = max_health;
        //InvokeRepeating("decreaseHealthbar", 1f, 1f);
    }

    void decreaseHealthbar()
    {
        cur_Health -= 1;
        float calc_Health = cur_Health/max_health;
        SetHealthBar(calc_Health);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        //adjust less then to character size
        if (hit.distance < 0.7f)
        {
            //FlipPlayer();
        }

        RaycastHit2D see = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        //adjust less then to character size
        if ((see.distance < 15f) && scared == true)
        {
            Debug.Log("we");
            EnemySpeed = 4;
            scared = false;
            BearRunsAgain();
        }
        if(dead == true)
        {
            anim.SetBool("Run", false);
        }
        if(cur_Health == 0 && dead == false)
        {
            Debug.Log("ohboi");
            XMoveDirection = 0;
            EnemySpeed = 0;
            bear_Collider.isTrigger = false;
            dead = true;
            if (Input.GetKeyDown(KeyCode.Return) && dead == true){
                Debug.Log("I love sarah");
                dead = false;;
            }
        }

   }

    void BearRunsAgain()
    {
        //StartCoroutine("Wait");
        anim.SetBool("Run", true);
    }

    IEnumerator Wait()
    {
        //This is a 
        yield return new WaitForSeconds(1);    //Wait one 
        EnemySpeed = 4;
    }

    void FlipPlayer() {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else {
            XMoveDirection = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
       
        if (trig.gameObject.tag == "potion" && cur_Health > 0)
        {
            Debug.Log("hit");
            decreaseHealthbar();
        }
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f),
                                               healthBar.transform.localScale.y,
                                               healthBar.transform.localScale.z);

    }

}
