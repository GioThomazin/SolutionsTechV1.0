﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SolutionsTech.Business.Entity
{
    public class Product
    {
        [Key]
        public long IdProduct { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public long IdBrand { get; set; }

        [NotMapped]
        public List<Brand?>? Brands { get; set; }
    }
}
