using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
    public Animator anim;
    public MC_Movement potionType;
    public GameObject Poison;
    public GameObject Ice;
    public GameObject Health;
    public PotionGun gun;
    public int position = 1;
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (position == 1 && gun.hasHPotion)
            {
                anim.SetBool("switchLeft", true);
                position = 0;
            }
            if( position == 2)
            {
                anim.SetBool("switchRight", false);
                position = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (position == 1&& gun.hasPPotion)
            {
                anim.SetBool("switchRight", true);
                position = 2;
            }
            if (position == 0)
            {
                anim.SetBool("switchLeft", false);
                position = 1;
            }
            

        }
        if(position == 1 && gun.hasIcePotion)
        {
            gun.CurrPotion = Ice;
        }
        if(position == 0&& gun.hasHPotion)
        {
            gun.CurrPotion = Poison;
        }
        if(position == 2&& gun.hasPPotion)
        {
            gun.CurrPotion = Health;
        }
        
    }
}
