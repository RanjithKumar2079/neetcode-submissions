public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;
        (int position, double time)[] cars = new(int, double)[n];

        for (int i = 0; i < n; i++) {
            double time = (double)(target - position[i]) / speed[i];
            cars[i] = (position[i], time);
        }

        // Sort cars by position descending (closest to target first)
        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        Stack<double> stack = new Stack<double>();

        foreach (var car in cars) {
            stack.Push(car.time);

            // If the car we just pushed takes LESS or EQUAL time than the fleet ahead of it,
            // it catches up and merges into that fleet. We pop it because it doesn't form
            // a distinct new fleet.
            if (stack.Count >= 2) {
                double currentCarTime = stack.Pop();   // temporarily pop top
                double fleetAheadTime = stack.Peek();  // look at the fleet ahead

                if (currentCarTime <= fleetAheadTime) {
                    // Merges into fleetAheadTime -> don't push currentCarTime back!
                } else {
                    // Forms a new distinct fleet -> put it back on the stack
                    stack.Push(currentCarTime);
                }
            }
        }

        // The remaining elements on the stack represent the fleet leaders.
        return stack.Count;
    }
}
