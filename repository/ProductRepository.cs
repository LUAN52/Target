using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tarefa.data;
using Tarefa.Models;

namespace Tarefa.repository
{
    public class ProductRepository : IRepository<Product>
    {
        
        public ProductRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public int Delete(Product entity)
        {
             Context.Products.Remove(entity);
            var save =Context.SaveChanges();

           return save;
        }

        public List<Product> GetAll()
        {
            return Context.Products.ToList();
        }

         public List<Product> GetByIdClient(string id)
        {   
            return Context.Products.Where(i=>i.Client.Id==id).ToList();
        }

        public Product GetOneProductByIdClient(int id,string idClient)
        {
            var allProducts = GetByIdClient(idClient);
            var oneProduct = allProducts.Where(i=>i.Id==id).FirstOrDefault();

            return oneProduct;
                   

        }
        public int insert(Product entity)
        {
             Context.Products.Add(entity);
           var result = Context.SaveChanges();

           return result;
        }

        public List<Product> Query(Expression<Func<Product, bool>> filter)
        {
            var result = Context.Products.Where(filter);
            return result.ToList();
        }

        public int Update(Product entity)
        {
             Context.Products.Update(entity);
           var result = Context.SaveChanges();

            return result;
        }

      
    }
}