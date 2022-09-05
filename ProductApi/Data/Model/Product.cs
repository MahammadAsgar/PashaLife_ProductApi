using System;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data
{
    public class Product
    {
        public int  ProductId { get; set; }

        [Display(Name ="Product Name",Prompt = "Enter Product Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name length between 3-50")]
        public string ProductName { get; set; }

        [Display(Name = "Product Category Id", Prompt = "Enter ProductCategoryId")]
        [Required(ErrorMessage = "CategoryId is Required")]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        [Display(Name = "Product Price", Prompt = "Enter Product Price")]
        [Required(ErrorMessage = "Price is Required")]
        [Range(0,10000,ErrorMessage ="Price is between 0-10000")]
        public double  Price { get; set; }

        [Display(Name = "Product Created Date", Prompt = "Enter Product Created Date")]
        [Required(ErrorMessage = "Created Date is Required")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Product State Id", Prompt = "Enter Product StateId")]
        [Required(ErrorMessage = "StateId is Required")]
        public int StateId { get; set; }
        public State State { get; set; }

        [Display(Name = "Product IsDelete", Prompt = "Enter Product IsDelete")]
        [Required(ErrorMessage = "IsDelete is Required")]
        public bool IsDeleted { get; set; }
    }
}
