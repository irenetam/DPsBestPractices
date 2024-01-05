using Strategy.Business.Models;
using Strategy.Business.Stratergies.Invoice;
using Strategy.Business.Stratergies.SaleTax;
using Strategy.Business.Stratergies.Shipping;

#region Input
Console.WriteLine("Please select an origin country: ");
var origin = Console.ReadLine().Trim();

Console.WriteLine("Choose one of the following shipping providers.");
Console.WriteLine("1. PostNord (Swedish Postal Service)");
Console.WriteLine("2. DHL");
Console.WriteLine("3. USPS");
Console.WriteLine("4. Fedex");
Console.WriteLine("5. UPS");
Console.WriteLine("Select shipping provider: ");
var provider = Convert.ToInt32(Console.ReadLine().Trim());

Console.WriteLine("Choose one of the following invoice delivery options.");
Console.WriteLine("1. E-mail");
Console.WriteLine("2. File (download later)");
Console.WriteLine("3. Mail");
Console.WriteLine("Select invoice delivery options: ");
var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());
#endregion

var order = new Order
{
    ShippingDetails = new ShippingDetails
    {
        OriginCountry = "Sweden",
        DestinationCountry = "Sweden"
    },
    SalesTaxStrategy = GetSalesTaxStrategyFor(origin),
    InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
    ShippingStrategy = GetShippingStrategyFor(provider)
};

order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

Console.WriteLine(order.GetTax());

order.InvoiceStrategy = new FileInvoiceStrategy();
order.FinalizeOrder();

ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
{
    if(origin.ToLowerInvariant() == "sweden")
    {
        return new SwedenSalesTaxStrategy();
    }
    else if(origin.ToLowerInvariant() == "usa")
    {
        return new USAStateSalesTaxStratergy();
    }
    else
    {
        throw new Exception("Unsupported shipping region");
    }
}

IInvoiceStrategy GetInvoiceStrategyFor(int invoiceOption)
{
    switch (invoiceOption)
    {
        case 1:
            return new EmailInvoiceStrategy();
        case 2:
            return new FileInvoiceStrategy();
        case 3: 
            return new PrintOnDemandInvoiceStrategy();
        default:
            throw new Exception("Unsupported invoice delivery option");
    }
}

IShippingStrategy GetShippingStrategyFor(int provider)
{
    switch (provider)
    {
        case 1: return new SwedishPostalServiceShippingStrategy();
        case 2: return new DhlShppingStrategy();
        case 3: return new UnitedStatesPostalServiceShippingStrategy();
        case 4: return new FedexShippingStrategy();
        case 5: return new UpsShippingStrategy();
        default: throw new Exception("Unsupported shipping method");

    }
}

public class OrderAmountComparer : IComparer<Order>
{
    public int Compare(Order? x, Order? y)
    {
        var xTotal = x.TotalPrice;
        var yTotal = y.TotalPrice;
        if (xTotal == yTotal)
        {
            return 0;
        }
        else if (xTotal > yTotal)
        {
            return 1;
        }

        return -1;
    }
}
public class OrderOriginComparer : IComparer<Order>
{
    public int Compare(Order? x, Order? y)
    {
        var xDest = x.ShippingDetails.OriginCountry.ToLowerInvariant();
        var yDest = y.ShippingDetails.OriginCountry.ToLowerInvariant();
        if (xDest == yDest)
        {
            return 0;
        }
        else if (xDest[0] > yDest[0])
        {
            return 1;
        }

        return -1;
    }
}