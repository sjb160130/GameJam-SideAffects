using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafControl : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public float speed = 3f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("MC");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.gameObject.transform.position - gameObject.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            speed = 1f;
        }
        if (collision.CompareTag("Poison"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TimeSlow"))
        {
            speed = 3f;
        }
    }
}
