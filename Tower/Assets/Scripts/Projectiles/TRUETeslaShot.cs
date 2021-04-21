using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRUETeslaShot : MonoBehaviour
{
    public Vector3 direction;
    public int destroyTime = 5;
    public float speed = 1f;
    public int damage = 10;
    public float timer = 0;
    private Vector3 moveDir;


    

    void Start()
    {
        moveDir = (direction - transform.position).normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "tower")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "tower")
        {
            Destroy(gameObject);
        }


    }



    void Update()
    {
        
        

        transform.position += moveDir * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {

            Destroy(gameObject);
        }
    }
}
