using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        [Display(Name = "Category Name", Prompt = "Enter Category Name")]
        [Required(ErrorMessage = "Category Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category Name length between 3-50")]
        public string ProductCategoryName { get; set; }
    }
}
