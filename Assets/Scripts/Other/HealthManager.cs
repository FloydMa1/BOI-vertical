using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    //full hearths
    [SerializeField] Image h1;
    [SerializeField] Image h2;
    [SerializeField] Image h3;
    //empty and half hearts
    [SerializeField] Sprite empty_hearth;
    [SerializeField] Sprite half_hearth;

    [SerializeField] GameObject player;

    Health playerHealthScript;

    int playerHealth;

    // Use this for initialization
    void Start () {
        playerHealthScript = player.GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        playerHealth = playerHealthScript.healthPoints;
        switch (playerHealth)
        {
            case 5:
                h3.sprite = half_hearth;
                break;
            case 4:
                h3.sprite = empty_hearth;
                break;
            case 3:
                h2.sprite = half_hearth;
                break;
            case 2:
                h2.sprite = empty_hearth;
                break;
            case 1:
                h1.sprite = half_hearth;
                break;
            case 0:
                h1.sprite = empty_hearth;
                break;
        }
    }
}
