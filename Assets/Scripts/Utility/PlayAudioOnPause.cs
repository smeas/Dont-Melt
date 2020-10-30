using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Robin
public class PlayAudioOnPause : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip clip;
    public void PlayOnPause()
    {
        if (Time.timeScale == 1)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            Time.timeScale = 0;
        }
    }
}
