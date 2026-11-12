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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }
        
        // Base case 2: One node is null or the values don't match
        if (p == null || q == null || p.val != q.val) {
            return false;
        }
        
        // Recursively check both the left and right subtrees
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
