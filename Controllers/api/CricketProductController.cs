using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCricketStore.Repositories;
using OnlineCricketStore.ViewModels;

namespace OnlineCricketStore.Controllers.api
{
    public class CricketProductController : ApiController
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        //public CricketProductController()
        //{
                
        //}
        public CricketProductController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        // GET api/<controller>
        public IEnumerable<ProductsVM> GetAllProducts()
        {
            return _dataAccessLayer.GetAllProducts();
        }

        // GET api/<controller>/5
        public ProductsVM GetProductById(int id)
        {
            return _dataAccessLayer.GetProductById(id);
        }

        // POST api/<controller>
        public IEnumerable<ProductsVM> GetProductAttributes(int ProdId)
        {
            return _dataAccessLayer.GetProductAttributes(ProdId);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}