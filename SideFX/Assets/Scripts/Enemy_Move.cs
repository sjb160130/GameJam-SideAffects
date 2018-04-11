using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    public GameObject Text_Manager;
    private bool scared = true;
    private bool done = false;
    public TextAsset textfile1;
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        //adjust less then to character size
        if (hit.distance < 0.7f)
        {
            FlipPlayer();
        }

        RaycastHit2D see = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        //adjust less then to character size
        if ((see.distance < 7f) && scared == true)
        {
            Debug.Log("we");
            Text_Manager.GetComponent<Text_manager1>().EnableTextBox();
            EnemySpeed = 0;
            scared = false;
        }
        if (scared == false)
        {
            BearRunsAgain();
        }
   }
    void BearRunsAgain()
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        //This is a 
        yield return new WaitForSeconds(3);    //Wait one 
        EnemySpeed = 4;
    }
void FlipPlayer() {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else {
            XMoveDirection = 1;
        }
    }
}
