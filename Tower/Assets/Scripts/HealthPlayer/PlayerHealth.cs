using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 5;
    public int maxHearts = 10;
    [SerializeField] HPSystem hs;

    private void Start()
    {
        hs.DrawHearts(hearts, maxHearts);
    }

    public void DamagePlayer(int dmg)
    {
        if(hearts > 0)
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
}
