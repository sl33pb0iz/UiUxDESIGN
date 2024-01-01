using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusicMaster : MonoBehaviour
{
    public static PlayMusicMaster instance;

    [Range(0f,1f)]
    public float musicVolumn = 1.0f;

    [Range(0f, 1f)]
    public float soundFXVolumn = 1.0f;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private AudioClip musicAudioClip;
    [SerializeField] private AudioClip buttonAudioClip;

    private void Start()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        EazySoundManager.PlayMusic(musicAudioClip, musicVolumn, true, false, 1, 1);
    }

    public void PlayButtonClick()
    {
        EazySoundManager.PlayUISound(buttonAudioClip);
    }
}

