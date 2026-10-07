public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;
        
        // Pair position and calculate unimpeded time for each car
        // Cast target - position to double to avoid integer division issues
        (int position, double time)[] cars = new (int, double)[n];
        for (int i = 0; i < n; i++) {
            double time = (double)(target - position[i]) / speed[i];
            cars[i] = (position[i], time);
        }

        // Sort cars by position descending (farthest ahead/closest to target first)
        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        int fleets = 0;
        double maxTime = 0;

        // Iterate from closest to target to farthest back
        foreach (var car in cars) {
            // If this car takes strictly longer than the current fleet ahead,
            // it cannot catch up and becomes the leader of a new fleet.
            if (car.time > maxTime) {
                fleets++;
                maxTime = car.time; // Update current fleet bottleneck time
            }
            // Otherwise, car.time <= maxTime:
            // It catches up and merges into the existing fleet ahead (inheriting maxTime).
        }

        return fleets;
    }
}
