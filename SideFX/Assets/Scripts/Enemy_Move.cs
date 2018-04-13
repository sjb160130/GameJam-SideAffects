using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    public GameObject Text_Manager;
    public GameObject Text_Manager1;
    private bool scared = true;
    private bool done = false;
    public TextAsset textfile1;
    public Collider2D bear_Collider;

    public float max_health = 10;
    public float cur_Health;
    public GameObject healthBar;
    public bool dead = false;
    public TextAsset bear2;

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
        if ((see.distance < 7f) && scared == true)
        {
            Debug.Log("we");
            Text_Manager.GetComponent<Text_manager1>().EnableTextBox();
            EnemySpeed = 0;
            scared = false;
        }
        if (scared == false)
        {
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
            Text_Manager1.GetComponent<Text_manager1>().EnableTextBox();
            if (Input.GetKeyDown(KeyCode.Return) && dead == true){
               Text_Manager1.GetComponent<Text_manager1>().DisableTextBox();
                Debug.Log("I love sarah");
                dead = false;;
            }
        }

   }

    void BearRunsAgain()
    {
        StartCoroutine("Wait");
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
       
        if (trig.gameObject.tag == "Poison" && cur_Health > 0)
        {
            Debug.Log("hit");
            decreaseHealthbar();
        }
        if(trig.gameObject.tag == "Ice")
        {
            
            EnemySpeed = 1;
        }
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f),
                                               healthBar.transform.localScale.y,
                                               healthBar.transform.localScale.z);

    }

}
