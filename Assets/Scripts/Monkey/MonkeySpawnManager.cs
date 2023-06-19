using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawnManager : MonoBehaviour
{
    //monkey
    [SerializeField] GameObject[] _objects;
    [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;

    GameObject _spawnedObject;
    float _randomX;
    float _randomY;
    public float[] x = new float[6];
    public float[] y = new float[6];

    AudioSource _AudioPlayer;
    public AudioClip Sound_Scream;
    private float leftEdge;

    void Start()
    {
        _AudioPlayer = GetComponent<AudioSource>();
        Invoke("Spawn" , 2f);
    }
      
    void Spawn()
    {
        x[0]=-17.91f;
        x[1]=-64.93f;
        x[2]=32.19f;
        x[3]=76.31f;
        x[4]=120.19f;

        y[0]=-0.45f;
        y[1]=0.03f;
        y[2]=-0.23f;
        y[3]=-0.23f;
        y[4]=2.26f;

        for(int i=0;i<5;i++){
            int RandomObjectId=Random.Range(0,_objects.Length);
            Vector2 position=new Vector2(x[i],y[i]);
            _spawnedObject = Instantiate(_objects[RandomObjectId],position,Quaternion.identity)as GameObject;

            //playing Monkey sound
            _AudioPlayer.PlayOneShot(Sound_Scream);
        }
    } 
}
