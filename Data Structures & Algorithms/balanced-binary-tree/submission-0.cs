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
    public bool IsBalanced(TreeNode root) {
        return CheckHeight(root) != -1;
    }

    private int CheckHeight(TreeNode node) {
        // Base case: An empty tree is balanced and has a height of 0
        if (node == null)
            return 0;

        // Recursively check left subtree height
        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1)
            return -1;  // If left is unbalanced, propagate -1

        // Recursively check right subtree height
        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1)
            return -1;  // If right is unbalanced, propagate -1

        // If current node's subtrees differ in height by more than 1, return -1
        if (Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }

        // Otherwise, return the height of the current node
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
