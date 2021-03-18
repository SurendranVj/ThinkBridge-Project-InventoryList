using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MvcDbModel
    {
        public int InventoryID { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<int> Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<int> Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<int> InventoryValue { get; set; }
    }
}