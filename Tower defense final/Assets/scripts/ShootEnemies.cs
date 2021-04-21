using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private Tower tower;

    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        tower = gameObject.GetComponentInChildren<Tower>();
    }

    void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = tower.CurrentLevel.bullet; //vezme prefab střely

        Vector3 startPosition = gameObject.transform.position; //pozice odkud letí
        Vector3 targetPosition = target.transform.position; // pozice cíle
        startPosition.z = bulletPrefab.transform.position.z; //nastavení souřadnice Z
        targetPosition.z = bulletPrefab.transform.position.z; 

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab); //vytvoří střelu
        newBullet.transform.position = startPosition; //změní pozici objektu
        Projectiles bulletComp = newBullet.GetComponent<Projectiles>(); 
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition; //nastavení startovní pozice střely
        bulletComp.targetPosition = targetPosition; //nastavení cílové pozice střely
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Enemy")) //je objekt nepritel?
        {
            enemiesInRange.Add(other.gameObject); //prida do seznamu
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }

        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }


    void Update()
    {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;
        //určení cíle
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        if (target != null) //pokud je vybrán cíl, zahájí palbu
        {
            if (Time.time - lastShotTime > tower.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            // 
            Vector3 direction = gameObject.transform.position - target.transform.position;   
        }
    }
}
