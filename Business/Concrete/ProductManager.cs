using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal iProductDal)
        {
            _productDal = iProductDal;
        }
        //business codes
        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdeed);
        }

        public IDataResult <List<Product>> GetAll()
        {
            //Business Codes 
            //does have the authority
            return new DataResult<List<Product>>(_productDal.GetAll(),true,"Product Listed");
        }

        public IDataResult <List<Product>> GetAllByCategoryId(int id)
        {
            return (IDataResult<List<Product>>)_productDal.GetAll(p => p.CategoryId == id);
        }

        public IDataResult <Product> GetById(int productId)
        {
            return (IDataResult<Product>)_productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return (IDataResult<List<Product>>)_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return (IDataResult<List<ProductDetailDto>>)_productDal.GetProductDetails();
        }
    }
}
