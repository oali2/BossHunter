using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour {

    public int startingHealth = 100;
    public int currHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    //public AudioClip deathClip;

    //Animator anim; //if used, more code needed
    //AudioSource enemyAudio;
    //ParticleSystem hitParticles; //if used, more code needed
    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();

        currHealth = startingHealth;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // if (isSinking)
            //transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
	}

    void FixedUpdate()
    {
        if (isSinking)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -sinkSpeed, 0));
        }
    }
    //makes enemy take damage
    public void TakeDamage (int amount)
    {
        if (isDead)
            return;
        //enemyAudio.Play();
        currHealth -= amount;

        if (currHealth <= 0) {
            Death();
        }

    }
    //handles death, sound/animation.
    void Death()
    {
        isDead = true;

        boxCollider.isTrigger = true;

        //anim.SetTrigger("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();

        StartSinking();
    }
    //makes enemy character start sinking
    public void StartSinking()
    {
        //GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        //GetComponent<Rigidbody>().isKinematic = true; //find rigidbody and make it kinematic

        isSinking = true; //enemy will now sink

        Destroy(gameObject, 4f); //will destroy after 2 seconds
    }
}
