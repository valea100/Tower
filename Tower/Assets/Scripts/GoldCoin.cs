using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{

    private GameHandler gameHandler;
    public int value = 100;

    [Header("Coin random drop")]
    public Transform objTrans;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 0.5f;
    private Vector3 off;

    private void Awake()
    {
        //random smer x
        off = new Vector3(Random.Range(-1f, 1f), off.y, off.z);
        //random smer y
        off = new Vector3(off.x, Random.Range(-1f, 1f), off.z);
    }

    private void Start()
    {
        gameHandler = GameHandler.FindObjectOfType<GameHandler>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameHandler.Gold += value;
            Destroy(gameObject);
        }
        
    }


    private void Update()
    {
        //kdy se coin prestane hybat
        if (when >= delay)
        {
            pasttime = Time.deltaTime;
            //pozice coinu
            objTrans.position += off * Time.deltaTime;
            delay += pasttime;
        }
    }

}
