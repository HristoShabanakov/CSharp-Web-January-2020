using Andreys.Models;
using Andreys.ViewModels.Products;
using System.Collections;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(ProductAddInputModel productAddInputModel);

        //Using IEnumerable to display data. 
        //IEnumerable does not contain method add.
        //We can return a database object.
        IEnumerable<Product> GetAll();

         Product GetById(int id);

        void DeleteById(int id);
            
    }
}
