using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject[] TowerPrefabs;
    private GameObject gameHandler;
    private GameHandler handler;
    private GameObject Tower;
    private int index = -1;



    private bool CanPlaceTower() // kontrola  jestli splňuje všechno
    {
        if (Tower == null && index != -1) return true;
        else return false;
    }

    private void OnMouseUp() //zavolá se po kliknutí na spot
    {
        if (CanPlaceTower())
        {
            Tower = (GameObject)Instantiate(TowerPrefabs[index], transform.position, Quaternion.identity); // vytvoření věže

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip); // spuštění zvuku

            index = -1;
            handler.towerIndex = -1;
            handler.Gold -= handler.price; // cena
        }
        if (handler.canDestroy() && Tower != null)
        {
            handler.Destroy = false;
            Destroy(Tower);
        }

    }



    private void Awake()
    {
        gameHandler = GameObject.Find("GameHandler");
        handler = gameHandler.GetComponent<GameHandler>();
    }

    void Update()
    {
        index = handler.towerIndex;
    }
}
