using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
//mushroom 
    [SerializeField] GameObject[] _objects;
        [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;

    [SerializeField] int _offsetY;

    GameObject _spawnedObject;

    float _randomX;

    float _randomY;

    public float[] x=new float[6];
        public float[] y=new float[6];



 private float leftEdge;


    void Start()
    {
                //InvokeRepeating("Spawn",0f,4f);
                Invoke("Spawn",6f);

        // leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x + 10f;

    }
    

    void Update()
     

        {
        //        if (transform.position.x < leftEdge) {
        //     Destroy(gameObject);
        // }   
    }
  


    void Spawn(){

            x[0]=-10.01f;
            x[1]=-23.17f;
            x[2]=-41.16f;
            x[3]=-68.88f;
           x[4]=-58.63f;

            y[0]=-1.78f;
            y[1]=-3.3f;
            y[2]=0.07f;
            y[3]=-1.93f;
            y[4]=-0.05f;



        for(int i=0;i<5;i++){

        int RandomObjectId=Random.Range(0,_objects.Length);
        //Vector2 position=GetRandomCooordinate();

        Vector2 position=new Vector2(x[i],y[i]);

        _spawnedObject=Instantiate(_objects[RandomObjectId],position,Quaternion.identity)as GameObject;

        }

    

    }

}
