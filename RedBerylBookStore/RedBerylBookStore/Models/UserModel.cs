namespace RedBerylBookStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;

    public class UserModel : LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Confirm Password is required"), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public UserRole Role { get; set; }
    }
}