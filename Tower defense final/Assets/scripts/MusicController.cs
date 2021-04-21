using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume;

    private void Awake()
    {
        audioSource.volume = volume;
    }
}
