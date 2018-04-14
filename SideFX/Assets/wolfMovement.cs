using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wolfMovement : MonoBehaviour
{
    public int EnemySpeed;
    private bool slowed = false;
    public int XMoveDirection;

    public bool isLeft;
    public GameObject player;
    public Collider2D bear_Collider;

    public float max_health = 10;
    public float cur_Health;
    public GameObject healthBar;
    public bool dead = false;
    Animator anim;
    void Start()
    {
        player = GameObject.Find("MC");
        anim = GetComponent<Animator>();
        cur_Health = max_health;
    }
    void decreaseHealthbar()
    {
        cur_Health -= 1;
        float calc_Health = cur_Health / max_health;
        SetHealthBar(calc_Health);
    }

    void Update()
    {
        if (isLeft)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        }
        if (cur_Health == 0 && dead == false)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Wait()
    {
        //This is a 
        yield return new WaitForSeconds(1);    //Wait one 
        if (slowed)
        {
            EnemySpeed = 1;
        }
        else
        {
            EnemySpeed = 4;
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Poison" && cur_Health > 0)
        {
            Debug.Log("hit");
            decreaseHealthbar();
        }
        if (trig.gameObject.tag == "sludge" && cur_Health > 0)
        {
            decreaseHealthbar();
        }
        if (trig.gameObject.tag == "TimeSlow")
        {
            slowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TimeSlow")
        {

            slowed = false;
        }
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f),
                                               healthBar.transform.localScale.y,
                                               healthBar.transform.localScale.z);

    }
}
