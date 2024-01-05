using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Invoice;

public interface IInvoiceStrategy
{
    public void Generate(Order order);
}
