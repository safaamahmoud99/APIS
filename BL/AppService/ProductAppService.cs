using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public class ProductAppService:BaseAppService
    {
        public ProductAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {
        }
        public IEnumerable<ProductViewModel> GetAllProduct()
        {
            IEnumerable<Product> allProducts = TheUnitOfWork.Product.GetAllProduct();
            return Mapper.Map<IEnumerable<ProductViewModel>>(allProducts);
        }
        public IEnumerable<ProductViewModel> GetAllProductDevices()
        {
            IEnumerable<Product> allProducts =
                 TheUnitOfWork.Product.GetAllProductDevices();
            return Mapper.Map<IEnumerable<ProductViewModel>>(allProducts);

        }
        public IEnumerable<ProductViewModel> GetAllProductInASpecificSubCategory(int id)
        {
            IEnumerable<Product> allProducts =
                 TheUnitOfWork.Product.GetAllProductInAspecificSubCategory(id);
            return Mapper.Map<IEnumerable<ProductViewModel>>(allProducts);

        }
        public IEnumerable<ProductViewModel> GetAllProductBetweenTwoPrice(int id,double min_price, double max_price)
        {
            IEnumerable<Product> products =
                 TheUnitOfWork.Product.GetAllProductBetweenTwoPrice(id,min_price, max_price);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductInAspecificBrands(int subcategoryid,int brandid)
        {
            IEnumerable<Product> products =
                 TheUnitOfWork.Product.GetAllProductInAspecificBrand(subcategoryid,brandid);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductfilteredBySize(int subcategoryid, string size)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductfilteredBySize(subcategoryid, size);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductfilteredByCategoryID(int id)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductFilteredByCategoryID(id);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductFilteredByBrandID(int id)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductFilteredByBrandID(id);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductFilteredBySizeonly(string size)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductFilteredBySizeonly(size);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductFilteredByColor(string color)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductFilteredByColor(color);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetAllProductFilteredByMainCategory(int id)
        {
            IEnumerable<Product> products =
              TheUnitOfWork.Product.GetAllProductFilteredByMainCategory(id);
            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        public int GetAllProductCountinCategory(int id)
        {
            int products =
              TheUnitOfWork.Product.GetAllProductCountinCategory(id);
            return products;
        }
        public IEnumerable<ProductViewModel> GetLatestProduct(int numberOfProducts = 0)
        {
            IEnumerable<Product> allProducts =
                TheUnitOfWork.Product.GetNewArrivalsProduct(numberOfProducts);

            return Mapper.Map<IEnumerable<ProductViewModel>>(allProducts);
        }

        public IEnumerable<ProductViewModel> GetRandomRelatedProducts(int categoryId, int numberOfProducts)
        {
            IEnumerable<Product> relatedProducts = TheUnitOfWork.Product
                .GetRandomRelatedProducts(categoryId, numberOfProducts);
            return Mapper.Map<IEnumerable<ProductViewModel>>(relatedProducts);

        }
        public IEnumerable<ProductViewModel> GetAllProductFilteredByPrice(double min_price, double max_price)
        {
            IEnumerable<Product> relatedProducts = TheUnitOfWork.Product
                .GetAllProductFilteredByPrice(min_price, max_price);
            return Mapper.Map<IEnumerable<ProductViewModel>>(relatedProducts);

        }
        public IEnumerable<ProductViewModel> GetProductsByCategoryIdPagination(int catId, int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;
            var products = TheUnitOfWork.Product.GetWhere(p => p.SubCategoryID == catId)
                .Skip(pageNumber * pageSize).Take(pageSize)
                .Include(p => p.subCategory)
                .ToList(); ;

            return Mapper.Map<List<ProductViewModel>>(products);
        }
        public IEnumerable<ProductViewModel> GetProductsByColorPagination(string color, int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;
            var products = TheUnitOfWork.Product.GetWhere(p => p.Color == color)
                .Skip(pageNumber * pageSize).Take(pageSize)
                .Include(p => p.subCategory)
                .ToList(); ;

            return Mapper.Map<List<ProductViewModel>>(products);
        }

        public IEnumerable<ProductViewModel> GetProductsBySearch(string SearchKeyword)
        {
            var searchRes = TheUnitOfWork.Product.GetWhere(p => p.Name.Contains(SearchKeyword));

            return Mapper.Map<List<ProductViewModel>>(searchRes);
        }
        public ProductViewModel GetProduct(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetProductById(id));
        }
        public bool UpdateProduct(ProductViewModel productViewModel)
        {
            var pro = Mapper.Map<Product>(productViewModel);
            TheUnitOfWork.Product.Update(pro);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool AddNewProduct(ProductViewModel productViewModel)
        {
            if (productViewModel == null)
                throw new ArgumentNullException();
            bool result = false;
            var product = Mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DecreaseQuantity(int prodID, int decresedQuantity)
        {
            var product = TheUnitOfWork.Product.GetById(prodID);
            product.Quantity -= decresedQuantity;
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteProduct(int id)
        {
            bool result = false;
            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        
        public bool CheckProductExists(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return TheUnitOfWork.Product.CheckProductExists(product);
        }
        public int CountEntity(int categoryId = 0, int colorId = 0)
        {
            return TheUnitOfWork.Product.CountProducts(categoryId, colorId);
        }
        public IEnumerable<ProductViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            var products = Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetPageRecords(pageSize, pageNumber));
            return products;
        }

       
    }
}
