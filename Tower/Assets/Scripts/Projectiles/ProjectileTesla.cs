using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTesla : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;
    public int destroyTime = 5;
    public int damage = 10;
    float timer = 0;

    /*public static void Create(Vector3 spawnPosition, Vector3 direction)
    {
        Transform ballTransform = Instantiate(GameAssets.i.Projectile_Blue, spawnPosition, Quaternion.identity);

        Projectile_BlueBall projectile_BlueBall = ballTransform.GetComponent<Projectile_BlueBall>();

    }*/
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);

    }


    private void Update()
    {

        Vector3 moveDir = (direction - transform.position).normalized;

        transform.position += moveDir * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {

            Destroy(gameObject);
        }

    }
}
