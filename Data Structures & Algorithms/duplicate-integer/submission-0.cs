public class Solution {
    public bool hasDuplicate(int[] nums) {
        var freq=new Dictionary<int,int>();
        foreach(int i in nums){
            if(freq.ContainsKey(i)){
                return true;
            }else{
                freq[i]=1;
            }
        }
        return false;
    }
}