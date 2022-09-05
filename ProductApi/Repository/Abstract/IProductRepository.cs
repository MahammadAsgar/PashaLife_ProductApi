using ProductApi.Data;
using ProductApi.Data.ViewModel;
using System.Collections.Generic;

namespace ProductApi.Services
{
    public interface IProductRepository
    {
        Product AddProduct(ProductVM productVM);
        Product UpdateProduct(int id,ProductVM productVM);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts ();
    }
}
