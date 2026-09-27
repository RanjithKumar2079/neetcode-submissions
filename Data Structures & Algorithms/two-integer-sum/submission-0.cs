public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var prev = new Dictionary<int, int>();
        for(int i=0; i < nums.Length; i++) {
            var needed = target - nums[i];
            if (prev.ContainsKey(needed)){
                return new int[]{prev[needed], i};
            }else {
                prev[nums[i]] = i;
            }
        }
        return [-1, -1];
    }
}
