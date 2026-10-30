/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null)
            return null;

        // Step 1: Interweave cloned nodes with original nodes
        Node curr = head;
        while (curr != null) {
            Node clone = new Node(curr.val);
            clone.next = curr.next;
            curr.next = clone;
            curr = clone.next;
        }

        // Step 2: Assign random pointers for the cloned nodes
        curr = head;
        while (curr != null) {
            if (curr.random != null) {
                curr.next.random = curr.random.next;
            }
            curr = curr.next.next;
        }

        // Step 3: Separate the lists and restore the original list
        Node dummy = new Node(0);
        Node copyTail = dummy;
        curr = head;

        while (curr != null) {
            Node clone = curr.next;
            copyTail.next = clone;
            copyTail = clone;

            // Restore original list
            curr.next = clone.next;
            curr = curr.next;
        }

        return dummy.next;
    }
}
