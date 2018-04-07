using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Potions : MonoBehaviour {

    public int potionCount = 0;
    public GameObject playerScoreUI;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        playerScoreUI.gameObject.GetComponent <Text>().text = ("Potions:" + potionCount);
	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("yeet");
        if (trig.gameObject.tag == "coin") {
            potionCount += 1;
            Destroy(trig.gameObject);
        }
    }
}
