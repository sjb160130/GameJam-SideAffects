using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour {

    public GameObject wolf;
    public GameObject wolf2;
    public GameObject wolf3;
    public GameObject wolf4;
    //public GameObject wolf5;


    void Start () {
		


	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            wolf.SetActive( true);
            wolf2.SetActive( true);
            wolf3.SetActive(true);
            wolf4.SetActive(true);
           // wolf5.SetActive(true);

        }
    }
}
