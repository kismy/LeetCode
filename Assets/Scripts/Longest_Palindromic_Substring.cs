using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longest_Palindromic_Substring : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log(longestPalindrome("babad"));
	}

    private int lo, maxLen;
    public string longestPalindrome(string s)
    {
        int len = s.Length;
        if (len < 2)
            return s;

        //由中间向两边扩散 时间复杂度O(n ^2)
        for (int i = 0; i < len - 1; i++)
        {
            //分奇偶
            extendPalindrome(s, i, i);  //assume odd length, try to extend Palindrome as possible
            extendPalindrome(s, i, i + 1); //assume even length.
        }
        return s.Substring(lo, lo + maxLen);
    }

    private void extendPalindrome(string s, int j, int k)
    {
        while (j >= 0 && k < s.Length && s[j] == s[k])
        {
            j--;
            k++;
        }
        if (maxLen < k - j - 1)
        {
            lo = j + 1;
            maxLen = k - j - 1;
        }
    }

}
