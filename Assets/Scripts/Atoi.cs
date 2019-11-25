using System;
using System.Collections.Generic;
using UnityEngine;
public static class MathEx
{
    //考虑+-号
    //可能是整数，也可能是浮点数,浮点数可能没有整数部分，比如：".58"即0.58
    //5e2、5e-2 科学计数法:500和0.05
    //考虑越界
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input">[+-A][.[B]][e|E][+-C],A是整数部分，B是小数部分，C是指数部分</param>
    /// <returns></returns>
    public static float ToFloat(this string input)
    {
        return 0;
    }

    //1)discards all leading whitespaces
    //2)sign of the number 考虑+-号
    //3)overflow越界  Input: "-91283472332" Output: -2147483648   即假定输入int32,[2^31,2^31-1]
    //4)invalid input
    //仅仅考虑整数

    //取输入的有效字段Input: "4193 with words" Output: 4193 ；   Input: "words and 987" Output: 0
   
    public static int ToInt32(this string str)
    {
        int sign = 1, Base = 0, i = 0;
        while (i < str.Length&&str[i] == ' ') { i++; } //去掉字符串头的空格字符
        if (i < str.Length && (str[i] == '-' || str[i] == '+'))
        {
            if (str[i++] == '-')
                sign = -1;
        }
        int MAXD10 = int.MaxValue / 10;
        while (i<str.Length&& str[i] >= '0' && str[i] <= '9')
        {
            //MIN=-2147483648 ; MAX=2147483647 ; MAXD10=214748364
            if (Base > MAXD10 || ((Base == MAXD10) && str[i] - '0' > 7))
            {
                if (sign == 1)
                    return int.MaxValue;
                else
                    return int.MinValue;
            }
            Base = 10 * Base + (str[i++] - '0');
        }
        return Base * sign;
    }
}
public class Atoi : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string input = "2147483647";
        Debug.Log(input.ToInt32());
	}
	

}
