using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicController : MonoBehaviour
{
    
    AudioSource audioSource;
    [SerializeField]
    AudioClip backgroundMusic;
    // Start is called before the first frame update
     void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.25f;
        StartCoroutine(playAudioSequentially());
    }

     
    IEnumerator playAudioSequentially()
    {
        yield return null;

        //loop enternally
        while (true)
        {
                //2.Assign current AudioClip to audiosource
                audioSource.clip = backgroundMusic;

                //3.Play Audio
                audioSource.Play();

                //4.Wait for it to finish playing
                while (audioSource.isPlaying || (GameManager.instance != null && !GameManager.instance.IsGameStarted()))
                {
                    yield return null;
                }

              
        }
    }

    public void StopMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.Play();
    }
}
