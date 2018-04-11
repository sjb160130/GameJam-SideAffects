using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Animator : MonoBehaviour
{
    public Animator anim;
    bool m_Run;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        m_Run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            m_Run = true;
        } else {
            m_Run = false;
        }

        if (m_Run == false)
        {
           anim.SetBool("Move", false);
        }
        if (m_Run == true)
        {
            anim.SetBool("Move", true);
        }
    }
}
