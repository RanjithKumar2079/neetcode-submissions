public class Solution {
    public int LastStoneWeight(int[] stones) {
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (int stone in stones) {
            maxHeap.Enqueue(stone, stone);
        }

        while (maxHeap.Count > 1) {
            int y = maxHeap.Dequeue();  // Heaviest
            int x = maxHeap.Dequeue();  // Second heaviest

            if (y > x) {
                int remaining = y - x;
                maxHeap.Enqueue(remaining, remaining);
            }
        }

        return maxHeap.Count == 1 ? maxHeap.Dequeue() : 0;
    }
}
