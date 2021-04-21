using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRUETeslaTower : MonoBehaviour
{
    private Vector3 shootFromPosition;
    public GameObject poziceShoot;
    float timer = 0;
    public float waiting_time = 1f;
    public TRUETeslaShot projectile;
    public List<GameObject> enemiesInRange;
    private bool isPlayerIn = false;
    GameObject Pleyer;

    private void Awake()
    {
        shootFromPosition = poziceShoot.transform.position;

    }


    void Start()
    {
        enemiesInRange = new List<GameObject>();
    }

    private void CreateShot(Vector3 spawnPoint, Vector3 direction)
    {
        TRUETeslaShot shot = projectile.GetComponent<TRUETeslaShot>();
        shot.direction = direction;
        Instantiate(projectile, spawnPoint, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Ignore_all"))
        {
            enemiesInRange.Add(collider.gameObject);
        }

        if (collider.gameObject.tag.Equals("Player"))
        {
            isPlayerIn = true;
            Pleyer = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            isPlayerIn = false;
        }
        else enemiesInRange.Remove(collider.gameObject);
    }

    void Update()
    {


        if (GameObject.Find("GameHandler").GetComponent<WaveSpawner>().isWave)
        {
            GameObject target = null;
            float minimalEnemyDistance = float.MaxValue;
            if(enemiesInRange.Count == 0 && isPlayerIn)
            {
                target = Pleyer;
            }
            foreach (GameObject enemy in enemiesInRange)
            {
                float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
                if (distanceToGoal < minimalEnemyDistance)
                {
                    target = enemy;
                    minimalEnemyDistance = distanceToGoal;
                }
            }

            if (target != null)
            {
                timer += Time.deltaTime;
                if (timer > waiting_time)
                {

                    projectile.direction = target.transform.position;

                    Instantiate(projectile, shootFromPosition, Quaternion.identity);
                    timer = 0;
                }

            }
            else timer = 0;

        }

    }
}
