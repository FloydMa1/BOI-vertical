using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNeckMovement : MonoBehaviour {

    public Transform Leader;
    public float distanceToLeader;

    private void Update()
    {
        var dir = Leader.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(Vector3.left * Time.deltaTime);

        var dist = Vector3.Distance(Leader.position, transform.position);

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
