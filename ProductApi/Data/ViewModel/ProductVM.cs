using System;

namespace ProductApi.Data.ViewModel
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StateId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
