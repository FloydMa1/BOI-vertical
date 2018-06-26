using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float destroyTimer;
    GameObject player;

    Movement movementScript;
    Animator anim;

    private bool Destroy = false;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private Vector2 playerVelocity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        if(!Destroy)
        StartCoroutine(DestroyBullet());

        rb.gravityScale = 0;
        movementScript = player.GetComponent<Movement>();
        playerVelocity = movementScript.movement;
    }

    private void FixedUpdate()
    {
        if (!Destroy)
        {
            Vector2 velocity = transform.up * speed * Time.fixedDeltaTime;
            velocity += playerVelocity / 100;
            rb.MovePosition(rb.position + velocity);
        }
        
    }

    IEnumerator DestroyBullet()
    {
        anim.SetBool("Destroy", true);
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            Destroy = true;
            anim.SetBool("Destroy", true);
            Destroy(gameObject, 0.1f);
        }
    }
}
