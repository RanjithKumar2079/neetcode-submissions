public class Solution {
    public bool IsValid(string s) {
        var mon = new Stack<char>();
        var open = new Dictionary<char, char> { { ')', '(' }, { '}', '{' }, { ']', '[' } };

        foreach (char c in s) {
            if (open.ContainsKey(c)) {
                // TryPop attempts to pop and check the value at the same time
                if (!mon.TryPop(out char last) || last != open[c]) {
                    return false;
                }
            } else {
                mon.Push(c);
            }
        }
        return mon.Count == 0;
    }
}