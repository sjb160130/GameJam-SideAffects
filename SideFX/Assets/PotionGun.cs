using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionGun : MonoBehaviour {
    public bool isShooting= false;
    public PotionControl potion;
    
    public float potionSpeed;

    public float timeBetweenthrow;
    private float throwCounter;

    public Transform firePoint;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        //var go = Instantiate(potion, transform.position, q);

    }
    public void Shoot()
    {
        var pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);

        var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
        //Debug.Log("?");
        var go = Instantiate(potion, transform.position, q);
       
    }
}
