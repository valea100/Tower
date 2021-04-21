using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;
    public GameObject optionsMenu;
    public GameObject about;
    public void PlayGame()
    {
        click.PlayOneShot(click.clip);
        SceneManager.LoadScene("main1");
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);

    }

    public void AboutButton()
    {
        about.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        click.PlayOneShot(click.clip);
        Application.Quit();
    }
}
