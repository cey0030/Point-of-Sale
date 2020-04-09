using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

public class PointOfSaleTerminal
{
    private List<Product> pricingData;
    private Dictionary<Product, int> productCounts = new Dictionary<Product, int>();

    public void SetPricing(string json)
    {
        pricingData = JsonConvert.DeserializeObject<List<Product>>(json);
    }

    /// <summary>
    /// Adds a scanned product to productCounts.
    /// </summary>
    /// <param name="productCode">The code of a scanned product.</param>
    public void ScanProduct(string productCode)
    {
        var product = GetProduct(productCode);
        if (product != null)
        {
            if (productCounts.ContainsKey(product))
                productCounts[product]++;
            else
                productCounts[product] = 1;
        }
    }

    public Product GetProduct(string productCode)
    {
        return pricingData.SingleOrDefault(product => product.code == productCode);
    }

    public decimal CalculateTotal()
    {
        return productCounts.Sum(product => product.Key.CalculateTotal(product.Value));
    }
}