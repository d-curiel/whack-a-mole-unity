using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MoleController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    int score;
    [SerializeField]
    float timeAwake;
    private bool hit;
    private bool hiding;
    private AudioSource audioSource;
    [SerializeField]
    AudioClip hitClip;
    // Use this for initialization
    void Start () {
        hit = false;
        hiding = false;
        animator = GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    
    public void MoleHit()
    {
        if(!hit && !hiding)){
            hit = true;
            audioSource.PlayOneShot(hitClip);
            GameManager.instance.ModifyScore(score);
            StartCoroutine(MoleHitAnimation());
        }
        
    }

    private void OnEnable() {
        hit = false;
        StartCoroutine(MoleSpawner());
    }

    IEnumerator MoleSpawner() {
        yield return new WaitForSeconds(timeAwake);
        StartCoroutine(MoleHide());
    }

    IEnumerator MoleHitAnimation() {
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoleHide());
    }
    
    IEnumerator MoleHide() {
        animator.SetBool("Hide", true);
        hiding = true;
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.CleanHiddenMole(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
