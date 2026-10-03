public class Solution {
    public bool IsValid(string s) {
        var mon = new Stack<char>();
        var open = new Dictionary<char, char>{{')','('},{'}','{'},{']','['}};
        foreach(char c in s){
            if(open.ContainsKey(c)){
                if(mon.TryPeek(out char last)){
                if(last == open[c]){
                    mon.Pop();
                    continue;
                }else{
                    return false;
                }
                }else{
                    return false;
                }
            }else {
                mon.Push(c);
            }
        }
        return mon.Count == 0;
    }
}
