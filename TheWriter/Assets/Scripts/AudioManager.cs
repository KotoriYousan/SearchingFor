using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip preAudioClip;
    private string audioName;
    public AudioClip[] audioClip;
    public float fadeOut = 3;
    public float fadeIn = 3;
    public float delay = 0;
    public float maxVolume = 1f;
    private AudioClip currentAudioClip;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0f;
        audioSource.loop = true;
        audioSource.spatialBlend = 0f;
        
        //调用的时候调用Play函数就行
        //Play("3");
        
        DontDestroyOnLoad(gameObject);
    }

    [YarnCommand("PlayMusic")]
    public void Play(string name)
    {
        audioName = name;
        StartCoroutine(DoPlay());
    }

    private IEnumerator DoPlay()
    {
        
        
        for (int i = 0; i < audioClip.Length; i++)
        {
            if (audioClip[i].name == audioName)
                currentAudioClip = audioClip[i];
        }
        
        if (audioSource.isPlaying && audioSource.clip == currentAudioClip)
        {
            yield return 0;
        }
        else 
        {
            float time1 = Time.time;
            if (preAudioClip != null)
            {
                yield return StartCoroutine(StartFadeOut(fadeOut));
            }

            //set delay
            float time2 = Time.time - time1;
            if (delay > time2)
            {
                yield return new WaitForSeconds(delay - time2);
            }

            //Play audio
            audioSource.clip = currentAudioClip;
            preAudioClip = currentAudioClip;
            audioSource.Play();

            yield return StartCoroutine(StartFadeIn(fadeIn));
        }
    }
    private IEnumerator StartFadeOut(float fadeOut)
    {
        float time = 0f;
        while (time <= fadeOut)
        {
            if (time != 0)
            {
                audioSource.volume = Mathf.Lerp(maxVolume, 0, time / fadeOut);
            }
            time += Time.deltaTime;
            yield return 1;
        }
        audioSource.volume = 0;
    }
    private IEnumerator StartFadeIn(float fadeIn)
    {
        float time = 0f;
        while (time <= fadeIn)
        {
            if (time != 0)
            {
                audioSource.volume = Mathf.Lerp(0, maxVolume, time / fadeIn);
            }
            time += Time.deltaTime;
            yield return 1;
        }
        audioSource.volume = maxVolume;
    }
}
