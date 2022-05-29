using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    int score;
    private bool hit;
    // Use this for initialization
    void Start () {
        hit = false;
        animator = GetComponent<Animator>();
    }
    
    public void MoleHit()
    {
        if(!hit){
            hit = true;
            GameManager.instance.ModifyScore(score);
            StartCoroutine(MoleHitAnimation());
        }
        
    }

    private void OnEnable() {
        hit = false;
        StartCoroutine(MoleSpawner());
    }

    IEnumerator MoleSpawner() {
        yield return new WaitForSeconds(3f);
        StartCoroutine(MoleHide());
    }

    IEnumerator MoleHitAnimation() {
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoleHide());
    }
    
    IEnumerator MoleHide() {
        animator.SetBool("Hide", true);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.CleanHiddenMole(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
