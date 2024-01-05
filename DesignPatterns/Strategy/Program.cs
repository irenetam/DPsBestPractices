using Strategy.Business.Models;
using Strategy.Business.Stratergies.Invoice;
using Strategy.Business.Stratergies.SaleTax;

var order = new Order
{
    ShippingDetails = new ShippingDetails
    {
        OriginCountry = "Sweden",
        DestinationCountry = "Sweden"
    },
    SalesTaxStrategy = new SwedenSalesTaxStrategy()
};

order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

Console.WriteLine(order.GetTax());

order.InvoiceStrategy = new FileInvoiceStrategy();
order.FinalizeOrder();