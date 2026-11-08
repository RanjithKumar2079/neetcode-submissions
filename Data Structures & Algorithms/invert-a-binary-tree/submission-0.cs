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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
            return null;

        // Recursively invert the left and right subtrees
        TreeNode leftSub = InvertTree(root.left);
        TreeNode rightSub = InvertTree(root.right);

        // Swap the left and right pointers
        root.left = rightSub;
        root.right = leftSub;

        return root;
    }
}
