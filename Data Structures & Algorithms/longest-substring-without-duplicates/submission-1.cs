public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var dict = new Dictionary<char, int>();
        int max = 0, r = 0, l = 0;
        
        while (r < s.Length) {
            if (!dict.ContainsKey(s[r])) {
                dict[s[r]] = 1;
                max = Math.Max(max, r - l + 1);
                r++;
            } else {
                dict.Remove(s[l]);
                l++;
            }
        }
        return max;
    }
}