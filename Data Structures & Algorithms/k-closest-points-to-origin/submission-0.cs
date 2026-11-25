public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var maxHeap = new PriorityQueue<int[], long>();

        foreach (var point in points) {
            long x = point[0];
            long y = point[1];
            long distSq = x * x + y * y;

            maxHeap.Enqueue(point, -distSq);

            if (maxHeap.Count > k) {
                maxHeap.Dequeue();
            }
        }

        int[][] result = new int [k][];
        for (int i = 0; i < k; i++) {
            result[i] = maxHeap.Dequeue();
        }

        return result;
    }
}
