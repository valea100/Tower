using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text gold;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + StaticScore.score;
        gold.text = "Gold: " + StaticScore.gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
