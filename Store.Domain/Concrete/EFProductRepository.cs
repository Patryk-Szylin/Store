﻿using System;
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
    }
}
