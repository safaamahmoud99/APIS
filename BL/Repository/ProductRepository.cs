using System;
using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class ProductRepository:BaseRepository<Product>
    {
        private DbContext EC_DbContext;

        public ProductRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }


        public IEnumerable<Product> GetAllProduct()
        {
            return GetAll()
                .Include(p => p.subCategory)
                .Include(p => p.Reviews)
                .ToList();
        }
        public IEnumerable<Product> GetAllProductDevices()
        {
            return GetAll().Where(p => (p.subCategory.Category.mainCategory.Name) == "Electronics").ToList();
        }
        public IEnumerable<Product> GetAllProductInAspecificSubCategory(int id)
        {
            return GetAll().Where(p => p.SubCategoryID == id).ToList();
        }
        public IEnumerable<Product> GetAllProductBetweenTwoPrice(int id,double min_price,double max_price)
        {
            return GetAll().Where(p=>p.Price>=min_price && p.Price<=max_price &&p.SubCategoryID==id).ToList();
        }
        public IEnumerable<Product> GetAllProductInAspecificBrand(int subcategoryid,int brandid)
        {
            return GetAll().Where(p => p.BrandID == brandid&&p.SubCategoryID==subcategoryid).ToList();
        }
        public IEnumerable<Product> GetAllProductfilteredBySize(int subcategoryid, string size)
        {
            return GetAll().Where(p => p.SubCategoryID == subcategoryid && p.Size == size);
        }
        public IEnumerable<Product> GetAllProductFilteredByCategoryID(int id)
        {
            return GetAll().Where(p => p.subCategory.Category.ID == id).ToList();
        }
        public IEnumerable<Product> GetAllProductFilteredByBrandID(int id)
        {
            return GetAll().Where(p => p.BrandID == id).ToList();
        }

        public IEnumerable<Product> GetAllProductFilteredBysupplier(int supplierid)
        {
            return GetAll().Where(p => p.SupplierID == supplierid).ToList();
        }
        public IEnumerable<Product> GetAllProductFilteredBySizeonly(string size)
        {
            return GetAll().Where(p => p.Size == size).ToList();
        }
        public IEnumerable<Product> GetAllProductFilteredByColor(string color)
        {
            return GetAll().Where(p => p.Color ==color).ToList();
        }
        public IEnumerable<Product> GetAllProductFilteredByMainCategory(int id)
        {
            return GetAll().Where(p => p.subCategory.Category.mainCategory.ID == id).ToList();
        }
        public IEnumerable<Product> GetAllProductFilteredByPrice(double min_price,double max_price)
        {
            return GetAll().Where(p => p.Price >= min_price && p.Price <= max_price).ToList();
        }
        public int GetAllProductCountinSubCategory(int id)
        {
            return GetAll().Where(p => p.subCategory.ID == id).Count();
        }
        public IEnumerable<Product> GetNewArrivalsProduct(int numberOfProducts = 0)
        {
            IEnumerable<Product> newArivailsProducts;
            if (numberOfProducts <= 0)
                newArivailsProducts = DbSet
                    .Include(p => p.Reviews)
                    .Include(p => p.subCategory)
                    .OrderByDescending(p => p.ID).Take(10).ToList();
            else
                newArivailsProducts = DbSet
                    .Include(p => p.Reviews)
                    .Include(p => p.subCategory)
                    .OrderByDescending(p => p.ID).Take(numberOfProducts).ToList();

            return newArivailsProducts;
        }



        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }

        public bool CheckProductExists(Product product)
        {
            return GetAny(l => l.ID == product.ID);
        }
        public Product GetProductById(int id)
        {
            var product = DbSet.AsNoTracking()
                .Include(p => p.subCategory)
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.ID == id);
            return product;
        }

        internal IEnumerable<Product> GetRandomRelatedProducts(int categoryId, int numberOfProducts)
        {
            var query = DbSet
                    .Include(p => p.subCategory)
                    .Include(p => p.Reviews)
                    .Where(p => p.SubCategoryID == categoryId)
                    .OrderBy(p => Guid.NewGuid())
                    .Take(numberOfProducts);
            var x = query.ToQueryString();
            return query;
        }

        public override IEnumerable<Product> GetPageRecords(int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;

            var products = DbSet
                .Skip(pageNumber * pageSize).Take(pageSize)
                .Include(p => p.subCategory)
                .Include(p => p.Reviews)
                .ToList();
            return products;
        }
        public int CountProducts(int categoryId = 0, int colorId = 0)
        {
            if (categoryId != 0)
            {
                return DbSet.Where(p => p.SubCategoryID == categoryId).Count();
            }
            return DbSet.Count();
        }

    }
}
