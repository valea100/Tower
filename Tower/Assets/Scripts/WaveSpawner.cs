using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] waypoints;
    public Button start;




    private int waveNumber = 1;
    private int[] enemiesWave;
    public bool isWave = false;
    private float timer = 0;
    private int index = 0;

    public float spawnInterval = 2;

    

    
    
    
    public void SpawnWave()
    {
        enemiesWave = gameObject.GetComponent<waves>().chooseWave(waveNumber-1);
        
        waveNumber++;
        isWave = true;
        start.interactable = !start.interactable;
    }

    private void Update()
    {
        if (isWave)
        {
            timer += Time.deltaTime;

            if (timer > spawnInterval)
            {
                if (index < enemiesWave.Length)
                {
                    Instantiate(enemies[enemiesWave[index] - 1]).GetComponent<MoveEnemy>().waypoints = waypoints;
                    index++;
                    
                }
                else
                {
                    GameObject[] en = GameObject.FindGameObjectsWithTag("Ignore_all");

                    if (en == null || en.Length == 0)
                    {
                        index = 0;
                        isWave = false;
                        start.interactable = !start.interactable;
                    }
                }
                timer = 0;
            }
        }
       
    }
}
