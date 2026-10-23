public class TimeMap {
    private Dictionary<string, List<(string Value, int Timestamp)>> map;

    public TimeMap() {
        map = new Dictionary<string, List<(string Value, int Timestamp)>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (!map.ContainsKey(key)) {
            map[key] = new List<(string, int)>();
        }
        // Since LeetCode guarantees timestamps are strictly increasing for set calls,
        // we can just append it to the end, and it remains sorted!
        map[key].Add((value, timestamp));
    }

    public string Get(string key, int timestamp) {
        if (!map.ContainsKey(key)) {
            return "";
        }

        var list = map[key];
        int left = 0;
        int right = list.Count - 1;
        string result = "";

        // Binary search to find the largest timestamp <= target timestamp
        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (list[mid].Timestamp <= timestamp) {
                result = list[mid].Value;  // Valid candidate found, save it
                left =
                    mid + 1;  // Try to see if there's a closer, larger valid timestamp to the right
            } else {
                right = mid - 1;  // Timestamp is too large, search left
            }
        }

        return result;
    }
}
