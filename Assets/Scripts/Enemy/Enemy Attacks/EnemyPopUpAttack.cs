using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPopUpAttack : MonoBehaviour {
    //-3.05

    private float maxWidth = 7.05f;
    private float minWidth = -7.05f;
    private float maxHeight = 3;
    private float minHeight = -3;

    public bool StartAttack = false;
    public bool canPopUp = true;

    public EnemyBodyMovement[] bodyMove;
    public GameObject[] body;
    public GameObject popUpPart;

    public GameObject player;
    public GameObject Head;
    public GameObject otherHead;
    public GameObject upperBody;
    public GameObject lowerBody;
    public GameObject fullBody;

    public GameObject resetPos;
    Animator anim;

    public float popTimes;

    [SerializeField] Transform target;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] GameObject shootPoint;
    [SerializeField] int amountBulletsSpawn;

    [SerializeField] float minRange;
    [SerializeField] float maxRange;

    void Start () {
        //body = GameObject.FindGameObjectsWithTag("body");
        anim = shootPoint.GetComponent<Animator>();
        bodyMove = new EnemyBodyMovement[body.Length];
        for (int i = 0; i < body.Length; i++)
        {
            bodyMove[i] = body[i].GetComponent<EnemyBodyMovement>();
        }
    }
	
	void Update () {
        //gameObject.transform.Rotate(new Vector3(0, 0, 0));
        enemyBullet.transform.LookAt(target);
    }

     public IEnumerator PopUpAttack()
    {
        canPopUp = false;

        for (int i = 0; i < body.Length; i++)
        {
            bodyMove[i].distanceToLeader = 0;
        }

        yield return new WaitForSeconds(1);

        upperBody.SetActive(false);
        lowerBody.SetActive(false);
        Head.SetActive(false);

        for (int i = 0; i < popTimes; i++)
        {
            yield return new WaitForSeconds(2);
            Teleport();
            popUpPart.SetActive(true);
            anim.SetBool("popUp", true);
            yield return new WaitForSeconds(1);
            Shoot();
            yield return new WaitForSeconds(4);
            popUpPart.SetActive(false);
            anim.SetBool("popUp", false);
        }
        StartAttack = false;
        StartCoroutine(ResetAttack());
        yield return new WaitForSeconds(5);
        canPopUp = true;
        
    }

    void Teleport()
    {
        var randomx = Random.Range(minWidth, maxWidth);
        var randomy = Random.Range(minHeight, maxHeight);

        Vector3 newPos = new Vector3(randomx, randomy);
        upperBody.transform.position = newPos;
        lowerBody.transform.position = newPos;
        fullBody.transform.position = newPos;
    }

     IEnumerator ResetAttack()
    {
        for (int i = 0; i < body.Length; i++)
        {
            body[i].transform.position = resetPos.transform.position;
        }
        otherHead.transform.position = resetPos.transform.position;
        for (int i = 0; i < body.Length; i++)
        {
            bodyMove[i].distanceToLeader = 1;
        }

        var wantedPosition = transform.position;
        wantedPosition.x = -3;
        wantedPosition.y = resetPos.transform.position.y;
        for (;;)
        {
            transform.position = Vector3.Lerp(transform.position, wantedPosition, 5 * Time.deltaTime);

            if (Vector3.Distance(transform.position, wantedPosition) < 0.5f) break;

            yield return new WaitForEndOfFrame();
        }

        upperBody.SetActive(true);
        lowerBody.SetActive(true);
        Head.SetActive(true);
    }

    //Shoot() is made by Joey Kossen and Floyd!
    public void Shoot()
    {
        float direction = Random.Range(0, 360);
        //shootPoint.transform.LookAt(target);
        for (int i = 0; i < amountBulletsSpawn; i++)
        {
            Instantiate(enemyBullet, shootPoint.transform.position, Quaternion.Euler(0, 0, direction));
        }
    }
}
