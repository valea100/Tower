using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] waypoints;
    public Button start; //wave button
    public Text WaveLabel; //zobrazení vlny
    public AudioSource LetsGoo;

    private int waveNumber = 0; //index vlny k vytvoření
    private int[] enemiesWave;
    public bool isWave = false;
    private int index = 0; //index nepřátel ve vlně

    public float spawnInterval = 2; 
    private float timer = 0;


    public void SpawnWave()
    {
        //vezme si vlnu
        enemiesWave = gameObject.GetComponent<waves>().chooseWave(waveNumber);

        waveNumber++; //zvýší číslo vlny
        isWave = true;
        start.interactable = !start.interactable; //vypne tlačítko

        LetsGoo.volume = 0.1f;
        LetsGoo.PlayOneShot(LetsGoo.clip);

    }

    private void Update()
    {
        if (isWave)
        {
            timer += Time.deltaTime;

            if (timer > spawnInterval) //interval vytváření nepřátel
            {
                if (index < enemiesWave.Length)
                {
                    GameObject enemy = enemies[enemiesWave[index] - 1];
                    enemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                    enemy.transform.position = waypoints[0].transform.position;
                    Instantiate(enemy);
                    index++;

                }
                else //kontrola, jestli neskončila vlna
                {
                    GameObject[] en = GameObject.FindGameObjectsWithTag("Enemy");

                    if (en == null || en.Length == 0)
                    {
                        if (waveNumber == 10)
                        {
                            gameObject.GetComponent<GameHandler>().EndGame();
                        }
                        index = 0;
                        isWave = false;
                        start.interactable = !start.interactable;
                        WaveLabel.text = "Wave: " + (waveNumber+1);
                        gameObject.GetComponent<GameHandler>().Gold += 100; 
                        
                    }
                }
                timer = 0;
            }
        }
        
    }
}
