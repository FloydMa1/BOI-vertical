using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrimstoneAttack : MonoBehaviour {

    private float charge = 0;
    private float minCharge = 0;
    private float maxCharge = 10;
    private float chargeSpeed = 0.5f;
    private float chargeAplier = 1;

    private float fadeTime = 1;
    public GameObject Brimstone;
    private float cooldown = 0f;
    private float attackTime = 2f;
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        int mask = 1 << 8;
        int LayerMask = 1 << mask;

        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        var raycast = Physics2D.Raycast(transform.position, Vector3.right, float.PositiveInfinity, LayerMask);
        lineRenderer.SetPositions(new Vector3[]
            {
                transform.position,
                raycast.point
            });

        SpriteRenderer render = GetComponent<SpriteRenderer>();
        render.color = new Color(1, 1, 1);

        if (Input.GetKey(KeyCode.G) && cooldown <= 0)
        {
            charge = minCharge + chargeAplier * chargeSpeed;
            //Debug.Log("Moan");
            minCharge = charge;
        }
        else
        {
            minCharge = 0;
            charge = minCharge;
            Debug.Log("off");
        }


        if (charge >= 10)
        {
            minCharge = 0;
            //render.color = Color.Lerp(Color.white, Color.red, Time.deltaTime * fadeTime);
            Instantiate(Brimstone, transform.position, Quaternion.identity);
            cooldown = 2.0f;
        }
        

        if (cooldown <= 2f && cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Debug.Log(cooldown);
        Debug.Log(charge);
    }

}
