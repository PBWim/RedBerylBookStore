namespace RedBerylBookStore.ServiceModels
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}