using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExplosionScript : MonoBehaviour {

    Transform tran;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 0.75f;

    void Start () {
        tran = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        tran.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;
        if(tran.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
            
    }
}
