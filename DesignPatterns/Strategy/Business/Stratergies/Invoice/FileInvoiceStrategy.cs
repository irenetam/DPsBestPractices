﻿using Strategy.Business.Models;

namespace Strategy.Business.Stratergies.Invoice;

public class FileInvoiceStrategy : InvoiceStrategy
{
    public override void Generate(Order order)
    {
        using(var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt"))
        {
            stream.Write(GenerateTextInvoice(order));
            stream.Flush();
        }
    }
}
