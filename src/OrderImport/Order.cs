using System;

namespace OrderImport
{
    public class Order
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JournalId { get; set; }
        public string JournalName { get; set; }
        public DateTime StartDate { get; set; }
        public string Currency { get; set; }
    }
}
