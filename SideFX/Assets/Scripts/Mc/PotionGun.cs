﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionGun : MonoBehaviour {
    public bool isShooting= false;
    public PotionControl potion;
    public GameObject CurrPotion;
    public float potionSpeed;
    
    public float timeBetweenthrow;
    private float throwCounter;
    public bool hasPPotion=false;
    public bool hasIcePotion = false;
    public bool hasHPotion = false;
    public Transform firePoint;
    public Inventory inv;
    public Animator PPotion;
    public Animator HPotion;
    public Animator IcePotion;

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
        if (hasIcePotion)
        {
            var go = Instantiate(CurrPotion, transform.position, q);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IcePotionRecip"))
        {
            hasIcePotion = true;
            IcePotion.SetBool("hasIce", true);
            inv.anim.SetBool("hasIce", true);
            Destroy(other.gameObject);

        }
        if(other.CompareTag("PoiPotionRecip"))
        {
            hasPPotion = true;
            PPotion.SetBool("HasPoi", true);
            inv.anim.SetBool("hasPoi", true);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("HeaPotionRecip"))
        {
            hasHPotion = true;
            HPotion.SetBool("hasHealth", true);
            inv.anim.SetBool("hasHea", true);
            Destroy(other.gameObject);
        }
    }
}
