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
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxSoFar) {
        // Base case: if the node is null, it contributes 0 good nodes
        if (node == null) {
            return 0;
        }

        int goodCount = 0;

        // If the current node's value is greater than or equal to the path maximum, it's a good
        // node
        if (node.val >= maxSoFar) {
            goodCount = 1;
            maxSoFar = node.val;  // Update the max value for subsequent children
        }

        // Traverse left and right subtrees, adding their good node counts
        goodCount += Dfs(node.left, maxSoFar);
        goodCount += Dfs(node.right, maxSoFar);

        return goodCount;
    }
}
