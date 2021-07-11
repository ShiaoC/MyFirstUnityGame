using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBird : AllEnemy
{
    public Transform toppoint, bottompoint;
    public float speed;

    Rigidbody2D rb;
    //Collider2D coll;
    //Animator animator;
    bool facetop = true;
    float topy , bottomy;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collider2D>();
        topy = toppoint.position.y;
        bottomy =  bottompoint.position.y;
        Destroy(toppoint.gameObject);
        Destroy(bottompoint.gameObject);
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement(){
        if(facetop){
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > topy){
                //transform.localScale = new Vector3(-1, 1, 1);
                facetop = false;
            }
        }
        else{
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < bottomy){
                //transform.localScale = new Vector3(1, 1, 1);
                facetop = true;
            }
        }
    }
}
