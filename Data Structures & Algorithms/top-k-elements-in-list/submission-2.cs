public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freq = new Dictionary<int, int>();
        foreach(var item in nums){
            if(freq.ContainsKey(item)){
                freq[item]+=1;
            }else{
                freq[item]=1;
            }
        }

        var lfreq = freq.OrderByDescending(a => a.Value).Take(k);
        var result = new List<int>();
        foreach(var val in lfreq){
            result.Add(val.Key);
        }

        return result.ToArray();
    }
}
