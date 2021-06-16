using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCricketStore.ViewModels
{
    public class ProductsVM
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? PricePerItem { get; set; }
        public int? AvgCustomerRating { get; set; }

        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int ProductAttrID { get; set; }
        public string Attribute { get; set; }
        public string Weight { get; set; }
        public string WillowGrade { get; set; }
        public string GripColor { get; set; }

        public IEnumerable<ProductsVM> ProductsVms { get; set; }
    }
}