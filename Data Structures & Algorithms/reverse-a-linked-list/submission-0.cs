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
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null; // Equivalent to your A
        ListNode curr = head; // Equivalent to your B
        
        while (curr != null) {
            ListNode nextTemp = curr.next; // Equivalent to your C (save next)
            curr.next = prev;              // Reverse the current node's pointer
            prev = curr;                   // Move prev (A) one step forward
            curr = nextTemp;               // Move curr (B) one step forward
        }
        
        // When curr is null, prev is pointing at the new head of the reversed list
        return prev;
    }
}
