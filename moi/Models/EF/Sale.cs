using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace moi.Models.EF
{
    [Table("tb_Sale")]
    public class Sale
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaGiamGia { get; set; }
        public int GiamGia { get; set; }
    }
}