using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // Start is called before the first frame update
    Rigidbody2D myRig;
    Animator myanim;
    public bool Ground;
    AudioSource _AudioPlayer;
    public AudioClip Sound_Singing;
    public int maxHealth = 100;
	public int currentHealth;
    private Player player;
    public float jumpforce=5;


    //magic
    
    public ProjectalBehavior projectalprefabs;
     public ProjectalBehavior2 projectalprefabsRight;
    public Transform launchOfset;

    //Cahracter direction
    bool Right,left=true;
    public AudioClip Sound_jump;
    

	public HealthBar healthBar;


  //wolf start
  EnemyController enemyController;


    void Start()
    {
        myRig = GetComponent <Rigidbody2D> ();
        myanim = GetComponent <Animator> ();
        _AudioPlayer = GetComponent <AudioSource> ();
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        player = FindObjectOfType<Player>();

          //wolf start
enemyController=GameObject.Find("GameSpawner").GetComponent<EnemyController>();


    }

    // Update is called once per frame
    void Update()
    {
     
    if(Input.GetKey(KeyCode.D))
        {
           transform.Translate(new Vector2(3* Time.deltaTime, 0)); //moving Player
           transform.localScale = new Vector3 (-0.7088f, transform.localScale.y, transform.localScale.z); //Direction of player
            myanim.SetBool("Run", true);
            //character direction 
            Right=true;
            left=false;
            
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-3* Time.deltaTime, 0)); //moving Player
            transform.localScale = new Vector3 (0.7088f, transform.localScale.y, transform.localScale.z); //Direction of player
             myanim.SetBool("Run", true);
            //character direction 
            Right=false;
            left=true;
            
        }

        if(Input.GetKey(KeyCode.S))
        {
           _AudioPlayer.PlayOneShot(Sound_Singing);//Alice Singing a Song
        }


        //Enable the mode of standing
        if((!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.A)))
        {
        myanim.SetBool("Run", false);
        }


        //Jumping the Player and Runing the animation of that
        if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(myRig.velocity.y)<0.001f)
        {            
          myRig.AddForce(new Vector2(0,jumpforce),ForceMode2D.Impulse);
          myanim.Play("Jump");
          _AudioPlayer.PlayOneShot(Sound_jump);

          //TakeDamage(5);
        }
        //shooting magic
        if(Right==true){
          if(Input.GetButtonDown("Fire1")){
            Instantiate(projectalprefabsRight,position: launchOfset.position,rotation: transform.rotation);
          }
        }
        if(left==true){
          if(Input.GetButtonDown("Fire1")){
            Instantiate(projectalprefabs,position: launchOfset.position,rotation: transform.rotation);
          }
        }
        

        //GameOverCode
        if(currentHealth==0)
        {
        player.gameObject.SetActive(false);
        }
    }


    void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

    



//collision
private void OnCollisionEnter2D(Collision2D collision){
  if(collision.transform.tag=="obstacle"){
    Debug.Log("oops!");
    TakeDamage(5);
  }
else if(collision.transform.tag=="spawnPoint"){
    //Debug.Log("wolfs are comming!");
        enemyController.run=true;

        Debug.Log(enemyController.run);

    //enemyController.run=true;
    enemyController.Start();
  enemyController.Update();
  }

}

    }
    
