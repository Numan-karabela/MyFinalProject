using DataAccess.Abstract;
using Entities.Concreet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreet.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product Entity)
        {
            using (NortwindContext context= new NortwindContext())
            {
                var addedEntity=context.Add(Entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Delete(Product Entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var deletedEntity = context.Add(Entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();

            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product Entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var updatedEntity = context.Add(Entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
