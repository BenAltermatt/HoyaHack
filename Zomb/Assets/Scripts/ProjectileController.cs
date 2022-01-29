using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public int strength;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this will be called upon instantiation and dictate
    // where the bullet heads
    public void fire(float x, float y)
    {
        Vector2 trajectory = new Vector2(x, y);
        trajectory = trajectory.normalized;

        GetComponent<Rigidbody2D>().velocity = trajectory * speed;
    }  

    public int calculateMyAttackValue()
    {
        return strength;
    }
}
