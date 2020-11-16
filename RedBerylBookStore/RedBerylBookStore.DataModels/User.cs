namespace RedBerylBookStore.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Base;
    using Common.Enums;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<int>, IBaseModel
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Book> Books { get; set; }

        [Required]
        public int LastModifiedBy { get; set; }

        [Required]
        public DateTime LastModifiedOn { get; set; }
    }
}