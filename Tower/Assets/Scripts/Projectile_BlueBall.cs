using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_BlueBall : MonoBehaviour
{


    public Vector3 direction;
    public float speed = 5f;
    public int destroyTime = 5;
    float timer = 0;

    


    private void Setup(Vector3 direction)
    {
        this.direction = direction;
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
