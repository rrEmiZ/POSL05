using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppCore.DbModels
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        public double DicuntValue { get; set; }

        public string Code { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int? CategoryId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }


    }
}
