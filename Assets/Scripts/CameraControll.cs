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
        if (target != null) {
            // default jump force
            Player.jumpforce = 7;

            // update camera size
            camera.orthographicSize = cameraSize;

            // get the last tree of the yello jungle to configure camera movements
            finishTree = GameObject.Find("FinishTree");

            // get the tree that located before spell whole to configure camera movements
            afterSpellTree = GameObject.Find("AfterSpellTree");

            // get the tree that located after spell whole to configure camera movements
            beforeSpellTree = GameObject.Find("BeforeSpellTree");

            // get pink spell object
            pinkSpell = GameObject.Find("PinkSpell");

            // if Alice is in the pink spell area increase the jump force and configure the camera location
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
            // if Alice is out of the pink spell area reset the camera location to default
                if (cameraSize > 5f) {
                    this.cameraSize -= 0.08f;
                    camera.orthographicSize = this.cameraSize;
                } 
            }

            // if Alice is going to enter the blue jungle , change the camera location because of different hights of jungles
            if (target.transform.position.x <= (finishTree.transform.position.x + 5)) {
                if (tempY > (this.startY -4f)) {
                    tempY -= 0.05f;
                }
            }

            // setting the camera to follow Alice's movement on the X-axis
            transform.position = new Vector3(target.transform.position.x , tempY , transform.position.z);
        }
    }
}
