using System.ComponentModel.DataAnnotations;

namespace Solution
{
    public class Basket
    {
        public int Id { get; set; }
        public int SelectedProductID { get; set; }
        public int ProductState { get; set; }
    }
}