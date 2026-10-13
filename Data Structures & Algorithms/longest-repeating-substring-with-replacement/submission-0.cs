public class Solution {
    public int CharacterReplacement(string s, int k) {
        var max=0;
        var freq=0;
        var dict=new Dictionary<char, int>();
        var l=0;
        var r=0;
        while(l<=r && r<s.Length){
            dict[s[r]] = dict.ContainsKey(s[r]) ? dict[s[r]] + 1: 1;
            freq=Math.Max(freq, dict[s[r]]);
            if((r-l+1)-freq>k){
                dict[s[l]]-=1;
                l++;
            }
            max=Math.Max(max, r-l+1);
            r++;
        }
        return max;
    }
}
