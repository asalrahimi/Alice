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
    public AudioClip Sound_jump;
    

	public HealthBar healthBar;
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
     
    if(Input.GetKey(KeyCode.D))
        {
           transform.Translate(new Vector2(3* Time.deltaTime, 0)); //moving Player
           transform.localScale = new Vector3 (-0.7088f, transform.localScale.y, transform.localScale.z); //Direction of player
            myanim.SetBool("Run", true);
            
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-3* Time.deltaTime, 0)); //moving Player
            transform.localScale = new Vector3 (0.7088f, transform.localScale.y, transform.localScale.z); //Direction of player
             myanim.SetBool("Run", true);
            
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
          myRig.velocity = new Vector2(myRig.velocity.x, 7);
          myanim.Play("Jump");
          _AudioPlayer.PlayOneShot(Sound_jump);
          
        }

        //GameOverCode
        if(currentHealth==0)
        {
        player.gameObject.SetActive(false);
        }



    void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
        
    }
}
