using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OrderImport;

namespace OrderImportTests
{
    [TestFixture]
    public class OrderParserTests
    {
        public string XmlTest1 { get; set; }
        public OrderParser OrderParser { get; set; }

        [SetUp]
        public void SetUp()
        {
            OrderParser = new OrderParser();

            XmlTest1 = 
            "<orders>" +
                "<order>" +
                    "<customer>" +
                        "<title>Mr</title>" +
                        "<firstname>Canabrana</firstname>" +
                        "<lastname>Lammer</lastname>" +
                    "</customer>" +
                    "<orderitem>" +
                        "<id>26</id>" +
                        "<journal>Splinter Removal Weekly</journal>" +
                        "<start>2009-01-01</start>" +
                        "<currency>GBP</currency>" +
                    "</orderitem>" +
                "</order>" +
            "</orders>";
        }

        //TODO Need to add more tests. I'm only testing one order

        [Test]
        public void Parse_OneOrder()
        {
            var orders = OrderParser.Parse(XmlTest1);
            var orderList = new List<Order>(orders);
            Assert.AreEqual(orderList.Count, 1);
            Assert.AreEqual(orderList[0].Title, "Mr");
            Assert.AreEqual(orderList[0].FirstName,"Canabrana");
            Assert.AreEqual(orderList[0].LastName,"Lammer");
            Assert.AreEqual(orderList[0].JournalId, 26);
            Assert.AreEqual(orderList[0].JournalName, "Splinter Removal Weekly");
            Assert.AreEqual(orderList[0].Currency, "GBP");
            Assert.AreEqual(orderList[0].StartDate.ToShortDateString(),"01/01/2009");
        }
    }
}
