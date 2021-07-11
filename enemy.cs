using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : AllEnemy
{
    public Transform leftpoint, rightpoint;
    public float speed;

    Rigidbody2D rb;
    //Collider2D coll;
    //Animator animator;
    bool faceleft = true;
    float leftx , rightx;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collider2D>();
        leftx = leftpoint.position.x;
        rightx =  rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement(){
        if(faceleft){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx){
                transform.localScale = new Vector3(-1, 1, 1);
                faceleft = false;
            }
        }
        else{
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx){
                transform.localScale = new Vector3(1, 1, 1);
                faceleft = true;
            }
        }
    }

    
}
