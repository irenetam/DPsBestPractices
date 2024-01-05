using Newtonsoft.Json;
using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Invoice;

public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
{
    public void Generate(Order order)
    {
        using (var client = new HttpClient())
        {
            var content = JsonConvert.SerializeObject(order);

            client.BaseAddress = new Uri("https://pluralsight.com");

            client.PostAsync("/print-on-demand", new StringContent(content));
        }
    }
}
