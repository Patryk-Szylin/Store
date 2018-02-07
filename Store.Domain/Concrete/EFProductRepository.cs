using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        EFDbContext _context = new EFDbContext();

        public IEnumerable<Product> Products {
            get { return _context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                _context.Products.Add(product);
            } else
            {
                Product dbEntry = _context.Products.Find(product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }

            _context.SaveChanges();
        }
    }
}
