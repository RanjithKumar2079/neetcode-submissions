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
    private int _maxSum;

    public int MaxPathSum(TreeNode root) {
        _maxSum = int.MinValue;
        MaxGain(root);
        return _maxSum;
    }

    private int MaxGain(TreeNode node) {
        if (node == null) {
            return 0;
        }

        // Only include left/right branches if they contribute positively
        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);

        // Path passing through `node` as its highest point (turning point)
        int currentPathSum = node.val + leftGain + rightGain;
        _maxSum = Math.Max(_maxSum, currentPathSum);

        // Return max gain if continuing the path upward through the parent
        return node.val + Math.Max(leftGain, rightGain);
    }
}
