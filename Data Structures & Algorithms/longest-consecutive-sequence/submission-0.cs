public class Solution {
    public int LongestConsecutive(int[] nums) {
        var dict=new Dictionary<int,int>();
        foreach(var item in nums){
            dict[item] = 1;
        }
        var start=new List<int>();
        foreach(var itm in dict){
            if(!dict.ContainsKey(itm.Key - 1)){
                start.Add(itm.Key);
            }
        }
        var count=0;
        while(start.Count() > 0){
            var len=1;
            var s=start[0];
            var nxt=s+1;
            while(dict.ContainsKey(nxt)){
                len+=1;
                nxt++;
            }
            if(len > count) {
                count = len;
            }
            start.Remove(s);
        }

        return count;
    }
}
