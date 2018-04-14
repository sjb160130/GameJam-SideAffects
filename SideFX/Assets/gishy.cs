using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gishy : MonoBehaviour {
    public bool phase1 = true;
    public GameObject leafboi;
    public bool canleaf = true;
    public float max_health = 100;
    public float cur_Health;
    public GameObject healthBar;
    private bool slowed = false;
    Rigidbody2D rb;
    public GameObject target;
    public GameObject target2;
    public float speed = 20f;
    public bool left;
    private bool invence = false;
    // Use this for initialization
    void Start () {
        cur_Health = max_health;
        rb = GetComponent<Rigidbody2D>();
    }
    void decreaseHealthbar()
    {
        cur_Health -= 1;
        float calc_Health = cur_Health / max_health;
        SetHealthBar(calc_Health);
    }
    // Update is called once per frame
    void Update () {
        if (!slowed)
        {
            speed = 20f;
        }
        else
        {
            speed = 2f;
        }
        if (phase1)
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            if (canleaf)
            {
                Instantiate(leafboi, gameObject.transform.position, gameObject.transform.rotation);
                canleaf = false;
                Invoke("canleafrecharge",4f);
            }
        }
        else
        {
            //transform.rotation.y = 0
            float step = speed * Time.deltaTime;
            if (left)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, step);
                
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
               
            }
            rb.constraints = RigidbodyConstraints2D.None;
           // rb.freezeRotation = true;
            rb.isKinematic = (false);

        }
        
            
        
        if (cur_Health <= 75)
        {
            phase1 = false;
        }
            if(cur_Health <= 0)
        {
            //place win here
            SceneManager.LoadScene("Win");
            Destroy(gameObject);
        }
	}
    void canleafrecharge()
    {
        canleaf = true;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Poison")
        {
            Debug.Log("hit");
            decreaseHealthbar();
        }
        if (!invence)
        {
            if (trig.gameObject.tag == "sludge")
            {
                decreaseHealthbar();
                invence = true;
                Invoke("ResetInvol", 1.5f);
            }
        }
        if (trig.gameObject.tag == "TimeSlow")
        {
            slowed = true;
        }
        if (trig.gameObject.tag == "right")
        {
            left = true;
        }
        if (trig.gameObject.tag == "leftl")
        {
            left = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TimeSlow")
        {

            slowed = false;
        }
    }
    void ResetInvol()
    {
        invence = false;
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f),
                                               healthBar.transform.localScale.y,
                                               healthBar.transform.localScale.z);

    }
}
