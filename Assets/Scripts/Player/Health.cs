using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] Sprite hurtSprite;
    [SerializeField] Sprite normalSprite;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject gameUI;

    EnemyAttackController attContlr;

    public int healthPoints;
    private int startHP = 6;

    private bool vulnerable = true;
    public bool dead = false;

    public GameObject head;
    public GameObject middle;

    Animator anim;

	// Use this for initialization
	void Start () {
        healthPoints = startHP;
        anim = GetComponent<Animator>();
        head.SetActive(true);
        attContlr = middle.GetComponent<EnemyAttackController>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(healthPoints);
        if(healthPoints <= 0 && dead == false)
        {
            Death();
            dead = true;
            attContlr.playerDead = true;
        }
        if (dead)
        {
            DeathMenuControl();
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (vulnerable && healthPoints != 0)
        {
            if (coll.tag == "EnemyBullet" || coll.tag == "Enemy")
            {
                healthPoints--;
                StartCoroutine(CantBeHit());
                vulnerable = false;
            }
        }
    }
    IEnumerator CantBeHit()
    {
        for (int i = 0; i < 5; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            head.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            head.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.1f);
        vulnerable = 
            true;
    }

    void Death()
    {
        head.SetActive(false);
        transform.localScale = new Vector3(4, 4, transform.localScale.z);
        anim.Play("death");
        Instantiate(ghost, transform.position, transform.rotation);
        StartCoroutine(DeathScreenFade());
    }

    IEnumerator DeathScreenFade()
    {
        yield return new WaitForSeconds(2);
        gameUI.SetActive(false);
        deathScreen.SetActive(true);
    }

    void DeathMenuControl()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}
