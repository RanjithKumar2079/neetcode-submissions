public class Solution {
    public bool IsAnagram(string s, string t) {
        var n = s.Count();
        var m = t.Count();
        if (m != n) {
            return false;
        }
        var freqmap=new Dictionary<char,int>();
        for(int i=0; i<n; i++){
            if(freqmap.ContainsKey(s[i])){
                freqmap[s[i]]+=1;
            }
            else{
                freqmap[s[i]]=1;
            }
        }

        for(int j=0; j<m; j++){
            if(freqmap.ContainsKey(t[j])){
                freqmap[t[j]]-=1;
                if(freqmap[t[j]] < 0){
                    return false;
                }
                if(freqmap[t[j]] == 0){
                    freqmap.Remove(t[j]);
                }
            }else {
                return false;
            }
        }

        if(freqmap.Count() > 0){
            return false;
        }
        return true;
    }
}
