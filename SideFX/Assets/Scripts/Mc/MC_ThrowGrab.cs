using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_ThrowGrab : MonoBehaviour {

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notbox;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics2D.queriesStartInColliders=false;
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if(hit.collider!=null && hit.collider.tag == "coin")
            {
                grabbed = true;
            }
        }else if (!Physics2D.OverlapPoint(holdpoint.position)){
            grabbed = false;
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) ;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1);
            }
        }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Vector3.right * transform.localScale.x);
    }
	}

