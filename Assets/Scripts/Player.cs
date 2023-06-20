using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  Rigidbody2D myRig;
  Animator myanim;
  public bool Ground;
  AudioSource _AudioPlayer;
  public AudioClip Sound_Singing;
  public int maxHealth = 100;
  public int currentHealth;
  private Player player;
  public  static float jumpforce = 7;
  public AudioClip Sound_jump;
	public HealthBar healthBar;
  public AudioClip Sound_Damage;
  
  //magic
  public ProjectalBehavior projectalprefabs;
  public ProjectalBehavior2 projectalprefabsRight;
  public Transform launchOfset;

  //Cahracter direction
  bool Right,left=true;


  public static Player Instance;

  private void Awake() 
  {
    if (Instance == null) {
      Instance = this;
    }
  }

  void Start()
  {
    myRig = GetComponent <Rigidbody2D> ();
    myanim = GetComponent <Animator> ();
    _AudioPlayer = GetComponent <AudioSource> ();
   currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
    player = FindObjectOfType<Player>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.D)) {
      transform.Translate(new Vector2(3* Time.deltaTime, 0)); //moving Player
      transform.localScale = new Vector3 (-0.62f, transform.localScale.y, transform.localScale.z); //Direction of player
      myanim.SetBool("Run", true);
      //character direction
      Right=true;
      left=false;  
    }

    if (Input.GetKey(KeyCode.A)) {
      transform.Translate(new Vector2(-3* Time.deltaTime, 0)); //moving Player
      transform.localScale = new Vector3 (0.62f, transform.localScale.y, transform.localScale.z); //Direction of player
      myanim.SetBool("Run", true);
      //character direction
      left=true;
      Right=false;
    }

    if (Input.GetKey(KeyCode.S)) {
      _AudioPlayer.PlayOneShot(Sound_Singing);//Alice Singing a Song
    }


    //Enable the mode of standing
    if ((!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.A))) {
      myanim.SetBool("Run", false);
    }


      //Jumping the Player and Runing the animation of that
    if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(myRig.velocity.y) < 0.001f) {            
      myRig.AddForce(new Vector2(0,jumpforce),ForceMode2D.Impulse);
      myanim.Play("Jump");
      _AudioPlayer.PlayOneShot(Sound_jump);
      
    }
      
    //shooting magic
    if (Right == true) {
      if (Input.GetKeyDown(KeyCode.F)) {
        Instantiate(projectalprefabsRight,position: launchOfset.position,rotation: transform.rotation);
      }
    }

    if (left == true) {
      if(Input.GetKeyDown(KeyCode.F)){
        Instantiate(projectalprefabs,position: launchOfset.position,rotation: transform.rotation);
      }
    }

    //GameOverCode
    if (currentHealth == 0)
    {
      player.gameObject.SetActive(false);
      SceneManager.LoadSceneAsync(1);
  }
  }


  void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
    _AudioPlayer.PlayOneShot(Sound_Damage);

	}

  public void SetCurrentHealth(int CurrentHealth)
  {
    this.currentHealth = CurrentHealth;
		healthBar.SetHealth(CurrentHealth);
  }



   

  //collision
  private void OnCollisionEnter2D(Collision2D collision){
    if(collision.transform.tag == "obstacle"){
      TakeDamage(5);
    } else if (collision.transform.tag == "SpellGlass") {
      SpellGlass.Collect(collision);
    }
  }

}
    
