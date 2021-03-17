using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; //public, abych mohl nastavit v unity, nebo nechat nastavit rovnou od gejmra

    public Rigidbody2D rb;
    public Animator animator;
    private PlayerHealth playerHealth;


    Vector2 movement;

    private void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            Destroy(collision.gameObject);
            playerHealth.DamagePlayer(1);
        }
    }



    // Update is called once per frame
    void Update()
    {
        //input od gejmra

        movement.x = Input.GetAxisRaw("Horizontal"); //returns 1,-1, 0
        movement.y =  Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); // for some reason sqrMagnitude faster than Magnitude...idk

    }

    private void FixedUpdate() //neni fixnutej na framerate
    {
        //movement actuall
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
}
