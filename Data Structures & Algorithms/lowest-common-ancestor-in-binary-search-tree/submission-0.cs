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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode current = root;

        while (current != null) {
            // If both p and q are greater than current, go right
            if (p.val > current.val && q.val > current.val) {
                current = current.right;
            }
            // If both p and q are smaller than current, go left
            else if (p.val < current.val && q.val < current.val) {
                current = current.left;
            }
            // We have found the split point (LCA)
            else {
                return current;
            }
        }

        return null;
    }
}
