using Strategy.Business.Models;
using System.Net.Mail;
using System.Net;

namespace Strategy.Business.Stratergies.Invoice;

public class EmailInvoiceStrategy : InvoiceStrategy
{
    public override void Generate(Order order)
    {
        var body = GenerateTextInvoice(order);
        using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
        {
            NetworkCredential credentials = new NetworkCredential("USERNAME", "PASSWORD");
            client.Credentials = credentials;

            MailMessage mail = new MailMessage("YOUR EMAIL", "YOUR EMAIL")
            {
                Subject = "We've created an invoice for your order",
                Body = body
            };

            client.Send(mail);
        }
    }
}
