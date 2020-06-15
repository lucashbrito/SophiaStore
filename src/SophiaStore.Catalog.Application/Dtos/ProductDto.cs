using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SophiaStore.Catalog.Application.Dtos
{
    public class ProductDto
    {
        [Key]
        [Required(ErrorMessage = "{0} Field is required")]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public string Description { get; set; }
        public bool Active { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} field is required and has at least {1}")]
        [Required(ErrorMessage = "{0} Field is required")]
        public int StockQuantity { get; set; }
        
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
    }

    public class CategoryDto
    {
        [Key]
        [Required(ErrorMessage = "{0} Field is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} Field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Field is required")]
        public int Code { get; set; }
    }
}
