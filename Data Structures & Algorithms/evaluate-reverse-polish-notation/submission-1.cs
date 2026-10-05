public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();

        foreach (var token in tokens) {
            // Use a switch expression to handle operators directly, falling back to numbers
            switch (token) {
                case "+":
                case "-":
                case "*":
                case "/":
                    // Pop order matters: second operand is popped first
                    int second = stack.Pop();
                    int first = stack.Pop();

                    int res = token switch {
                        "+" => first + second, "-" => first - second, "*" => first * second,
                        "/" => first / second,  // Integer division is automatic for ints
                        _ => 0
                    };
                    stack.Push(res);
                    break;

                default:
                    // If it's not an operator, parse it directly as an integer
                    stack.Push(int.Parse(token));
                    break;
            }
        }

        return stack.Pop();
    }
}
