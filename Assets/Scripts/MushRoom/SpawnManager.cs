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

    public float[] x = new float[13];
    public float[] y = new float[13];
    private float leftEdge;

    void Start()
    {
        Invoke("Spawn",7f);
    }
    
    void Spawn(){
        x[0]=-1f;
        x[1]=-41.16f;
        x[2]=156.51f;
        x[3]=18.25f;
        x[4]=105f;
        x[5]=55.01f;

        y[0]=-1.78f;
        y[1]=0.07f;
        y[2]=0.76f;
        y[3]=-3.1f;
        y[4]=-0.22f;
        y[5]=-2.88f;

        for(int i = 0;i < 5;i++){
            int RandomObjectId=Random.Range(0,_objects.Length);
            Vector2 position=new Vector2(x[i],y[i]);
            _spawnedObject=Instantiate(_objects[RandomObjectId],position,Quaternion.identity)as GameObject;
        }
    }
}
