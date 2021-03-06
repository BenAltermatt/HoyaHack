using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxCollide : MonoBehaviour
{
    public BoxCollider2D myBox;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // every time a collision of any kind is detected with another box
    void OnTriggerEnter2D(Collider2D collider) 
    {
        // collect information about what we are hitting
        GameObject otherObject = collider.GetComponent<Transform>().parent.gameObject;

        if(collider.tag == "Hitbox" || collider.tag == "Projectile") // if we are bing hit
        {
            Fighter parentScript = parent.GetComponent<Fighter>(); 
            if(collider.tag == "Hitbox")
            {
                Fighter attackerScript = otherObject.GetComponent<Fighter>(); 
                parentScript.registerCollision(collider.tag, attackerScript.calculateMyAttackValue());
            }
            if(collider.tag == "Projectile")
            {
                ProjectileController attackerScript = otherObject.GetComponent<ProjectileController>();
                parentScript.registerCollision(collider.tag, attackerScript.calculateMyAttackValue());
            }
            
        }
    }

}
