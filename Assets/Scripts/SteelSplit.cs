using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelSplit : MonoBehaviour {

    // Use this for initialization
    void Start () {

        Debug.Log(UpDown(0,p));
        Debug.Log(UpDown(1,p));
        Debug.Log(UpDown(2,p));
        Debug.Log(UpDown(3,p));
        Debug.Log(UpDown(4,p));
        Debug.Log(UpDown(5,p));
        Debug.Log(UpDown(6,p));
        Debug.Log(UpDown(7,p));
        Debug.Log(UpDown(8,p));
        Debug.Log(UpDown(9,p));
        Debug.Log(UpDown(10,p));
        Debug.Log(UpDown(20,p));
    }

    int[] result = new int[11];
    int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引0-10代表 钢条的长度，值代表价格

    int UpDown(int length,int[] prices)
    {
        if (length > prices.Length)
        {
            Debug.Log("钢条长度不可大于价格表长度，因为大于数组长度的钢条，单价没有, 数组越界");
            return -1;
        }

        if (length <= 1) return 
                prices[length];
        if (result[length] != 0)
            return result[length];

        int max = 0;
        for (int i = 1; i <= length; i++)
        {
            //全部情况分为两部分，一边切割，一边不切割
            //避免无限循环
            int temp = prices[i] + UpDown(length - i, prices); 
            if (temp > max)
                max = temp;

        }
        result[length] = max;
        return max;
    }
}
