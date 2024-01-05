using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.SaleTax;

public class SwedenSalesTaxStrategy : ISalesTaxStrategy
{
    public decimal GetTaxFor(Order order)
    {
        var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
        var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();
        if (destination == origin)
        {
            return order.TotalPrice * 0.25m;
        }

        return 0;
    }
}
