/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        var stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (current != null || stack.Count > 0) {
            // Reach the leftmost node of the current subtree
            while (current != null) {
                stack.Push(current);
                current = current.left;
            }

            // Process the next smallest node
            current = stack.Pop();
            k--;

            if (k == 0) {
                return current.val;
            }

            // Move to the right subtree
            current = current.right;
        }

        throw new ArgumentOutOfRangeException(nameof(k),
                                              "k is larger than the number of nodes in the BST.");
    }
}
