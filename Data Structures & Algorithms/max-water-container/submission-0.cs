public class Solution {
    public int MaxArea(int[] heights) {
        int n = heights.Length;
        int l = 0, r = n - 1;
        int max = 0;
        while (l < r) {
            int lh = heights[l];
            int rh = heights[r];
            int area = Math.Min(lh, rh);
            area = area * (r - l);
            max = area > max ? area : max;
            if (lh >= rh) {
                r--;
            } else {
                l++;
            }
        }
        return max;
    }
}
