﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle, SqlServer, Postgres, MongoDb den geliyormuş gibi
            _products = new List<Product> 
            { 
                new Product{ProductId =1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId =2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId =3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId =4, CategoryId = 2, ProductName = "Klaye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId =5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ = Language Integrated Query (Dile gömülü Sorgulama)
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //Aşağıdaki kod yukaırdaki foreach i yapıyor
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);

            _products.Remove(productToUpdate);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ID sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
