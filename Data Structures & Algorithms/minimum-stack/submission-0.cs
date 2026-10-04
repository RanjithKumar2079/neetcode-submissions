public class MinStack {
    // The stack stores a ValueTuple: (int val, int currentMin)
    private Stack<(int val, int currentMin)> stack;

    public MinStack() {
        stack = new Stack<(int val, int currentMin)>();
    }

    public void Push(int val) {
        if (stack.Count == 0) {
            // If empty, the current value is the minimum
            stack.Push((val, val));
        } else {
            // Get the minimum of the current top element
            int currentMin = stack.Peek().currentMin;
            // Push the new value along with the updated minimum
            stack.Push((val, Math.Min(val, currentMin)));
        }
    }

    public void Pop() {
        stack.Pop();
    }

    public int Top() {
        return stack.Peek().val;
    }

    public int GetMin() {
        return stack.Peek().currentMin;
    }
}
