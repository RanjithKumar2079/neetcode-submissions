public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0;
        int r = numbers.Length - 1;
        while(l<r && l< numbers.Length && r > 0){
            int sum = numbers[l]+numbers[r];
            if(sum == target){
                return new int[] {l+1, r+1};
            }else if(sum > target){
                r--;
            }else{
                l++;
            }
        }
        return new int[] {-1, -1};
    }
}
