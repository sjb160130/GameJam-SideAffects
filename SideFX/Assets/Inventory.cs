using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private int position = 1;
    Animator anim;
    public MC_Movement potionType;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (position == 1)
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
            if (position == 1)
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

        
    }
}
