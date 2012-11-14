using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OrderImport
{
    public class OrderParser
    {
        public IEnumerable<Order> Parse(string orderXml)
        {
            string xmlPattern = "(?<start>>)(?<content>.+?(?<!>))(?<end><)|(?<start>\")(?<content>.+?)(?<end>\")";
            string xmlResult = Regex.Replace(orderXml, xmlPattern, m =>
                        m.Groups["start"].Value +
                        HttpUtility.HtmlEncode(HttpUtility.HtmlDecode(m.Groups["content"].Value)) +
                        m.Groups["end"].Value);

            var orderElements = XElement.Parse(xmlResult);
            var orders = from order in orderElements.Elements()
                         select
                             new Order
                                 {
                                     FirstName = order.Element("customer").Element("firstname").Value,
                                     LastName = order.Element("customer").Element("lastname").Value,
                                     Title = order.Element("customer").Element("title").Value,
                                     JournalId = Convert.ToInt32(order.Element("orderitem").Element("id").Value),
                                     JournalName = order.Element("orderitem").Element("journal").Value,
                                     Currency = order.Element("orderitem").Element("currency").Value,
                                     StartDate = DateTime.Parse(order.Element("orderitem").Element("start").Value)
                                 };
            return orders;
        }
    }
}
