using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourTower : MonoBehaviour
{
    float timer = 0;
    public int waiting_time = 3;

    public GameObject projectile_up;
    public GameObject projectile_down;
    public GameObject projectile_left;
    public GameObject projectile_right;
    // Start is called before the first frame update
    void Start()
    {
        GameObject wave = GameObject.Find("GameHandler");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameObject.Find("GameHandler").GetComponent<WaveSpawner>().isWave)
        {
            if (timer > waiting_time)
            {
                //action
                Instantiate(projectile_up, gameObject.transform.position, Quaternion.identity);
                Instantiate(projectile_down, gameObject.transform.position, Quaternion.identity);
                Instantiate(projectile_left, gameObject.transform.position, Quaternion.identity);
                Instantiate(projectile_right, gameObject.transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
