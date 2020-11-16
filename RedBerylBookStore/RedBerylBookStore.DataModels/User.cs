namespace RedBerylBookStore.DataModels
{
    using System;
    using Base;
    using Common.Enums;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<int>, IBaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public bool IsActive { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}