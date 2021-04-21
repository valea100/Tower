using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hearts;
    public int maxHearts = 10;
    [SerializeField] public HPSystem hs;

    private void Start()
    {
        hearts = 10;
        hs.DrawHearts(hearts, maxHearts);
    }

    public void DamagePlayer(int dmg)
    {
        if (hearts > 0)
        {
            hearts -= dmg;
            hs.DrawHearts(hearts, maxHearts);
        }
    }

    public void HealPlayer(int dmg)
    {
        if (hearts < maxHearts)
        {
            hearts += dmg;
            hs.DrawHearts(hearts, maxHearts);
        }
    }

    private void Update()
    {
        if (hearts == 0)
        {
            gameObject.GetComponent<GameHandler>().EndGame();
        }
    }
}
