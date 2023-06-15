using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectalBehavior : MonoBehaviour
{
    public float speed=4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position-=transform.right*Time.deltaTime*speed;
         Destroy(gameObject,1.0f);

    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("obstacle")) {
            Debug.Log("hit detected");
            Destroy(gameObject);
        }
    }
}
