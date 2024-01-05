using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Shipping;

public interface IShippingStrategy
{
    void Ship(Order order);
}
