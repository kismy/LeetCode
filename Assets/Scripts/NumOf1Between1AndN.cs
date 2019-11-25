using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumOf1Between1AndN : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(NumOf1Between1ToN(0));
        Debug.Log(NumOf1Between1ToN(1));
        Debug.Log(NumOf1Between1ToN(9));
        Debug.Log(NumOf1Between1ToN(10));
        Debug.Log(NumOf1Between1ToN(11));
    }

    int NumOf1Between1ToN(int n)
    {
        if(n<=0)
            return 0;

        return NumOf1(n.ToString());
    }

    //21345
    int NumOf1(string strN)
    {
        if (string.IsNullOrEmpty(strN))
            return 0;
        int first = strN[0] - '0';
        int length = strN.Length;
        if (length == 1 && first == 0)
            return 0;
        if (length == 1 && first > 0)
            return 1;

        //假设strN="21345",分成两段，低位部分1-1345，高位部分1346-21345

        int numFirstDight = 0; //1出现在最高位的情况
        if (first > 1) //10000-19999
            numFirstDight = PowerBase10(length-1);
        else if (first == 1)//假设测试用例改为12345，则1出现1+2345次
            numFirstDight =1+int.Parse(strN.Substring(1, strN.Length - 1));


        //1出现在除去最高位[万位]的其他4位的情况，1346-21345分为两段
        //1346-11345 次高位1出现的次数=4*10^3 
        //11346-21345 次高位1出现的次数=4*10^3
        //根据排列组合：后(length-1)=4位中，选择其中一位是1，其余(length-2)位可以在0-9中选择
        int numOtherDights = first*(length-1)*PowerBase10(length-2); 


        //1-1345中1的个数  递归实现
        int numRecursive = NumOf1(strN.Substring(1,strN.Length-1));


        return numFirstDight + numOtherDights + numRecursive;
    }

    /// <summary>
    /// 10的n次方
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    int PowerBase10(int n)
    {
        int result = 1;
        for (int i = 0; i < n; i++)
        {
            result *= 10;
        }
        return result;
    }
}
