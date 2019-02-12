namespace ProductStore.Dtos
{
    public class ProductForCreation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Owner { get; set; }
        public Picture Picture { get; set; }
    }
}
