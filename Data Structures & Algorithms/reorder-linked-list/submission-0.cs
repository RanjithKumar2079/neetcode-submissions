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
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null)
            return;

        // --- Step 1: Find the middle of the linked list ---
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // 'slow' is now at the middle. Split the list into two halves.
        ListNode secondHalf = slow.next;
        slow.next = null;  // Cut the connection from the first half
        ListNode firstHalf = head;

        // --- Step 2: Reverse the second half ---
        ListNode prev = null;
        ListNode curr = secondHalf;

        while (curr != null) {
            ListNode nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        secondHalf = prev;  // 'prev' is now the new head of the reversed second half

        // --- Step 3: Interleave / Merge the two halves ---
        ListNode p1 = firstHalf;
        ListNode p2 = secondHalf;

        while (p2 != null) {
            // Temporarily store the next nodes
            ListNode nextP1 = p1.next;
            ListNode nextP2 = p2.next;

            // Weave them together
            p1.next = p2;
            p2.next = nextP1;

            // Advance pointers
            p1 = nextP1;
            p2 = nextP2;
        }
    }
}
