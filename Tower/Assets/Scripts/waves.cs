using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves : MonoBehaviour
{
    int[][] wave = new int[][] { 
       new int[] { 1, 1, 2, 2 }, 
       new int[] { 2, 3, 4, 1 },
       new int[] { 1, 2, 3, 3 },
       new int[] { 4, 4, 3, 1 } 
    };


    public int[] chooseWave(int number)
    {
        return wave[number];
    }


    
}
