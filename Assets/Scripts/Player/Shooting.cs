using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Rigidbody2D Projectile;

    private bool canShoot;

    [SerializeField] float fireRate;

    [SerializeField] GameObject shootpointUpDown1;
    [SerializeField] GameObject shootpointUpDown2;
    [SerializeField] GameObject shootpointLeftRight1;
    [SerializeField] GameObject shootpointLeftRight2;
    [SerializeField] GameObject head;

    ChangeSprites headSprite;

    private int switchShootPoint = 1;

    private void Start()
    {
        canShoot = true;
        headSprite = head.GetComponent<ChangeSprites>();
    }

    private void Update()
    {
        Shoot(); 
    }

    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey("right"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
                
                switch (switchShootPoint)
                {
                    case 1:
                        Rigidbody2D projectileClone1 = (Rigidbody2D)Instantiate(Projectile, shootpointLeftRight1.transform.position, shootpointLeftRight1.transform.rotation);
                        switchShootPoint = 2;
                        break;
                    case 2:
                        Rigidbody2D projectileClone2 = (Rigidbody2D)Instantiate(Projectile, shootpointLeftRight2.transform.position, shootpointLeftRight2.transform.rotation);
                        switchShootPoint = 1;
                        break;
                }

                headSprite.ShootRight();
                canShoot = false;

            }
            else if (Input.GetKey("left"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                switch (switchShootPoint)
                {
                    case 1:
                        Rigidbody2D projectileClone1 = (Rigidbody2D)Instantiate(Projectile, shootpointLeftRight1.transform.position, shootpointLeftRight1.transform.rotation);
                        switchShootPoint = 2;
                        break;
                    case 2:
                        Rigidbody2D projectileClone2 = (Rigidbody2D)Instantiate(Projectile, shootpointLeftRight2.transform.position, shootpointLeftRight2.transform.rotation);
                        switchShootPoint = 1;
                        break;
                }

                headSprite.ShootLeft();
                canShoot = false;
            }
            else if (Input.GetKey("up"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                switch (switchShootPoint)
                {
                    case 1:
                        Rigidbody2D projectileClone1 = (Rigidbody2D)Instantiate(Projectile, shootpointUpDown1.transform.position, shootpointUpDown1.transform.rotation);
                        switchShootPoint = 2;
                        break;
                    case 2:
                        Rigidbody2D projectileClone2 = (Rigidbody2D)Instantiate(Projectile, shootpointUpDown2.transform.position, shootpointUpDown2.transform.rotation);
                        switchShootPoint = 1;
                        break;
                }

                headSprite.ShootUp();
                canShoot = false;
            }
            else if (Input.GetKey("down"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                switch (switchShootPoint)
                {
                    case 1:
                        Rigidbody2D projectileClone1 = (Rigidbody2D)Instantiate(Projectile, shootpointUpDown1.transform.position, shootpointUpDown1.transform.rotation);
                        switchShootPoint = 2;
                        break;
                    case 2:
                        Rigidbody2D projectileClone2 = (Rigidbody2D)Instantiate(Projectile, shootpointUpDown2.transform.position, shootpointUpDown2.transform.rotation);
                        switchShootPoint = 1;
                        break;
                }

                headSprite.ShootDown();
                canShoot = false;
            }

            StartCoroutine(WaitTillShoot());
        }
    }

    IEnumerator WaitTillShoot()
    {
        if(canShoot == false)
        {
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }
}
