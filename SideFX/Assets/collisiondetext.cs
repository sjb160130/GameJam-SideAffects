using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiondetext : MonoBehaviour {
    public GameObject Text_Manager;
    public GameObject Text_Manager1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("yeet");
        if (trig.gameObject.tag == "poiPotionRecip")
        {
            Text_Manager.GetComponent<Text_manager1>().EnableTextBox();
            Debug.Log("yo");
        }

    }
}
