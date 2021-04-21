using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixer audioMixer;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void backButton()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
