public class Solution {
    public int CharacterReplacement(string s, int k) {
        int max = 0;
        int maxFreq = 0;
        int[] count = new int[26]; // Array for letters A-Z
        int l = 0;

        for (int r = 0; r < s.Length; r++) {
            int charIndex = s[r] - 'A';
            count[charIndex]++;
            maxFreq = Math.Max(maxFreq, count[charIndex]);

            // If the remaining characters to replace exceed k, shrink the window
            if ((r - l + 1) - maxFreq > k) {
                count[s[l] - 'A']--;
                l++;
            }

            max = Math.Max(max, r - l + 1);
        }

        return max;
    }
}