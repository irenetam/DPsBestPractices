using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Shipping;

public class DhlShppingStrategy : IShippingStrategy
{
    public void Ship(Order order)
    {
        using(var client = new HttpClient())
        {
            /// TODO: Implement DHL Intergration
            Console.WriteLine("Order is shipped with DHL");
        }
    }
}
