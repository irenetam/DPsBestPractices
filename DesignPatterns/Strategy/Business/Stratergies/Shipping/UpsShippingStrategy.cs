using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Shipping;

public class UpsShippingStrategy : IShippingStrategy
{
    public void Ship(Order order)
    {
        using (var client = new HttpClient())
        {
            /// TODO: Implement UPS Shipping Integration

            Console.WriteLine("Order is shipped with UPS");
        }
    }
}
