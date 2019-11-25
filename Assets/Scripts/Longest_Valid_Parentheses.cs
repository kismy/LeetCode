using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longest_Valid_Parentheses : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(LongestValidParentheses("(()"));
	}

    /// <summary>
    ///  “)(” 无效 “（）”有效
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    int LongestValidParentheses(string s)
    {
        int n = s.Length, longest = 0;
        Stack<int> st=new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(') st.Push(i);
            else
            {
                if (!(st.Count == 0))
                {
                    if (s[st.Peek()] == '(') st.Pop();
                    else st.Push(i);
                }
                else st.Push(i);
            }
        }
        if (st.Count==0) longest = n;
        else
        {
            int a = n, b = 0;
            while (!(st.Count == 0))
            {
                b = st.Peek(); st.Pop();
                longest = Math.Max(longest, a - b - 1);
                a = b;
            }
            longest = Math.Max(longest, a);
        }
        return longest;
    }
}
