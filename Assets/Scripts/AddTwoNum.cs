﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTwoNum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    
     
     public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }

    public ListNode addTwoNumbers(ListNode l1, ListNode l2)
    {
        return helper(l1, l2, 0);
    }

    public ListNode helper(ListNode l1, ListNode l2, int carry)
    {
        if (l1 == null && l2 == null && carry == 0)
        {
            if (carry == 0) return null;
            else return new ListNode(1);
        }

        // Ternary functions avoid NullPointerExceptions
        int sum = ((l1 == null) ? 0 : l1.val) + ((l2 == null) ? 0 : l2.val) + carry;
        ListNode head = new ListNode(sum % 10);

        // Set the next pointer to be the sum of the next element of the two lists and the carry
        head.next = helper((l1 == null) ? null : l1.next, (l2 == null) ? null : l2.next, sum / 10);

        return head;
    }
}
