using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip shootClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.50f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            if(!audioSource.isPlaying )
            {
                audioSource.PlayOneShot(shootClip);
            }
            RaycastHit2D hit = Physics2D.Raycast( Camera.main.ScreenToWorldPoint( Input.mousePosition ), Vector2.zero );
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Mole")
                {
                    hit.collider.GetComponent<MoleController>().MoleHit();
                }
            }
        }
    }
}
