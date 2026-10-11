public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        var l = 0;
        var r = n - 1;
        var left_max = 0;
        var right_max = 0;
        var total_water = 0;
        while (l < r) {
            if (height[l] < height[r]) {
                if (height[l] >= left_max) {
                    left_max = height[l];
                } else {
                    total_water += left_max - height[l];
                }
                l++;  // Move inward
            } else {
                if (height[r] >= right_max) {
                    right_max = height[r];
                } else {
                    total_water += right_max - height[r];
                }
                r--;  // Move inward
            }
        }
        return total_water;
    }
}