using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] waypoints; //R seznam waypointů
    private int currentWaypoint = 0; //P aktuální waypoint
    private float lastWaypointSwitchTime; //P čas kdy přešel přes waypoint
    public float speed = 1.0f; //P rychlost pohybu
    public int enemyIndex;
    private Health playerHealth; //R životy hráče


    void Start()
    {
        lastWaypointSwitchTime = Time.time;
        playerHealth = GameObject.FindWithTag("GameHandler").GetComponent<Health>();
    }

    public float DistanceToGoal() // vrací jak je blízko k poslednímu waypointu
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }


    void Update() // volá se po každém snímku
    {
        //z seznamu vezme startovní a poslední WP aktuálního směru
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        //spočítá dobu potřebnou na trasu, pak aktuální čas na trase
        //poté změní pozici nepřítele
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition)) // kontroluje jestli nedošel na WP
        {
            if (currentWaypoint < waypoints.Length - 2) //kontroluje jestli to není poslední WP
            {

                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;

            }
            else //pokud to je poslední WP, ubere hráči život a odstraní se.
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, Vector3.zero);
                playerHealth.DamagePlayer(1);
                Destroy(gameObject);
            }
        }
    }
}
