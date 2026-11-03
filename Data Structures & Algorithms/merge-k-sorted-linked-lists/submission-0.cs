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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0)
            return null;

        int right = lists.Length - 1;

        // Keep merging until everything is consolidated down to index 0
        while (right > 0) {
            int left = 0;
            int currentRight = right;

            // Merge pairs from opposite ends moving inward
            while (left < currentRight) {
                lists[left] = MergeTwoLists(lists[left], lists[currentRight]);
                left++;
                currentRight--;
            }

            // The new boundary is wherever the right pointer ended up
            right = currentRight;
        }

        return lists[0];
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        while (l1 != null && l2 != null) {
            if (l1.val <= l2.val) {
                curr.next = l1;
                l1 = l1.next;
            } else {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        curr.next = (l1 != null) ? l1 : l2;
        return dummy.next;
    }
}
