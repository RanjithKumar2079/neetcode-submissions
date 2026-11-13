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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (root == null) {
            return false;
        }

        // Check if the trees match starting from the current node
        if (IsSameTree(root, subRoot)) {
            return true;
        }

        // Otherwise, recursively check the left and right subtrees
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode p, TreeNode q) {
        // Both nodes are null -> identical
        if (p == null && q == null) {
            return true;
        }
        // One is null or values don't match -> not identical
        if (p == null || q == null || p.val != q.val) {
            return false;
        }

        // Recursively check left and right children
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}