using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour {

    public GameObject Head;
    public GameObject Middle;
    public GameObject Player;

    public bool playerDead = false;

    Vector2 enemyVector;
    Vector2 playerVector;

    float angle;

    EnemyShootAttack shoot;
    EnemyBrimstoneAttack brimstone;
    EnemyChargeAttack charge;
    EnemyPopUpAttack popUp;

	void Start () {
        brimstone = Head.GetComponent<EnemyBrimstoneAttack>();
        charge = Head.GetComponent<EnemyChargeAttack>();
        popUp = Head.GetComponent<EnemyPopUpAttack>();
        shoot = Head.GetComponent<EnemyShootAttack>();

        enemyVector = Vector2.up;
        angle = 0.0f;
	}
	

	void Update () {
        enemyVector = Middle.transform.position;
        playerVector = Player.transform.position;
        angle = Vector2.Angle(enemyVector, playerVector);
        if(!playerDead)
        StartCoroutine(Initiate());
	}

     void OnGUI()
    {
        GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + angle);
    }
    
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(checkAttack());
    }

    IEnumerator checkAttack()
    {
        
        if (angle > 0 && angle < 90 && popUp.canPopUp == true)
        {
            popUp.StartCoroutine(popUp.PopUpAttack());
            charge.canCharge = false;
        }
        if (angle > 91 && angle < 110 && charge.canCharge == true)
        {
            charge.StartCoroutine(charge.ChargeAttack());
            popUp.canPopUp = false;
            yield return new WaitForSeconds(6);
            popUp.canPopUp = true;
        }
        if (angle > 111 && angle > 130 && popUp.canPopUp == true && charge.canCharge == true && shoot.canShoot == true)
        {
            shoot.StartCoroutine(shoot.Shoot());
            charge.canCharge = false;
            popUp.canPopUp = false;
            yield return new WaitForSeconds(2);
            charge.canCharge = true;
            popUp.canPopUp = true;
        }
        if (angle > 91 && angle < 130 && charge.canCharge == true)
        {
            charge.StartCoroutine(charge.ChargeAttack());
            popUp.canPopUp = false;
            yield return new WaitForSeconds(6);
            popUp.canPopUp = true;
        }
        

    }
    
}
