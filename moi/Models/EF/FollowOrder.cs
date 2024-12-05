using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace moi.Models.EF
{
    public class FollowOrder
    {
        public FollowOrder()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string trangthai { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}