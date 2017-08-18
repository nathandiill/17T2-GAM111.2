using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public AudioClip[] EventSounds;
    public AudioSource SFXChannel;

    // To call on correct word
    public void correctWordAudio()
    {
        AudioClip correctWord = EventSounds[0];
        SFXChannel.PlayOneShot(correctWord);
    }

    // To call on wrong word
    public void wrongWordAudio()
    {
        AudioClip wrongWord = EventSounds[1];
        SFXChannel.PlayOneShot(wrongWord);
    }
}
