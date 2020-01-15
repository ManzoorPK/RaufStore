using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rauf_Gaming_Web.Models
{
    public class CartProduct
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public string Photo
        {
            get;
            set;
        }
        public double Quantity
        {
            get;
            set;
        }
        public double Total
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
    }
}