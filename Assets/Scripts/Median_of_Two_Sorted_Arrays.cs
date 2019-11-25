
using System;
using System.Collections.Generic;
using UnityEngine;

//寻找两有序数组中位数
public class Median_of_Two_Sorted_Arrays : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int[] a1 = new int[3] {1,2 ,5};
        int[] a2 = new int[2] {3, 4 };
       Debug.Log( findMedianSortedArrays(a1,a2));


    }

    /// <summary>
    /// 寻找两有序数组中位数
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double findMedianSortedArrays(int[] nums1, int[] nums2)
    {
        //Get the middle element
        int mid = (nums2.Length + nums1.Length + 1) / 2;
        //Find that middle element
        double res = getkth(nums1, nums2, mid);
        //If the combined Length is even then find mid+1 element as well
        if ((nums2.Length + nums1.Length) % 2 == 0)
        {
            res += getkth(nums1, nums2, mid + 1);
            //Find the average of two elements
            res = res / 2;
        }
        return res;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="k">第k个数，而非索引k</param>
    /// <returns></returns>
    public int getkth(int[] A, int[] B, int k)
    {
        //Make sure array A is the smaller array
        if (B.Length < A.Length) return getkth(B, A, k);
        //If smaller array is empty, simply return the value from second array
        if (A.Length == 0) return B[k - 1];
        //If k is 1, then it must be the smaller of first element of the array
        if (k == 1) return Math.Min(A[0], B[0]);

        //Get the index for array A to compare
        int i = Math.Min(A.Length, k / 2);
        //Index for array B must be such that i + j = k
        int j = k - i;

        //Remove the smaller elemets from the array A if, ith index of A is smaller than jth index of B
        if (A[i - 1] < B[j - 1])
        {
            int[] newA = new int[A.Length - i];
            //Make a new array and copy the rest of the array elements
            System.Array.Copy(A, i, newA, 0, (A.Length - i));
            return getkth(newA, B, k - i);
        }
        else
        {
            int[] newB = new int[B.Length - j];
            System.Array.Copy(B, j, newB, 0, (B.Length - j));
            return getkth(A, newB, k - j);
        }
    }
}
