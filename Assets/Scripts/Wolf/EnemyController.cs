using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


//now lets maks them follow the player

Rigidbody2D rb;
GameObject target;
Player player;


float moveSpeed;
Vector3 directionToTarget;

public bool run=true;
//
private float leftEdge;
 

   public void Start()
    {

    //      target=GameObject.Find("Player");
    //      rb=GetComponent<Rigidbody2D>();
        
    // moveSpeed=Random.Range(1f,2f);
    // }        
    
    }
    public void Update()
    {     
MoveEnemy();        
   }
   //}
    public void MoveEnemy(){

         player=GameObject.Find("Player").GetComponent<Player>();

         target=GameObject.Find("Player");
         rb=GetComponent<Rigidbody2D>();
        
    moveSpeed=Random.Range(1f,2f);

if(run==true){
            if(target!=null){
                    Debug.Log("hello");

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
}

