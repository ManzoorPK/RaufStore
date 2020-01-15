using Rauf_Gaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Rauf_Gaming.Classes
{
    public class Games
    {
        public List<ProductV1> GetProductList()
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.ProductV1.ToList().
                           OrderByDescending(e => e.ProductId).ToList();

                return lst;
            }
        }


    }
}