using System;
using System.Collections.Generic;

namespace DibawinWebsite.Models
{
    public partial class Sizes
    {
        //public Sizes()
        //{
        //    ProductFeature = new HashSet<ProductFeature>();
        //}

        public int Id { get; set; }
        public string Size { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
    }
}
