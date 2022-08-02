namespace Algorithm.Laboratory.SlidingWindow;

public class EasySlidingWindow
{
    #region + MaxProfit

    /// <summary>
    /// 121. Best Time to Buy and Sell Stock
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1)
            return 0;
        int left = 0, right = 1, maxProfit = 0;
        while (right < prices.Length)
        {
            if (prices[left] < prices[right])
                maxProfit = Math.Max(maxProfit, (prices[right] - prices[left]));
            else
                left = right;

            right++;
        }

        return maxProfit;
    }

    #endregion
}