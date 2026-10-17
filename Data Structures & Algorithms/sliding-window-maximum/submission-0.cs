public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums == null || nums.Length == 0 || k <= 0)
            return new int[0];

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        int resultIndex = 0;

        // We store INDICES in our deque (LinkedList)
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < n; i++) {
            // 1. Remove indices that are out of the current window (i - k)
            if (deque.Count > 0 && deque.First.Value <= i - k) {
                deque.RemoveFirst();
            }

            // 2. Remove elements from the back that are smaller than the current element
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
                deque.RemoveLast();
            }

            // 3. Add the current element's index to the back
            deque.AddLast(i);

            // 4. Once the window has reached size k, record the maximum (which is at the front)
            if (i >= k - 1) {
                result[resultIndex++] = nums[deque.First.Value];
            }
        }

        return result;
    }
}
