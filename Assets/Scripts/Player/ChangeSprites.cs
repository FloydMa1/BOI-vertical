using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour {

    [SerializeField] Sprite lookRight;
    [SerializeField] Sprite lookLeft;
    [SerializeField] Sprite lookUp;
    [SerializeField] Sprite lookDown;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShootDown()
    {
        anim.SetBool("ShootDown", true);
        StartCoroutine(WaitForEndAnim());
    }

    public void ShootUp()
    {
        anim.SetBool("ShootUp", true);
        StartCoroutine(WaitForEndAnim());
    }

    public void ShootRight()
    {
        anim.SetBool("ShootRight", true);
        StartCoroutine(WaitForEndAnim());
    }

    public void ShootLeft()
    {
        anim.SetBool("ShootLeft", true);
        StartCoroutine(WaitForEndAnim());
    }

    IEnumerator WaitForEndAnim()
    {
        if (anim.GetBool("ShootDown"))
        {
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("ShootDown", false);
        }
        else if (anim.GetBool("ShootUp"))
        {
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("ShootUp", false);
        } 
        else if (anim.GetBool("ShootLeft"))
        {
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("ShootLeft", false);
        }
        else if (anim.GetBool("ShootRight"))
        {
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("ShootRight", false);
        }
    }
}
