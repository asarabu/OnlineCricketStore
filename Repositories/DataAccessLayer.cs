using OnlineCricketStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCricketStore.Models;

namespace OnlineCricketStore.Repositories
{
    public class DataAccessLayer : IDataAccessLayer
    {
        CricketEntities db = new CricketEntities();
        public List<ProductsVM> GetAllProducts()
        {
            var data = db.Products.Select(x => new ProductsVM
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                    PricePerItem = x.PricePerItem,
                    AvgCustomerRating = x.AvgCustomerRating
                }).ToList();

            //var myList = db.Products
            //    .Join(
            //        db.ProductAttributes,
            //        comp => comp.ProductID,
            //        sect => sect.ProductID,
            //        (comp, sect) => new { Product = comp, ProductAttribute = sect })
            //    .Join(
            //        db.Attributes,
            //        cs => cs.ProductAttribute.AttributeId,
            //        dsi => dsi.AttributeId,
            //        (cs, dsi) => new { cs.Product, cs.ProductAttribute, dsi })
            //    .Select(c => new ProductsVM{
            //        ProductID = c.Product.ProductID,
            //        ProductName = c.Product.ProductName,
            //        PricePerItem = c.Product.PricePerItem,
            //        AvgCustomerRating = c.Product.AvgCustomerRating,
            //        ProductAttrID = c.ProductAttribute.ProductAttrID,
            //        AttributeName = c.dsi.AttributeName,
            //        AttributeId = c.dsi.AttributeId
            //    }).ToList();

            return data;

        }

        public List<ProductsVM> GetAttributes()
        {
            var data = db.Attributes.Select(y => new ProductsVM
            {
                AttributeId = y.AttributeId,
                AttributeName = y.AttributeName
            }).ToList();

            return data;
        }

        public List<ProductsVM> GetProductAttributes(int ProdId)
        {
            List<ProductsVM> myList = new List<ProductsVM>();

            var data = db.ProductAttributes.Where(x => x.ProductID == ProdId).ToList();

            var list = data.Select(i => i.AttributeId).ToList();

            foreach (var item in list)
            {
                var newList = new ProductsVM();
                var u = data.FirstOrDefault(t => t.AttributeId == item);
                newList.ProductAttrID = u.ProductAttrID;
                if (u.AttributeId != null) newList.AttributeId = (int) u.AttributeId;
                newList.Attribute = u.Attribute;

                myList.Add(newList);
            }

            return myList;
        }

        public ProductsVM GetProductById(int id)
        {
            var data = db.Products.Where(u => u.ProductID == id).Select(x => new ProductsVM
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                PricePerItem = x.PricePerItem,
                AvgCustomerRating = x.AvgCustomerRating
            }).FirstOrDefault();

            return data;
        }
    }
}