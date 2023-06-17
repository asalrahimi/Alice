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

    public float[] x=new float[13];
        public float[] y=new float[13];



 private float leftEdge;


    void Start()
    {
                Invoke("Spawn",7f);


    }
    

    void Update()
     

        {
      
    }
  


    void Spawn(){

            x[0]=-1f;
            x[1]=-41.16f;
            x[2]=168.36f;
           x[3]=152.7f;
           x[4]=18.25f;
           x[5]=99.59f;
           x[6]=55.01f;

            y[0]=-1.78f;
            y[1]=0.07f;
            y[2]=1.3f;
            y[3]=0.76f;
            y[4]=-3.1f;
            y[5]=-0.07f;
            y[6]=-2.88f;






        for(int i=0;i<7;i++){

        int RandomObjectId=Random.Range(0,_objects.Length);

        Vector2 position=new Vector2(x[i],y[i]);

        _spawnedObject=Instantiate(_objects[RandomObjectId],position,Quaternion.identity)as GameObject;

        }

    

    }

}
