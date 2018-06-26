using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinalStage : MonoBehaviour {

    public GameObject head;
    public GameObject heaHead;
    public GameObject[] upperBody;
    public GameObject spriteHolder;
    SpriteRenderer renderer;
    public Sprite feetMoving;

    Rigidbody2D rigid;
    
    private float step;

    private bool couritineStarted = false;
    public float speed;
    public Transform player;

    EnemyHealth health;
    EnemyBodyMovement bodyMove;

    void Start () {
        bodyMove = GetComponent<EnemyBodyMovement>();
        health = head.GetComponent<EnemyHealth>();
        renderer = spriteHolder.GetComponent<SpriteRenderer>();
        step = speed * Time.deltaTime;
        rigid = GetComponent<Rigidbody2D>();
    }


    public IEnumerator DetachAndAttack()
    {
        renderer.sprite = feetMoving;
        heaHead.SetActive(false);
        for (int i = 0; i < upperBody.Length; i++)
        {
            Destroy(upperBody[i]);
        }

        bodyMove.enabled = false;

        while(health.notDead == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "FriendlyBullet")
        {
            health.healthPoints--;
        }
    }
}
