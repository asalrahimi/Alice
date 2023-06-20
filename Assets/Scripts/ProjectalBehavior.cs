using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectalBehavior : MonoBehaviour
{
    
    public float speed = 4.5f;
    private static int spell;
    public static int Spell {
        get 
        {
            if (spell == null) {
                return 0;
            } else {
                return spell;
            }
        } 
        set 
        {
            if (value == null) {
                spell = 0;
            } else {
                if (value > 3) {
                    spell = 3;
                } else if (value < 0) {
                    spell = 0;
                } else {
                    spell = value;
                }
            }
        }
    }

    void Start()
    {
        spell = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * speed;
        Destroy(gameObject,1.0f);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("obstacle")) {
            Destroy(gameObject);
           

        }
    }
    
}
