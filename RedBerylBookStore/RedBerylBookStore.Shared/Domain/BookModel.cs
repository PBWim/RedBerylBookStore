namespace RedBerylBookStore.Shared.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "The User Id is required")]
        public int UserId { get; set; }

        public UserModel User { get; set; }
    }
}
