using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionControl : MonoBehaviour {
    public float thrust = 5000;
    Transform transform;
    Rigidbody2D rb;
    public GameObject potion;
    public LayerMask MissLayer;
    
    
    private bool timerGo = false;
    public float timer = 10f;
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        transform = GetComponent<Transform>();
       
        
        rb.AddForce(transform.up * thrust);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
