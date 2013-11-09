using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace CodeJewelModels
{
   public class Category
    {
        public int Id { get; set; }
       [Required]
        public string Name { get; set; }
    }
}
