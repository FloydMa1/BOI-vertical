using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    [SerializeField] float speed;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
