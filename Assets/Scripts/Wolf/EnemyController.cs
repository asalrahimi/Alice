using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

//now lets maks them follow the player

Rigidbody2D rb;
GameObject target;

float moveSpeed;
Vector3 directionToTarget;


    void Start()
    {
        target=GameObject.Find("Player");
        rb=GetComponent<Rigidbody2D>();
        
    moveSpeed=Random.Range(1f,3f);
    //moveSpeed=10000000000f;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        
    }
    void MoveEnemy(){
        if(target!=null){
            directionToTarget=(target.transform.position-transform.position).normalized;
            rb.velocity=new Vector2(directionToTarget.x*moveSpeed,directionToTarget.y*moveSpeed);

        // transform.position+=Vector3.left*moveSpeed*Time.deltaTime;
        transform.position +=Vector3.right*Time.deltaTime*2;


        }
        else{
            rb.velocity=Vector3.zero;
        }
    }
}
