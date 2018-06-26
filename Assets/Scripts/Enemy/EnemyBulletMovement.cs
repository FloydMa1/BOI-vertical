using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour {

    Rigidbody2D riegid;
    public float speeed;
    Animator anim;
    private bool Destroy = false;

	void Start () {
        riegid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        var a = transform.eulerAngles;
        a.z += Random.Range(0, 360);
        transform.eulerAngles = a;
	}
	

	void Update () {
        if(!Destroy)
        transform.position += transform.right * speeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Player")
        {
            anim.SetBool("Destroy", true);
            Destroy = true;
            Destroy(gameObject, 1f);
        }
    }
}
