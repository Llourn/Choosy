using System;
using UnityEngine;

public enum Sound
{
    ButtonHover, 
    ButtonClick,
    OMNOMNOM
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundClip[] soundClips;
    
    
    private AudioSource _audioSource;
    
    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(Sound sound)
    {
        _audioSource.PlayOneShot(GetClip(sound));
    }

    private AudioClip GetClip(Sound sound)
    {
        foreach (SoundClip clip in soundClips)
        {
            if (clip.sound == sound)
            {
                return clip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " is missing!");
        return null;
    }
}

[System.Serializable]
public class SoundClip
{
    public Sound sound;
    public AudioClip audioClip;
}