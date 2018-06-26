using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector2 speed = new Vector2(0, 0);
    public Vector2 movement = new Vector2(0,0);

    public Rigidbody2D _rigidbody2D;

    Animator anim;
    SpriteRenderer rend;

    private float inputX;
    private float inputY;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        if (GetComponent<Health>().dead == false)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            movement.x = speed.x * inputX;
            movement.y = speed.y * inputY;

            if (inputX > 0) { anim.Play("walkRight"); rend.flipX = false; }
            else if (inputX < 0) { anim.Play("walkRight"); rend.flipX = true; }
            else if (inputY != 0) { anim.Play("walkUp"); }
            else { anim.Play("idle"); }
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = movement;
    }
}
