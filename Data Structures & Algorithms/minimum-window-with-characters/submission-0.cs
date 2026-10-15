public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) {
            return "";
        }

        // 1. Map frequencies for t
        Dictionary<char, int> tMap = new Dictionary<char, int>();
        foreach (char c in t) {
            if (tMap.ContainsKey(c))
                tMap[c]++;
            else
                tMap[c] = 1;
        }

        int required = tMap.Count;  // Number of unique characters needed from t
        int formed = 0;             // Number of unique characters currently meeting the quota
        Dictionary<char, int> windowMap = new Dictionary<char, int>();

        int l = 0, r = 0;
        int minLen = int.MaxValue;
        int minLeft = 0;

        // 2. Expand window with r
        while (r < s.Length) {
            char c = s[r];
            if (windowMap.ContainsKey(c))
                windowMap[c]++;
            else
                windowMap[c] = 1;

            // If this character's frequency fully matches its requirement in t
            if (tMap.ContainsKey(c) && windowMap[c] == tMap[c]) {
                formed++;
            }

            // 3. Shrink window with l once all requirements are met
            while (l <= r && formed == required) {
                char leftChar = s[l];

                // Update minimum window tracker if current is smaller
                if (r - l + 1 < minLen) {
                    minLen = r - l + 1;
                    minLeft = l;
                }

                // Remove left character from window and contract
                windowMap[leftChar]--;
                if (tMap.ContainsKey(leftChar) && windowMap[leftChar] < tMap[leftChar]) {
                    formed--;  // Window is no longer valid, we lost a required quota
                }

                l++;
            }

            r++;
        }

        // Return the minimum substring found, or empty string if none existed
        return minLen == int.MaxValue ? "" : s.Substring(minLeft, minLen);
    }
}
