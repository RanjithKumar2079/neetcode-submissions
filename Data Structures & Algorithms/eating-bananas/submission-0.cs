public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = 0;

        // Find the maximum pile size to set our upper bound
        foreach (int pile in piles) {
            right = Math.Max(right, pile);
        }

        int bestK = right;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (CanEatAll(piles, h, mid)) {
                bestK = mid;      // Record valid speed
                right = mid - 1;  // Try to find a smaller (slower) valid speed
            } else {
                left = mid + 1;  // Too slow, need a higher speed
            }
        }

        return bestK;
    }

    private bool CanEatAll(int[] piles, int h, int k) {
        long hoursSpent = 0;
        foreach (int pile in piles) {
            // Equivalent to Math.Ceiling((double)pile / k) using integer arithmetic
            hoursSpent += (pile + k - 1) / k;
        }
        return hoursSpent <= h;
    }
}
