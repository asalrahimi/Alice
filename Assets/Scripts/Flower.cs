using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    Animator myanim;
    GameObject alice;

    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent <Animator> ();
 
    }

    // Update is called once per frame
    void Update()
    {   
        alice = GameObject.Find("Player");
        if (Input.GetKey(KeyCode.S))  {   
            if (((transform.position.x + 4) >= alice.transform.position.x) &&
             ((transform.position.x - 4) <= alice.transform.position.x)) {
                myanim.SetBool("FlowerBloom", true);
            }
        }
    }
}
