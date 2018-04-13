<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

>>>>>>> Connor
public class sludge : MonoBehaviour {

    Transform tran;
    public float targetScale = 0.1f;
    public float shrinkSpeed = 0.1f;
    private bool grow=true;
    void Start () {
        tran = GetComponent<Transform>();
<<<<<<< HEAD
    }
	
	// Update is called once per frame
=======
    }
	
	// Update is called once per frame
>>>>>>> Connor
	void Update () {
        if (grow)
        {
            tran.localScale += new Vector3(1, 0, 0) * Time.deltaTime * shrinkSpeed;
        }
        if (tran.localScale.x >= 1)
        {
            grow = false;
            Destroy(gameObject, 2f);
        }
<<<<<<< HEAD
    }
}
=======
    }
}
>>>>>>> Connor
