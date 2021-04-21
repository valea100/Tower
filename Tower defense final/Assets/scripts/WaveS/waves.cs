using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves : MonoBehaviour
{
    
    int[][] wave = new int[][] {
       new int[] { 1, 1, 1, 1}, //1
       new int[] { 2, 1, 1, 1, 2}, //2
       new int[] { 1, 2, 2, 2, 1, 2, 1, 1, 1}, //3
       new int[] { 3, 2, 2, 1, 3, 3}, //4
       new int[] { 1, 2, 3, 3, 2, 2, 2, 1, 3}, //5
       new int[] { 1, 1, 3, 3, 3, 3, 3}, //6
       new int[] { 4, 4, 3, 1, 4, 4, 3, 2, 2, 2, 3, 4, 4, 2, 1}, //7
       new int[] { 3, 1, 1, 1, 3, 2, 1}, //8
       new int[] { 3, 4, 3, 4}, //9
       new int[] { 4, 4, 4, 4} //10
    };


    public int[] chooseWave(int number)
    {
        return wave[number];
    }

}
