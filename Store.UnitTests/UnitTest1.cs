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
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //Arrange - define an html helper - we need to do tihs
            // in order to apply the 

            HtmlHelper myHelper = null;

            // Arrange - create paginginfo data
            PagingInfo pi = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            //MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
        }
    }
}
