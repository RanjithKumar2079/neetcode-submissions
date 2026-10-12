public class Solution {
    public int MaxProfit(int[] prices) {
        var l = 0;
        var r = 1;
        var profit = 0;
        while(l<r && r<prices.Length){
            if(prices[l]<=prices[r]){
                profit=Math.Max(profit,prices[r]-prices[l]);
                r++;
            }else{
                l=r;
                r++;
            }
        }
        return profit;
    }
}
