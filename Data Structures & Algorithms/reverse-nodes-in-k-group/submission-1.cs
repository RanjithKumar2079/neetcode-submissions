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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k == 1)
            return head;

        // Dummy node anchors the start of our list and handles head updates safely
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode groupPrev = dummy;

        while (true) {
            // 1. Check if there are at least k nodes left to reverse
            ListNode kthNode = groupPrev;
            for (int i = 0; i < k; i++) {
                kthNode = kthNode.next;
                if (kthNode == null) {
                    return dummy.next;  // Fewer than k nodes remain, stop reversing
                }
            }

            ListNode groupNext = kthNode.next;  // The starting node of the next group

            // 2. Reverse the current k-group
            // We set prev to groupNext so the first node's next pointer correctly points to the
            // next group
            ListNode prev = groupNext;
            ListNode curr = groupPrev.next;

            while (curr != groupNext) {
                ListNode tempNext = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tempNext;
            }

            // 3. Connect the reversed group back into the main list
            ListNode tailOfReversedGroup = groupPrev.next;  // The old head is now the tail
            groupPrev.next = kthNode;  // Connect previous section to the new group head
            groupPrev = tailOfReversedGroup;
        }
    }
}