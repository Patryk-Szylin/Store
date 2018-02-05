using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Store.Domain.Abstract;
using Store.Domain.Entities;
using System.Web.Mvc;
using Store.WebUI.Controllers;
using Store.WebUI.Models;
using Store.WebUI.HtmlHelpers;

namespace Store.UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"}
            });
        }
    }
}
