using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionControl : MonoBehaviour {
    public float thrust = 5000;
    Transform transform;
    Rigidbody2D rb;
    public GameObject potion;
    public LayerMask MissLayer;
    public GameObject player;
    public GameObject TimeExplosion;
    public GameObject Sludge;
    

    private bool timerGo = false;
    public float timer = 10f;
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        transform = GetComponent<Transform>();

        player = GameObject.Find("MC");
        rb.AddForce(transform.up * thrust);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            if (gameObject.CompareTag("Ice"))
            {
                Instantiate(TimeExplosion,transform.position,transform.rotation);
            }
            if (gameObject.CompareTag("Poison"))
            {
                Instantiate(Sludge, gameObject.transform.position,Sludge.transform.rotation);
            }
            if (gameObject.CompareTag("Heal"))
            {
                player.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            if (gameObject.CompareTag("Ice"))
            {
                Instantiate(TimeExplosion);
            }

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            rb.drag = 20;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            rb.drag = 0;
        }
    }
    // Update is called once per frame
    void Update () {
       
	}
    
}
