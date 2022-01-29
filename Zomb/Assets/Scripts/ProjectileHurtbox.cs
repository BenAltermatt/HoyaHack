using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHurtbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        // collect information about what we are hitting
        GameObject otherObject = collider.GetComponent<Transform>().parent.gameObject;

        if(collider.tag == "Hurtbox" && otherObject.tag != "Player") // if we are bing hit and not by ourselves
        {   
            Debug.Log("AHHHHHHHHHHHHH");
            Destroy(GetComponent<Transform>().parent.gameObject);// deal with taking damage
        }
    }
}
