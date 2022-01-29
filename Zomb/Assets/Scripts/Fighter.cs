using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Essentially building our game objecg
    public Rigidbody2D rb;
    public GameObject hitbox;
    public GameObject hurtbox;

    // Stats of the fighter!
    public float speed;
    public int dir;
    public int health;
    public int strength;
    public float swingSpeed;
    public float swingCooldown;
    
    // This is primarily for debugging purposes
    // checks if this fighter is the player
    public bool isPlayer;

    // Tracking melee attacks and cooldown
    private float timeSwung;
    
    const bool debugging = true;

    // Start is called before the first frame update
    void Start()
    {
        timeSwung = Time.time;
        hitbox.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    // 
    void FixedUpdate()
    {
        if(isPlayer) // check if this thing has controls
        {
            move((int) Input.GetAxisRaw("Horizontal"), (int) Input.GetAxisRaw("Vertical"));
            if(Input.GetKey("space"))
            {
                // shout("Space key is being pressed");
                attack();
            }
        }

        afterSwing();
    }

    // the directions in the x and y direction that the object wishes to move
    void move(int x, int y) {
        // direction the character is facing
        if(x != 0) {
            dir = x;
        }

        // 
        Vector2 newV = new Vector2(x, y).normalized;
        rb.velocity = newV * speed;
    }

    // handles attacks based on the weapon being used
    public void attack() {
        swing();
    }

    // melee attack
    public void swing() {
        if(Time.time - timeSwung > swingSpeed && // we arent already in the process of swinging
        Time.time - timeSwung > swingCooldown)   // we arent in cooldown
        {
            // shout("Swinging");
            timeSwung = Time.time; 
            hitbox.GetComponent<BoxCollider2D>().enabled = true; // turn on our hitbox
        }
    }

    // handle the melee attack after bits
    public void afterSwing() {
        //shout("Swing completed: " + (Time.time - timeSwung > swingSpeed));
        //shout("Swing cooldown completed: " + (Time.time - timeSwung > swingCooldown));
        if(Time.time - timeSwung > swingSpeed) // we finished swinging already
            // shout((Time.time - timeSwung) + " time since swung");
            hitbox.GetComponent<BoxCollider2D>().enabled = false; // turn the hitbox off again
    }

    // deals with collisions "inflicted" by other objects
    public void registerCollision(string tag, int AttackValue)
    {
        shout("This object has been hit.");
    }

    // calculates the damage inflicted by this fighter
    public int calculateMyAttackValue() {
        return strength;
    }

    // takes damage based on an attack value
    void takeDamage(int aV) {
        health -= aV;
    }

    // this is for debugging
    void shout(string msg) {
        if(debugging) 
            Debug.Log(msg);
    }
}