using moi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace moi.Models
{
    public class WishlistViewModel
    {
        public Wishlist WishlistItem { get; set; }
        public ProductImage ProductImage { get; set; }
    }
}