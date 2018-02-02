using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductsRepository _repository;

        public ProductController(IProductsRepository productRepository)
        {
            this._repository = productRepository;
        }

        public ViewResult List()
        {
            return View(_repository.Products);
        }
    }
}