public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right) {
            // Finding the middle index (using left + (right - left) / 2 to prevent potential
            // integer overflow)
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) {
                return mid;  // Found the target, return its index
            } else if (nums[mid] < target) {
                left = mid + 1;  // Target is in the right half
            } else {
                right = mid - 1;  // Target is in the left half
            }
        }

        return -1;
    }
}
