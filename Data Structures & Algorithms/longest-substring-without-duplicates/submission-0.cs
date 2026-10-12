public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var dict = new Dictionary<char, int>();
        var max = 0;
        var r = 0;
        var l = 0;
        foreach(var c in s){
            if(!dict.ContainsKey(s[r])){
                dict[s[r]]=1;
                r++;
                max=Math.Max(max,dict.Count);
                continue;
            }
            while(dict.ContainsKey(s[r])){
                dict.Remove(s[l]);
                l++;
            }
            dict[s[r]]=1;
            r++;
            max=Math.Max(max,dict.Count);
        }
        return max;
    }
}
