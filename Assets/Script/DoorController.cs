using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator myAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {   
                this.myAnimator.SetTrigger("doorOp1");
        }
    }
}
