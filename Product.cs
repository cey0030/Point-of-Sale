using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string code { get; set; }
    public Dictionary<int, decimal> pricing { get; set; }

    /// <summary>
    /// Calculates total cost for one item.
    /// </summary>
    /// <param name="amountBought">The total number of a product scanned.</param>
    /// <returns>The total cost of one type of scanned product.</returns>
    public decimal CalculateTotal(int amountBought)
    {
        decimal total = 0;
        foreach (var price in pricing.OrderByDescending(amount => amount.Key))
        {
            int bundlesSold = amountBought / price.Key;
            total += bundlesSold * price.Value;
            amountBought -= bundlesSold * price.Key;
        }
        return total;
    }
}