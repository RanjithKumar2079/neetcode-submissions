public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        Dictionary<char, int> s1Dict = new Dictionary<char, int>();
        Dictionary<char, int> s2Dict = new Dictionary<char, int>();

        // 1. Count char map s1 in dict
        foreach (char c in s1) {
            if (s1Dict.ContainsKey(c)) s1Dict[c]++;
            else s1Dict[c] = 1;
        }

        // 2. Count char map s2 in dict with s1 length (initial window)
        int l = 0;
        int r = s1.Length - 1;
        
        for (int i = l; i <= r; i++) {
            char c = s2[i];
            if (s2Dict.ContainsKey(c)) s2Dict[c]++;
            else s2Dict[c] = 1;
        }

        // 3. Slide and check window
        while (r < s2.Length) {
            // Check if all s1 characters and counts match s2Dict
            bool isMatch = true;
            foreach (var kvp in s1Dict) {
                if (!s2Dict.ContainsKey(kvp.Key) || s2Dict[kvp.Key] != kvp.Value) {
                    isMatch = false;
                    break; // break inner loop if mismatch found
                }
            }

            if (isMatch) return true; // break both loops and return true

            // If we are at the end of s2, stop sliding
            if (r == s2.Length - 1) break;

            // Remove/decrement current l key in s2 dict and increment l
            char leftChar = s2[l];
            s2Dict[leftChar]--;
            if (s2Dict[leftChar] == 0) {
                s2Dict.Remove(leftChar);
            }
            l++;

            // Increment r, then add/increment new r key in s2 dict
            r++;
            char rightChar = s2[r];
            if (s2Dict.ContainsKey(rightChar)) s2Dict[rightChar]++;
            else s2Dict[rightChar] = 1;
        }

        return false;
    }
}