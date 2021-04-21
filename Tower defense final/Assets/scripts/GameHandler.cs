using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{
    public Text goldLabel;
    public Text scoreLabel;

    public bool gameOver = false;

    public AudioSource click;

    private int score;
    private int wave;
    private bool destroy = false;

    public bool Destroy
    {
        get { return destroy; }
        set
        {
            if (!gameOver)
            {
                destroy = value;
            }
        }
    }

    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            if (!gameOver)
            {
                wave = value;
            }
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreLabel.GetComponent<Text>().text = " " + score;
        }
    }

    public void DestroyTower()
    {
        Destroy = true;
        click.PlayOneShot(click.clip);
    }

    public bool canDestroy()
    {
        return Destroy;
    }

    public TowerButton ClickedButton { get; private set; }

    public int price;
    public int towerIndex = -1;
    private int gold;

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = " " + gold;
        }
    }

    public void PickTower(TowerButton towerButton)
    {
        click.PlayOneShot(click.clip); //zvuk kliknuti
        if (towerButton.price <= Gold)
        {
            towerIndex = towerButton.towerIndex;
            ClickedButton = towerButton;
            price = towerButton.price;
        }
    }

    public void EndGame()
    {
        gameOver = true;
        StaticScore.score = Score;
        StaticScore.gold = Gold;
        SceneManager.LoadScene("GameOver");
    }


    private void Start()
    {
        Debug.Log("GameHandler.start");
        Gold = 400;
        Score = 0;
    }
}
