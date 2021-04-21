using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 1;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float range;

    private float distance;
    private float startTime;

    private GameHandler gameHandler;




    void Start()
    {

        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gh = GameObject.Find("GameHandler");
        gameHandler = gh.GetComponent<GameHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0); //poškození nepřítele
                //když nemá životy, zníčí cíl a přičte zlato
                if (healthBar.currentHealth <= 0)
                {
                    int ind = target.GetComponent<MoveEnemy>().enemyIndex;
                    if (ind == 0) { gameHandler.Gold += 50; gameHandler.Score += 50; }
                    if (ind == 1) { gameHandler.Gold += 100; gameHandler.Score += 100; }
                    if (ind == 2) { gameHandler.Gold += 150; gameHandler.Score += 150; }
                    if (ind == 3) { gameHandler.Gold += 200; gameHandler.Score += 200; }
                    Destroy(target);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                }
                Destroy(gameObject);
            }
            else //předpověď cíle, aby se projektil nikdy nezastavil na místě
            {
                targetPosition.x += 10;
                targetPosition.y += 10;
            }
        }

    }



    void Update()
    {

        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
        
        if (target != null && Vector3.Distance(startPosition, gameObject.transform.position) < range)
        {
            targetPosition = target.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }

       

    }
}
