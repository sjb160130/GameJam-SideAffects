using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MC_Health : MonoBehaviour {

    public int health;
    public GameObject playerHealthUI;
	// Update is called once per frame
	void Update () {
        if (health <=0 ){
            Die();
        }
        playerHealthUI.gameObject.GetComponent<Text>().text = ("Health:" + health);
    }

    void Die()
    {
        SceneManager.LoadScene("Main");
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "enemy")
        {
            health -= 1;
        }
    }
}
