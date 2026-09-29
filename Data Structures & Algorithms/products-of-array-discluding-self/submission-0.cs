public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] pre = new int[nums.Length];
        int[] post = new int[nums.Length];
        int len = nums.Length;
        var current = 1;
        pre[0]=post[len-1]=1;
        var index=0;
        for(int m=1; m<len; m++){
            current*=nums[index];
            pre[m]=current;
            index++;
        }
        var result = new int[len];
        result[len-1]=pre[len-1]*post[len-1];
        current = 1;
        index = len-1;
        for(int n=len-2; n>=0; n--){
            current*=nums[index];
            post[n]=current;
            index--;
            //Console.WriteLine(pre[n]);
            //Console.WriteLine(post[n]);
            result[n]=pre[n]*post[n];
        }

        return result;
    }
}
