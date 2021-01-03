using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtilities;

public class TestingGrid : MonoBehaviour
{

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(26, 15, 1f, new Vector3(-10, -9));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(MyUtils.GetMousePosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(MyUtils.GetMousePosition()));
        }
    }

}
