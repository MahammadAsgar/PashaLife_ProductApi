using ProductApi.Data;
using ProductApi.Data.ViewModel;
using System.Collections.Generic;

namespace ProductApi.Services.Abstract
{
    public interface IProductCategoryRepository
    {
        ProductCategory AddProductCategory(ProductCategoryVM categoryVM);
        ProductCategory UpdateProductCategory(int id, ProductCategoryVM categoryVM);
        void DeleteProductCategory(int id);
        ProductCategory GetProductCategory(int id);
        IEnumerable<ProductCategory> GetAllProductCategories();
    }
}
