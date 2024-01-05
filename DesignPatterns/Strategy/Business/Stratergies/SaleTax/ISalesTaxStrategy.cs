using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.SaleTax;

public interface ISalesTaxStrategy
{
    public decimal GetTaxFor(Order order);
}
