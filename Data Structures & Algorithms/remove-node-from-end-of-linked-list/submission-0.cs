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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0, head);
        ListNode slow = dummy;
        ListNode fast = dummy;

        // 1. Move fast pointer n + 1 steps ahead to create the exact gap
        for (int i = 0; i <= n; i++) {
            fast = fast.next;
        }

        // 2. Move both slow and fast together until fast hits the end (null)
        while (fast != null) {
            slow = slow.next;
            fast = fast.next;
        }

        // 3. slow is now right before the target node. Skip/remove it.
        slow.next = slow.next.next;

        return dummy.next;
    }
}
