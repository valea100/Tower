using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    public GameObject towerPrefab;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    public int price;
    [SerializeField]
    public int towerIndex;


    public Sprite Sprite { get => sprite; }
}
