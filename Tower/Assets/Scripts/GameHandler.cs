﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtilities;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Text goldLabel;
    public TowerButton ClickedButton { get; private set; }

    private Vector2 mousePos;
    private int gold;
    private int price;
    private Hover hover;

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }

    private void Start()
    {
        Debug.Log("GameHandler.start");
        Gold = 100;
        hover = GameObject.Find("hover").GetComponent<Hover>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(ClickedButton != null)
        {
            mousePos = MyUtils.GetMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                if (canSpawnTower(mousePos))
                {
                    float x = Mathf.Floor(mousePos.x);
                    float y = Mathf.Floor(mousePos.y);
                    Vector3 position = new Vector3(x, y, 0);

                    Instantiate(ClickedButton.towerPrefab, position, Quaternion.identity);
                    Gold -= price;


                    ClickedButton = null;
                    hover.Deactivate();
                }
            }
        }
    }

    public void PickTower(TowerButton towerButton)
    {
        if(towerButton.price <= Gold)
        {
            ClickedButton = towerButton;
            hover.Activate(towerButton.Sprite);
            price = towerButton.price;
        }     
    }

    private bool canSpawnTower(Vector3 position)
    {
        BoxCollider2D TowerBoxCollider = ClickedButton.towerPrefab.GetComponent<BoxCollider2D>();
        if (Physics2D.OverlapBox(position + (Vector3)TowerBoxCollider.offset, TowerBoxCollider.size, 0))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
