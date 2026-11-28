public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        if (tasks == null || tasks.Length == 0)
            return 0;

        int[] freq = new int[26];
        int maxFreq = 0;

        foreach (char task in tasks) {
            int idx = task - 'A';
            freq[idx]++;
            if (freq[idx] > maxFreq) {
                maxFreq = freq[idx];
            }
        }

        int maxCount = 0;
        for (int i = 0; i < 26; i++) {
            if (freq[i] == maxFreq) {
                maxCount++;
            }
        }

        int formulaCycles = (maxFreq - 1) * (n + 1) + maxCount;
        return Math.Max(tasks.Length, formulaCycles);
    }
}
