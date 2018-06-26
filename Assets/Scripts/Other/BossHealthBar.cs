using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    [SerializeField] public Image img;
    [SerializeField] public GameObject bossObject;


    private float eHealth;
    public EnemyHealth bossHP;

    private void Start()
    {
        bossHP = bossObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update ()
    {
        eHealth = bossHP.ReturnHealth();
        
        img.fillAmount = eHealth / 100;
        Debug.Log("BossHealth: " + eHealth);
    }
}
