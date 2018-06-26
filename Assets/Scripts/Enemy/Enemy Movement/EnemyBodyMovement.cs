using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyMovement : MonoBehaviour {

    public Transform nextBodyPart;
    public float distanceToLeader = 1;

    private void Start()
    {
    }

    private void Update()
    {

        var dir = nextBodyPart.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.Rotate(Vector3.left * Time.deltaTime);

        var dist = Vector3.Distance(nextBodyPart.position, transform.position);

        if (dist > distanceToLeader)
        {
            var moveDist = dist - distanceToLeader;
            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * moveDist;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * moveDist;

            var newPos = new Vector3(x, y, 0f) + transform.position;
            transform.position = newPos;
        }
    }

}
