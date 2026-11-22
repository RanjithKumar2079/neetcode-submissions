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

public class Codec {
    private const string NullToken = "null";
    private const char Delimiter = ',';

    // Encodes a tree to a single string using pre-order DFS.
    public string Serialize(TreeNode root) {
        var sb = new StringBuilder();
        BuildString(root, sb);
        return sb.ToString();
    }

    private void BuildString(TreeNode node, StringBuilder sb) {
        if (sb.Length > 0) {
            sb.Append(Delimiter);
        }

        if (node == null) {
            sb.Append(NullToken);
            return;
        }

        sb.Append(node.val);
        BuildString(node.left, sb);
        BuildString(node.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if (string.IsNullOrEmpty(data)) {
            return null;
        }

        string[] tokens = data.Split(Delimiter);
        int index = 0;
        return BuildTree(tokens, ref index);
    }

    private TreeNode BuildTree(string[] tokens, ref int index) {
        if (index >= tokens.Length) {
            return null;
        }

        string token = tokens[index++];
        if (token == NullToken) {
            return null;
        }

        var node = new TreeNode(int.Parse(token));
        node.left = BuildTree(tokens, ref index);
        node.right = BuildTree(tokens, ref index);
        return node;
    }
}
