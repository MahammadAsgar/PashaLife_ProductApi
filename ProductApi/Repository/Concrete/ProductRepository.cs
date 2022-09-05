using ProductApi.Data;
using ProductApi.Data.ViewModel;
using ProductApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public Product AddProduct(ProductVM productVM)
        {
            var product = new Product()
            {
                ProductName = productVM.ProductName,
                ProductCategoryId = productVM.ProductCategoryId,
                Price = productVM.Price,
                CreatedDate = productVM.CreatedDate,
                StateId = productVM.StateId,
                IsDeleted = productVM.IsDeleted,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        
        public Product GetProduct(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product UpdateProduct(int id, ProductVM productVM)
        {
            var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            product.ProductName = productVM.ProductName;
            product.ProductCategoryId = productVM.ProductCategoryId;
            product.Price = productVM.Price;
            product.CreatedDate = productVM.CreatedDate;
            product.StateId = productVM.StateId;
            product.IsDeleted = productVM.IsDeleted;
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
