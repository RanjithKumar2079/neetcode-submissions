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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;

        int carry = 0;

        // Traverse both lists until we run out of nodes AND there is no leftover carry
        while (l1 != null || l2 != null || carry != 0) {
            int sum = carry;

            // Add value from l1 if available
            if (l1 != null) {
                sum += l1.val;
                l1 = l1.next;
            }

            // Add value from l2 if available
            if (l2 != null) {
                sum += l2.val;
                l2 = l2.next;
            }

            // Calculate the new carry (e.g., 15 / 10 = 1)
            carry = sum / 10;

            // Get the current digit to store (e.g., 15 % 10 = 5)
            int digit = sum % 10;

            // Attach the new digit node to our result list
            curr.next = new ListNode(digit);
            curr = curr.next;
        }

        // Return the head of the newly built list (skipping the dummy anchor)
        return dummy.next;
    }
}
