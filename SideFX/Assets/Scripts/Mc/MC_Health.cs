using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MC_Health : MonoBehaviour {

    public int health;
    public GameObject playerHealthUI;
    public int bearHealth = 10;
    private bool invence = false;


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
        if (!invence)
        {
            if (trig.gameObject.tag == "enemy" && bearHealth > 0)
            {
                health -= 1;
                bearHealth -= 1;
                invence = true;
                Invoke("ResetInvol", 1.5f);
            }
            if (trig.gameObject.tag == "sludge" )
            {
                health -= 1;
                bearHealth -= 1;
                invence = true;
                Invoke("ResetInvol", 1.5f);
            }
        }
        if (trig.gameObject.tag == "enemy" && enemyScript1.cur_Health > 0)
        {
            health -= 1;
            enemyScript1.cur_Health -= 1;
        }
    }
    private void ResetInvol()
    {
        invence = false;
    }
}
