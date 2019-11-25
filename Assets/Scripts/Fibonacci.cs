using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///N个台阶，一次可以走一步或者两步，求走这n个台阶有多少种方法（递归和非递归实现）
public class Fibonacci : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        dic.Add(0, 0);
        dic.Add(1, 1);
        dic.Add(2, 2);
        Debug.Log(FibonacciResult(10));
        Debug.Log(Fibonacci1(10));
    }

    /// <summary>
    /// 带备忘录自底向上
    /// </summary>
    Dictionary<int, int> dic = new Dictionary<int, int>();
    int FibonacciResult(int N)
    {
        if (dic.ContainsKey(N))
            return dic[N];
      
        int result=FibonacciResult(N - 1) + FibonacciResult(N - 2); //走一步+走两步
        dic.Add(N,result);
        return result;

    }

    ///非递归方法
    int Fibonacci1(int N)
    {
        if (N <= 2)
            return N;
        int fibtwo = 2;
        int fibone = 1;
        int fibN = 0;
        for (int i = 3; i <= N; i++)
        {
            fibN = fibone + fibtwo;
            fibone = fibtwo;
            fibtwo = fibN;
        }
        return fibN;
    }
}
