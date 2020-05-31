using System.ComponentModel.DataAnnotations;

namespace Solution
{
    public class Order
    {
        public int Id { get; set; }
        public int SelectedProductId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeToGet { get; set; }
        public int Cost { get; set; }
    }
}