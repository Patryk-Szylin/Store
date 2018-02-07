using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;
using Store.Domain.Abstract;
using Store.Domain.Entities;


namespace Store.Domain.Concrete
{
    public class EmailSettings
    {
        public string m_mailToAddress = "patrykszylin93@gmail.com";
        public string m_mailFromAddress = "store@example.com";
        public bool m_useSSL = true;
        public string m_username = "MySmtpUsername";
        public string m_password = "MySmtpPassword";
        public string m_serverName = "smtp.example.com";
        public int m_serverPort = 587;
        public bool m_writeAsFile = true;
        public string m_fileLocation = @"c:\store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings _emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            _emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailSettings.m_useSSL;
                smtpClient.Host = _emailSettings.m_serverName;
                smtpClient.Port = _emailSettings.m_serverPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.m_username, _emailSettings.m_password);

                if (_emailSettings.m_writeAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailSettings.m_fileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to: ")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");


                MailMessage mailMessage = new MailMessage(
                    _emailSettings.m_mailFromAddress,
                    _emailSettings.m_mailToAddress,
                    "New Order Submitted",
                    body.ToString());

                if (_emailSettings.m_writeAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                //smtpClient.Send(mailMessage);
            }


        }
    }
}
