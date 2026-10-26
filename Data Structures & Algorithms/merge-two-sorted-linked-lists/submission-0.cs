/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(-1);
        ListNode curr = dummy;  // This tracks the end of our new merged list

        // Compare elements from both lists while both have nodes remaining
        while (list1 != null && list2 != null) {
            if (list1.val <= list2.val) {
                curr.next = list1;
                list1 = list1.next;
            } else {
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;  // Advance the tail pointer
        }

        // Once one list runs out, attach whatever is left of the other list
        curr.next = list1 != null ? list1 : list2;

        // The real head of our merged list is right after the dummy node
        return dummy.next;
    }
}