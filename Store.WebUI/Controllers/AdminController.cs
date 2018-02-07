using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository _repository;

        public AdminController(IProductsRepository repo)
        {
            _repository = repo;
        }


        public ViewResult Index()
        {
            return View(_repository.Products);
        }

        public ViewResult Edit(int productID)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }

    }
}