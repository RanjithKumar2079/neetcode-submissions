public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var final = new Dictionary<string, List<string>>();
        foreach(var item in strs){
            var total = new int[26];
            for(int i=0;i < item.Length; i++){
                total[item[i] - 'a']+=1;
            }
            string key = string.Join(",", total);
            if (final.ContainsKey(key)){
                final[key].Add(item);
            }else{
                final[key] = new List<string>{item};
            }
        }
        return final.Values.ToList<List<string>>();
    }
}
