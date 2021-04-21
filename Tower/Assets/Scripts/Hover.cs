using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer rangeSpriteRenderer;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

    }


    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        if (spriteRenderer.enabled)
        {
            //pozice mysi
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //resetuju Z hodnotu
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    //aktivuje hover ikonku
    public void Activate(Sprite sprite)
    {
        
        //nastavim spravnej sprite
        this.spriteRenderer.sprite = sprite;

        spriteRenderer.enabled = true;

        //rangeSpriteRenderer.enabled = true;
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;

        //rangeSpriteRenderer.enabled = false;
    }
}
