using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyNum : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetUglyNum(1500));
	}

    //第1500个丑数
    int GetUglyNum(int nTH)
    {
        int index = 3;
        try
        {
            int[] uglies = new int[nTH];
            uglies[0] = 1;
            uglies[1] = 2;
            uglies[2] = 3;
            uglies[3] = 5;

            int index2 = 0; int index3 = 0; int index5 = 0;

           
            while (index <= nTH-2)
            {

                while (uglies[index2] * 2 <= uglies[index])
                    index2++;
                while (uglies[index3] * 3 <= uglies[index])
                    index3++;
                while (uglies[index5] * 5 <= uglies[index])
                    index5++;
                //找到比 uglies[index-1]大的最小丑数
                uglies[++index] = Mathf.Min(2 * uglies[index2], 3 * uglies[index3], 5 * uglies[index5]);
            }


            return uglies[nTH - 1];
        }
        catch (Exception e)
        {
            Debug.Log(e+" index="+index);
            
        }
        return 0;
    }
}
