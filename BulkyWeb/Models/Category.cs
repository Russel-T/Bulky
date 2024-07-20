using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        // Primary key attribute for Category Model: Id property
        [Key]
        public int Id { get; set; }

        // Required attribute to ensure the Name property is not null or empty
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        // Default Constructor
        public Category()
        {
        }
    }
}

