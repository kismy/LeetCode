using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMaxValue : MonoBehaviour {

    //功能测试
    int[,] grid = new int[4, 4] {   { 1, 10, 3, 8 }, 
                                    { 12, 2, 9, 6 },
                                    {5,7,4,11 },
                                    { 3,7,16,5} };

    //特殊输入测试
    int[,] grid1 = new int[3, 4] {   { 1, 10, 3, 8 },
                                    { 12, 2, 9, 6 },
                                    {5,7,4,11 }};

    //边界值测试
    int[,] grid2 = new int[1, 4] {   { 1, 10, 3, 8 } }; //22
    int[,] grid3 = new int[4, 1] { { 1 }, { 12 }, { 5 }, { 3 } }; //21




    int[,] maxValue;
	void Start () {

        maxValue = new int[4, 4];
        int i = grid.GetLength(0) - 1 > 0 ? grid.GetLength(0) - 1 : 0;
        int j = grid.GetLength(1) - 1 > 0 ? grid.GetLength(1) - 1 : 0;
        Debug.Log(GetMAXValue(grid,i, j));

        maxValue = new int[3, 4];
        i = grid1.GetLength(0) - 1 > 0 ? grid1.GetLength(0) - 1 : 0;
        j = grid1.GetLength(1) - 1 > 0 ? grid1.GetLength(1) - 1 : 0; 
        Debug.Log(GetMAXValue(grid1, i, j));

        maxValue = new int[1, 4];
        i = grid2.GetLength(0) - 1 > 0 ? grid2.GetLength(0) - 1 : 0;
        j = grid2.GetLength(1) - 1 > 0 ? grid2.GetLength(1) - 1 : 0;
        Debug.Log(GetMAXValue(grid2, i, j));

        maxValue = new int[4, 1];
        i = grid3.GetLength(0) - 1 > 0 ? grid3.GetLength(0) - 1 : 0;
        j = grid3.GetLength(1) - 1 > 0 ? grid3.GetLength(1) - 1 : 0;
        Debug.Log(GetMAXValue(grid3, i, j));
    }
	
	
	int GetMAXValue (int[,] grid,int i,int j) //i=列 j=行 
    {
        if (grid == null) return 0;
        if (maxValue[i, j] != 0)
            return maxValue[i, j];

        if (i == 0 && j == 0)
        {
            maxValue[i, j] = grid[0, 0];
            return maxValue[i, j];
        }
       

        if (i == 0 && j > 0)
        {
            maxValue[i, j] = GetMAXValue(grid, 0, j - 1) + grid[i, j];
            return maxValue[i, j];
        }
        if (i > 0 && j == 0)
        {
            maxValue[i, j] = GetMAXValue(grid, i - 1, 0) + grid[i, j];
            return maxValue[i, j];
        }

        maxValue[i, j] =  Mathf.Max(GetMAXValue(grid, i - 1>0? i - 1:0, j),GetMAXValue(grid,i, j - 1>0? j - 1:0))+grid[i,j];

        return maxValue[i, j];
    }
}
