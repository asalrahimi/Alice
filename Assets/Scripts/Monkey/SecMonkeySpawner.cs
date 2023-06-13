using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecMonkeySpawner : MonoBehaviour
{
    //monkey2
    [SerializeField] GameObject[] _objects;
        [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;

    [SerializeField] int _offsetY;

    GameObject _spawnedObject;

    float _randomX;

    float _randomY;

    //public float[] x=new float{-31.75f,-42.82f,-48.67f,-57.11f};
    public float[] x=new float[2];
        public float[] y=new float[2];

    //public float[] y=new float{1.64f,2.01f,1.04f,1.22f};


 private float leftEdge;

   // public float[] X { get => x; set => x = value; }
    //public float[] X1 { get => x; set => x = value; }

    void Start()
    {
                Invoke("Spawn",2f);

        // leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x + 10f;

    }
    

    // Update is called once per frame
    void Update()
     

        {
        //        if (transform.position.x < leftEdge) {
        //     Destroy(gameObject);
        // }   
    }

    // Update is called once per frame
  


    void Spawn(){

            x[0]=-29.4f;
            x[1]=-44.3f;
            //x[2]=-41.16f;
          //  x[3]=-68.88f;
           //x[4]=-58.63f;
            //x[5]=-70.3f;

            y[0]=-0.28f;
            y[1]=0.05f;
           //y[2]=0.07f;
           // y[3]=-1.93f;
           // y[4]=-0.05f;
           //y[5]=-2.8f;



        for(int i=0;i<2;i++){

        int RandomObjectId=Random.Range(0,_objects.Length);
        //Vector2 position=GetRandomCooordinate();

        Vector2 position=new Vector2(x[i],y[i]);

        _spawnedObject=Instantiate(_objects[RandomObjectId],position,Quaternion.identity)as GameObject;

        }


    }
}