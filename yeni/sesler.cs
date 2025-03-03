using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesler : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip a;
    public AudioClip b;
    public AudioClip c;
    public AudioClip d;

public AudioClip e;

    private void Start()
    {
        musicSource.clip = a;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
