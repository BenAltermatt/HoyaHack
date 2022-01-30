using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    /**
    * Fields
    * ___________________________________________________________________________________
    **/
    // Essentially building our game objecg
    public Transform t;
    public Rigidbody2D rb;
    public GameObject hitbox;
    public GameObject hurtbox;
    public GameObject projectile;
    public GlobalScript globalVars;
    public Camera cam;
    public Animator animator;

    // Stats of the fighter!
    public float speed;
    public int dir;
    public int health;
    public int strength;
    public float swingSpeed;
    public float swingCooldown;
    public float shootCooldown;
    public float shootSpeed;
    public int State_Val;
    public bool moving;
    public bool shooting;
    public bool swinging;
    public float accuracy;

    // This is primarily for debugging purposes
    // checks if this fighter is the player
    public bool isPlayer;

    // Tracking melee attacks and cooldown
    private float timeSwung;

    //Working with shooting now
    private float timeShot;

    // this is the weapon the player is currently carrying
    public GlobalScript.Weapon currentWeapon;


    const bool debugging = true;

    /**
    * Built in Methods
    * ___________________________________________________________________________________
    **/

    // Start is called before the first frame update
    void Start()
    {
        globalVars = GetComponent<GlobalScript>();
        currentWeapon = new GlobalScript.HeavyMachineGun();
        cam = Camera.main;
        timeSwung = Time.time;
        timeShot = Time.time;
        hitbox.GetComponent<BoxCollider2D>().enabled = false;
        moving = false;
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            cam.transform.position = new Vector3(t.position.x, t.position.y, cam.transform.position.z);
        }
    }

    // 
    void FixedUpdate()
    {
        if (health <= 0) // dead
        {
            die();
        }

        if(isPlayer) // check if this thing has controls
        {
            move((int) Input.GetAxisRaw("Horizontal"), (int) Input.GetAxisRaw("Vertical"));
            if(Input.GetKey("space"))
            {
                // shout("Space key is being pressed");
                attack();
            }
        }

        updateState();
        afterSwing();
        afterShoot();
        weaponUpdate();
    }

    /**
    * Updating / Maitenance Methods
    * ___________________________________________________________________________________
    **/
    // calculates the damage inflicted by this fighter
    public int calculateMyAttackValue() {
        return strength;
    }

    // deals with collisions "inflicted" by other objects
    public void registerCollision(string tag, int AttackValue)
    {
        shout("This object has been hit.");
        takeDamage(AttackValue);
    }

    // handle the melee attack after bits
    public void afterSwing() {

        if(Time.time - timeSwung > swingSpeed) // we finished swinging already
        {
            // shout((Time.time - timeSwung) + " time since swung");
            hitbox.GetComponent<BoxCollider2D>().enabled = false; // turn the hitbox off again
            swinging = false;
        }
    }

    // handle the shooting after bits
    public void afterShoot() {
        if(Time.time - timeShot > shootSpeed)
            shooting = false;

    }

    // Turns on the hitbox and slightly moves so its detected
    void turnOnHitbox()
    {
        hitbox.GetComponent<BoxCollider2D>().enabled = true;
        t.position = new Vector2 (t.position.x+0.000001f, t.position.y);
    }

    // update direction when the player turns
    // visually and hitbox-wise
    void updateDir(int direction) 
    {
        hitbox.GetComponent<BoxCollider2D>().offset = new Vector2(direction, 0);
    }

    void updateState()
    {
        int newState = 0;
        if(currentWeapon != null) // get the weapon id
        {
            newState += 100 * currentWeapon.id;
        }
        
        if(moving)
        {
            State_Val += 20;
        }
        else if(swinging && currentWeapon == null) // punching
        {
            State_Val += 30;
        }
        else if(swinging && currentWeapon != null)
        {
            State_Val += 40;
        }
        else if(shooting) {
            State_Val += 50;
        }
        else {
            State_Val += 10;
        }

        newState += dir;
        
        animator.SetInteger("StateVal", State_Val);
    }

    void weaponUpdate() 
    {
        if(currentWeapon != null)
        {
            strength = currentWeapon.damage;
            if(currentWeapon.longRange) // gun
            {
                shootSpeed = currentWeapon.useSpeed;
                shootCooldown = currentWeapon.useCoolDown;
            }
            else
            {
                swingSpeed = currentWeapon.useSpeed;
                swingCooldown = currentWeapon.useCoolDown;
            }
        }
        else
        {
            swingSpeed = .5f;
            swingCooldown = .75f;
        }
    }

    /**
    * Action methods
    * ___________________________________________________________________________________
    **/

    // handles attacks based on the weapon being used
    public void attack() {

        Debug.Log(currentWeapon.name);
        if(currentWeapon.longRange)
        {
            shoot(dir, Random.Range(-accuracy / 2, accuracy / 2));
            Debug.Log("Shooted");
        }
        else
        {
            swing();
        }
        
    }

    // melee attack
    public void swing() {
        if(Time.time - timeSwung > swingSpeed && // we arent already in the process of swinging
        Time.time - timeSwung > swingCooldown)   // we arent in cooldown
        {
            timeSwung = Time.time; 
            turnOnHitbox(); // turn on our hitbox
            swinging = true;
        }
    }

    // this deals with the intricacies of shooting
    void shoot(float x, float y)
    {
        if(Time.time - timeShot > shootCooldown &&
        Time.time - timeShot > shootSpeed)
        {
            timeShot = Time.time;
            GameObject shot = Instantiate(projectile, t);
            shot.GetComponent<ProjectileController>().fire(x, y);
            shooting = true;
        }
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

    // the directions in the x and y direction that the object wishes to move
    void move(int x, int y) {
        if(!shooting && !swinging)
        {
            // direction the character is facing
            if(x != 0) {
                dir = x;
            }

            // 
            Vector2 newV = new Vector2(x, y).normalized;
            rb.velocity = newV * speed;

            updateDir(dir);
            if(rb.velocity.magnitude != 0f)
                moving = true;
            else
                moving = false;
        }
    }

    // handles when the Fighter's health is below zero
    void die() 
    {
        if(isPlayer) // handle game over
        {

        }
        else
        {
            // play dying animation (?)
            // disappear
            Destroy(gameObject);
        }
    }

}