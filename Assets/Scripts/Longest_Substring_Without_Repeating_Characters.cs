using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// </summary>
public class Longest_Substring_Without_Repeating_Characters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        Dictionary<Char, int> map = new Dictionary<Char, int>();
        int max = 0;
        int j = 0; //两重复字符中，前者的（索引+1）
        for (int i = 0; i < s.Length; ++i)
        {
            if (map.ContainsKey(s[i]))
            {
                j = Math.Max(j, map[s[i]] + 1);
            }
            map[s[i]]=i;
            max = Math.Max(max, i - j + 1);
        }
        return max;

    }
}
