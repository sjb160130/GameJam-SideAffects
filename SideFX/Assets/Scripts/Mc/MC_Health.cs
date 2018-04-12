using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MC_Health : MonoBehaviour {

    public int health;
    public GameObject playerHealthUI;
    public int bearHealth = 10;
	// Update is called once per frame
	void Update () {
        if (health <=0 ){
            Die();
        }
        playerHealthUI.gameObject.GetComponent<Text>().text = ("Health:" + health);
    }

    void Die()
    {
        SceneManager.LoadScene("Lose");
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "enemy" && bearHealth > 0)
        {
            health -= 1;
            bearHealth -= 1;
        }
    }
}
