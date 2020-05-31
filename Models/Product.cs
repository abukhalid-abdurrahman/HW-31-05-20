namespace Solution
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public int Cost { get; set; }
    }
}