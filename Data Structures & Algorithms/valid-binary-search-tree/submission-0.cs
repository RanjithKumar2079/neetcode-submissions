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
    public bool IsValidBST(TreeNode root) {
        return Validate(root, null, null);
    }

    private bool Validate(TreeNode node, long? min, long? max) {
        // An empty tree/node is valid
        if (node == null)
            return true;

        // The current node's value must be strictly between min and max bounds
        if ((min.HasValue && node.val <= min.Value) || (max.HasValue && node.val >= max.Value)) {
            return false;
        }

        // Recursively validate subtrees:
        // - Going left updates the upper bound (max) to the current node's value
        // - Going right updates the lower bound (min) to the current node's value
        return Validate(node.left, min, node.val) && Validate(node.right, node.val, max);
    }
}
