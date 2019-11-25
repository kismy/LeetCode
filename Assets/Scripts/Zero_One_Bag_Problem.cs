using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero_One_Bag_Problem : MonoBehaviour {

    private struct Item
    {
        public int weight;
        public int price;
        public Item(int weight,int price)
        {
            this.weight = weight;
            this.price = price;
        }
    }
    Dictionary<int, Item> WVSP = new Dictionary<int, Item>();
    int[,] result;
    // Use this for initialization
    void Start () {

        //初始化测试用例
        int m = 10;      
        WVSP.Add(1,new Item(3,4));
        WVSP.Add(2,new Item(4,5));
        WVSP.Add(3,new Item(5,6));
        result = new int [m+1,WVSP.Count+1];

        //计算结果
        //result.Clear();
        //Debug.Log(C(3, 10));

        //result.Clear();
        //Debug.Log(C(3, 3));

        //result.Clear();
        //Debug.Log(C(3, 4));

        //result.Clear();
        //Debug.Log(C(3, 5));
        Debug.Log(UpDown(3, 7));

    }



    /// <summary>
    /// 我们要求得i个物体放入容量为m(kg)的背包的最大价值
    /// </summary>
    /// <param name="i">3</param>
    /// <param name="m">7</param>
    /// <returns></returns>
    int UpDown(int i, int m)
    {
        if (i == 0 || m == 0)
            return 0;
        if (result[m,i]!=0)
            return result[m,i];
       
        Item item = WVSP[i];
        if (m < item.weight) //袋子已满，装不下，直接舍弃
            result[m,i]= UpDown(i - 1, m);
        else
        {
            //放入i
            int puti = UpDown(i-1,m-item.weight)+item.price;

            //不放入i
            int withouti = UpDown(i-1,m);

            result[m, i] = Mathf.Max(puti, withouti);
        }
       return result[m, i];
    }
}
