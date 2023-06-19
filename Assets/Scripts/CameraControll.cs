using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{


    // Start is called before the first frame update
    public Transform target;
    private GameObject finishTree , afterSpellTree , beforeSpellTree , pinkSpell;
    public float startY , tempY , cameraSize;
    public Camera camera;

    void Start() {
        startY =  transform.position.y ;
        camera = GetComponent<Camera>();
        tempY = this.startY;
        cameraSize = 5f;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (target != null){
            Player.jumpforce = 7;
            camera.orthographicSize = cameraSize;
            finishTree = GameObject.Find("FinishTree");
            afterSpellTree = GameObject.Find("AfterSpellTree");
            beforeSpellTree = GameObject.Find("BeforeSpellTree");
            pinkSpell = GameObject.Find("PinkSpell");
            if ((target.transform.position.x <= (beforeSpellTree.transform.position.x + 5)) && (target.transform.position.x >= (afterSpellTree.transform.position.x))) {                
                Player.jumpforce += 5;
                if (tempY > (this.startY-3.5f)) {
                tempY -= 0.05f;
                }
                if (cameraSize < 6.9f) {
                    this.cameraSize += 0.1f;
                    camera.orthographicSize = this.cameraSize;
                } 
            } else {
                if (cameraSize > 5f) {
                    this.cameraSize -= 0.08f;
                    camera.orthographicSize = this.cameraSize;
                } 
            }

            if (target.transform.position.x <= (finishTree.transform.position.x + 5)) {
                if (tempY > (this.startY -4f)) {
                    tempY -= 0.05f;
                }
            }
            transform.position = new Vector3(target.transform.position.x , tempY , transform.position.z);
        }
    }
}
