using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeAttack : MonoBehaviour {

    public float speed;
    public float randomizer;

    public bool StartAttack = false;
    public bool isCharging = false;
    public bool canCharge = true;

    public GameObject headHolder;
    public GameObject shootHead;
    public GameObject backHead;
    SpriteRenderer backHeadSprite;
    SpriteRenderer headHolderSprite;
    SpriteRenderer shootHeadSprite;
    
    EnemyHeadMovement bodyMovement;

    public GameObject player;

    private float charges;
    private bool teleported;

    void Start() {
        teleported = false;
        bodyMovement = GetComponent<EnemyHeadMovement>();
        charges = 4;
        headHolderSprite = headHolder.GetComponent<SpriteRenderer>();
        shootHeadSprite = shootHead.GetComponent<SpriteRenderer>();
        backHeadSprite = backHead.GetComponent<SpriteRenderer>();
    }


    void Update() {
        
    }

    public IEnumerator ChargeAttack()
    {
        canCharge = false;
        bodyMovement.enabled = true;

        randomizer = Random.Range(0, 2);

        bool newcharge = false;

        int startDirection = (int)Mathf.Floor(Random.Range(-1,1)) == 1 ? 1 : -1;
        for (int i = 0; i < 4; i++)
        {
            if (newcharge)
            {
                var wantedy = player.transform.position.y;
                var newpos = transform.position;
                newpos.y = wantedy;
                transform.position = newpos;
                newcharge = false;
            }
            float wantedx = startDirection == 1 ? 16f : -16f;

            while(true)
            {
                if (startDirection == 1)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;

                    if (transform.position.x > wantedx)
                    {
                        startDirection = -startDirection;
                        newcharge = true;
                        headHolderSprite.flipX = false;
                        shootHeadSprite.flipX = false;
                        backHeadSprite.flipX = false;

                        break;
                    }
                }
                else
                {

                    transform.position -= Vector3.right * speed * Time.deltaTime;

                    if (transform.position.x < wantedx)
                    {
                        startDirection = -startDirection;
                        newcharge = true;
                        headHolderSprite.flipX = true;
                        shootHeadSprite.flipX = true;
                        backHeadSprite.flipX = true;
                        break;
                    }
                }

                yield return new WaitForEndOfFrame();
            }
        }

        var wantedPosition = transform.position;
        wantedPosition.x = -3;
        for(;;)
        {
            transform.position = Vector3.Lerp(transform.position, wantedPosition, 5 * Time.deltaTime);

            if (Vector3.Distance(transform.position, wantedPosition) < 0.5f) break;

            yield return new WaitForEndOfFrame();
        }

        bodyMovement.enabled = true;
        yield return new WaitForSeconds(5);
        canCharge = true;
    }
}
