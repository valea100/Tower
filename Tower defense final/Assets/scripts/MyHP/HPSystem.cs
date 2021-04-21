using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject brokenHeartPrefab;

    public void DrawHearts(int hearts, int maxHearts)
    {   //znici predchozi vykreslene srdce
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //znovu vykresli spravna srdce
        for (int i = 0; i < maxHearts; i++)
        {
            if (i + 1 <= hearts)
            { //vykresleni srdcí
                GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform; //pozice se dědí
            }
            else
            { //vykreslení prázdných srdcí
                GameObject heart = Instantiate(brokenHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
        }
    }
}
