using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCricketStore.ViewModels;

namespace OnlineCricketStore.Repositories
{
    public interface IDataAccessLayer
    {
        List<ProductsVM> GetAllProducts();
        ProductsVM GetProductById( int id);

        List<ProductsVM> GetAttributes();
        List<ProductsVM> GetProductAttributes(int ProdId);
    }
}
