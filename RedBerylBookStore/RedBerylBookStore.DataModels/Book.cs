namespace RedBerylBookStore.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Book : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int LastModifiedBy { get; set; }

        [Required]
        public DateTime LastModifiedOn { get; set; }
    }
}