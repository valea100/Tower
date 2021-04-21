using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    private GameObject gameHandler;
    private GameHandler handler;
    private void awake()
    {
        gameHandler = GameObject.Find("GameHandler");
        handler = gameHandler.GetComponent<GameHandler>();
    }

    private void OnMouseUp()
    {
        Destroy(gameObject);
    }
}
