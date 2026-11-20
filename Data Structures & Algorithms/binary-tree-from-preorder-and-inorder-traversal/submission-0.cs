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
    private int _preorderIndex;
    private Dictionary<int, int> _inorderIndexMap;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        _preorderIndex = 0;
        _inorderIndexMap = new Dictionary<int, int>(inorder.Length);

        for (int i = 0; i < inorder.Length; i++) {
            _inorderIndexMap[inorder[i]] = i;
        }

        return Build(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] preorder, int inorderLeft, int inorderRight) {
        if (inorderLeft > inorderRight) {
            return null;
        }

        int rootVal = preorder[_preorderIndex++];
        var root = new TreeNode(rootVal);

        int inorderRootIndex = _inorderIndexMap[rootVal];

        // Build left subtree first to match preorder's Root -> Left -> Right order
        root.left = Build(preorder, inorderLeft, inorderRootIndex - 1);
        root.right = Build(preorder, inorderRootIndex + 1, inorderRight);

        return root;
    }
}
