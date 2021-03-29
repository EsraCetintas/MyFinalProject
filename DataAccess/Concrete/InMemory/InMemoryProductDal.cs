﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15,CategoryId=1},
                new Product{ProductId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3,CategoryId=2},
                new Product{ProductId=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2,CategoryId=2},
                new Product{ProductId=4,ProductName="Klavye",UnitPrice=150,UnitsInStock=65,CategoryId=2},
                new Product{ProductId=5,ProductName="Fare",UnitPrice=85,UnitsInStock=1,CategoryId=2}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
          Product  productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;

        }
    }
}