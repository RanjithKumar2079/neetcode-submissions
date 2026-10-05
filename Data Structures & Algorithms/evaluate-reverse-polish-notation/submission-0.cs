public class Solution {
    public int EvalRPN(string[] tokens) {
        var operand = new Stack<int>();
        var operato = new string[] {"+","-","*","/"};
        foreach(var token in tokens){
            if(operato.Contains(token) && operand.Count > 0){
                var second = operand.Pop();
                var first = operand.Pop();
                var res = 0;
                switch (token){
                    case "+":
                        res = first + second;
                        break;
                    case "-":
                        res = first - second;
                        break;
                    case "*":
                        res = first * second;
                        break;
                    case "/":
                        res = (int)first/second;
                        break;
                }
                operand.Push(res);
            }else{
                operand.Push(int.Parse(token));
            }
        }

        return operand.Pop();
    }
}
