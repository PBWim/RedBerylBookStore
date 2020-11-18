namespace RedBerylBookStore.Shared.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;

    public class UserModel : LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public bool IsActive { get; set; }
    }
}