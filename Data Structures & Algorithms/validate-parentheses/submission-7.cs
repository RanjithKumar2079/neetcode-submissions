public class Solution {
    public bool IsValid(string s) {
        // Optimization 1: Odd lengths can never be valid
        if (s.Length % 2 != 0)
            return false;

        // Optimization 2: Fixed-size raw array instead of an object stack
        // The stack will never exceed half the length of the string for valid cases
        char[] stack = new char[s.Length / 2];
        int top = 0;  // Our manual stack pointer

        foreach (char c in s) {
            switch (c) {
                    // If opening bracket, push by storing it and incrementing top
                case '(':
                case '{':
                case '[':
                    // If the stack pointer exceeds our allocated half-size, it's invalid
                    if (top >= stack.Length)
                        return false;
                    stack[top++] = c;
                    break;

                    // If closing bracket, pop by decrementing top and matching
                case ')':
                    if (top == 0 || stack[--top] != '(')
                        return false;
                    break;
                case '}':
                    if (top == 0 || stack[--top] != '{')
                        return false;
                    break;
                case ']':
                    if (top == 0 || stack[--top] != '[')
                        return false;
                    break;
            }
        }

        // Valid only if our manual pointer made it back to 0
        return top == 0;
    }
}
