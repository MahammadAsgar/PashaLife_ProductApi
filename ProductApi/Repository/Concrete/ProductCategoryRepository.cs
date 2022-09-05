using ProductApi.Data;
using ProductApi.Data.ViewModel;
using ProductApi.Repository;
using ProductApi.Services.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
           
        }

        public ProductCategory UpdateProductCategory(int id, ProductCategoryVM categoryVM)
        {
            var category=_context.ProductCategories.Where(x=>x.ProductCategoryId==id).FirstOrDefault();
            category.ProductCategoryName = categoryVM.ProductCategoryName;
            _context.ProductCategories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public ProductCategory AddProductCategory(ProductCategoryVM categoryVM)
        {
            var category = new ProductCategory()
            {
                ProductCategoryName = categoryVM.ProductCategoryName,
            };
            _context.ProductCategories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteProductCategory(int id)
        {
            var category = _context.ProductCategories.Where(x => x.ProductCategoryId == id).FirstOrDefault();
            _context.ProductCategories.Remove(category);
            _context.SaveChanges();
        }

        public ProductCategory GetProductCategory(int id)
        {
            return _context.ProductCategories.Where(x => x.ProductCategoryId == id).FirstOrDefault();

        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return _context.ProductCategories;

        }
    }
}
