namespace RedBerylBookStore.ServiceModels
{
    using System.Collections.Generic;
    using Common.Enums;

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}