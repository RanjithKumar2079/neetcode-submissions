public class KthLargest {
    private readonly int _k;
    // Element and priority are both the integer value so smaller numbers are dequeued first.
    private readonly PriorityQueue<int, int> _minHeap;

    public KthLargest(int k, int[] nums) {
        _k = k;
        _minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums) {
            Add(num);
        }
    }

    public int Add(int val) {
        _minHeap.Enqueue(val, val);

        if (_minHeap.Count > _k) {
            _minHeap.Dequeue();
        }

        return _minHeap.Peek();
    }
}
