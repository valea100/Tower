using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtilities;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    public GameObject towerPrefab;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    public int price;


    public Sprite Sprite { get => sprite;}
}
