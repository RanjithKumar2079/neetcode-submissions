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
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null) {
            return false;
        }

        ListNode slow = head;
        ListNode fast = head;

        // Traverse while fast can take two steps safely
        while (fast != null && fast.next != null) {
            slow = slow.next;       // Tortoise moves 1 step
            fast = fast.next.next;  // Hare moves 2 steps

            if (slow == fast) {
                return true;  // They met! A cycle exists.
            }
        }

        // Fast reached the end of the list, meaning there is no cycle
        return false;
    }
}
