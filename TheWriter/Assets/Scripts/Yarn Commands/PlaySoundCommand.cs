using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PlaySoundCommand : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] ads;


    [YarnCommand("PlaySound")]
    public void PlaySound(string clipname)
    {

        foreach (AudioClip clip in ads)
        {
            if (clip.name == clipname)
                //audioSource.Stop();
                audioSource.clip = clip;
                audioSource.Play();
        }

        //audioSource.clip = clip;
        //audioSource.Play();
    }


}
