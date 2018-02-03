using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductsRepository _repository;
        public int m_pageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            this._repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * m_pageSize)
                .Take(m_pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = m_pageSize,
                    TotalItems = _repository.Products.Count()
                }
            };

            return View(model);

        }
    }
}