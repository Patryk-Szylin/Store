using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Store.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]                 // this tells the MVC to render the property as hidden form element
        public int ProductID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]                  // and this allows me to specify how value is represented and edited
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}
