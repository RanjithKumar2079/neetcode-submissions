public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freq = new Dictionary<int, int>();
        List<int>[] result = new List<int>[nums.Length+1];
        for (int i = 0; i < nums.Length + 1; i++)
        {
            result[i] = new List<int>();
        }
        for(int i=0; i < nums.Length; i++){
            if(freq.ContainsKey(nums[i])){
                freq[nums[i]]++;
            }else{
                freq[nums[i]]=1;
            }
        }
        foreach(var item in freq){
            //Console.WriteLine("Key " + item.Key + " Value " + item.Value);
            var o = item.Value;
            result[o].Add(item.Key);
            //Console.WriteLine($"[{string.Join(", ", result[o])}]");
        }

        var output = new int[k];
        var count = 0;
        var index = nums.Length;
        while(index>= 0 && count < k){
            if(result[index].Count > 0 ) {
                //Console.WriteLine(result[index][0] + " "+ index);
                foreach(var r in result[index]){
                    if(count < k){
                        output[count] = r;
                        count++;
                    }
                }
            }
            index--;
        }

        return output;
    }
}
