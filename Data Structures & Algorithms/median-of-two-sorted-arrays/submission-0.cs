public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length) {
            return FindMedianSortedArrays(nums2, nums1);
        }
        
        int m = nums1.Length;
        int n = nums2.Length;
        int low = 0, high = m;
        
        while (low <= high) {
            int partitionX = (low + high) / 2;
            int partitionY = (m + n + 1) / 2 - partitionX;
            
            // Handle edge cases where partition is at the extreme left or right
            int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int minRightX = (partitionX == m) ? int.MaxValue : nums1[partitionX];
            
            int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            int minRightY = (partitionY == n) ? int.MaxValue : nums2[partitionY];
            
            // Check if we have found the correct partition
            if (maxLeftX <= minRightY && maxLeftY <= minRightX) {
                // If total number of elements is even
                if ((m + n) % 2 == 0) {
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                } 
                // If total number of elements is odd
                else {
                    return (double)Math.Max(maxLeftX, maxLeftY);
                }
            } 
            else if (maxLeftX > minRightY) {
                // Too far right in nums1, move left
                high = partitionX - 1;
            } 
            else {
                // Too far left in nums1, move right
                low = partitionX + 1;
            }
        }
        throw new ArgumentException("The input arrays are not sorted.");
    }
}
