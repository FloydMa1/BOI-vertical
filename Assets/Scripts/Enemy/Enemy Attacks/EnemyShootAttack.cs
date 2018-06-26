using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAttack : MonoBehaviour {

    public Transform Player;
    public GameObject enemyBullet;
    public GameObject Head;
    public float amountOfBulletsSpawn;
    public bool canShoot = true;

	void Update () {
	}

    public IEnumerator Shoot()
    {
        canShoot = false;
        float direction = Random.Range(0, 180);
        for (int i = 0; i < amountOfBulletsSpawn; i++)
        {
            Instantiate(enemyBullet, Head.transform.position, Quaternion.Euler(0, 0, direction));
        }
        yield return new WaitForSeconds(2);
        canShoot = true;
    }
}
