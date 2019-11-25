using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStringOfNoRepeatChar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GetSubStringOfNoRepeatChar(""));
        Debug.Log(GetSubStringOfNoRepeatChar("arabcacfr"));
    }
	
	// Update is called once per frame
	string GetSubStringOfNoRepeatChar(string str) {
        if (string.IsNullOrEmpty(str) || str.Length == 1)
            return str;
        int[] Position = new int[26]; //标记位，结合tempStart判断Char是否重复
        for (int i = 0; i < Position.Length; i++)
            Position[i] = -1;


        int start = 0;
        int end = 0;
        int tempStart = 0;
        int tempEnd =0;

        for (int i = 0; i < str.Length; i++)
        {
           
            int Char = str[i] - 'a';
            if (i == 0)
            {
                Position[Char] = i;
                continue;
            }

            int p = Position[Char];
            if (p == -1 || p < tempStart)//Char不是重复字符
            {
                if (i == str.Length - 1)
                {
                    tempEnd = i;
                    if (tempEnd - tempStart > end - start)
                    {
                        start = tempStart;
                        end = tempEnd;
                    }
                }
            }
            else // Char是重复字符
            {
                tempEnd = i - 1;
                if (tempEnd - tempStart > end - start)
                {
                    start = tempStart;
                    end = tempEnd;
                }

                tempStart = p + 1;
            }
            Position[Char] = i;
        }
        return str.Substring(start,end-start+1);
	}
}
