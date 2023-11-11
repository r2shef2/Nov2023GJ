using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip jump;
    public AudioClip[] hitGround;
    public AudioClip pullLever;
    public AudioClip[] walk;

    public void PlayAudioClip(AudioClip clip, float volume = 1, float pitch = 1)
    {
        if(audioSource.isPlaying == false)
        {
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void PlayAudioClip(AudioClip[] clips, float volume = 1, float pitch = 1)
    {
        if (audioSource.isPlaying == false)
        {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
