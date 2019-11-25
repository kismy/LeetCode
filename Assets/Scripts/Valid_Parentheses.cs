using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valid_Parentheses : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string str = "[()[]{()()}]";
        Debug.Log(IsValid(str));
	}

    public bool IsValid(string s)   
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count > 0 && stack.Peek() == s[i])
                stack.Pop();
            else
                stack.Push(Reverse(s[i]));

        }
        return stack.Count==0;

    }

    char Reverse(char input)
    {
        if (input == '[') return ']';
        if (input == ']') return '[';

        if (input == '(') return ')';
        if (input == ')') return '(';

        if (input == '{') return '}';
        if (input == '}') return '{';
        return ' ';
    }
}
