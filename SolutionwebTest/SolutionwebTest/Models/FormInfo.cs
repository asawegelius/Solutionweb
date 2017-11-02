using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionwebTest.Models
{
    public class FormInfo
    {
        public long Id { get; set; }
        [Required]
        [RegularExpression("(^[-+]?\\d*$)", ErrorMessage = "Please enter valid Number")]
        public int Number { get; set; }
        [Required]
        [RegularExpression("(^[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?$)", ErrorMessage = "Please enter valid Float")]
        public decimal DecimalNumber { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date dd/mm/yyyy")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(50, ErrorMessage="Max length 50")]
		public string TextMax50 { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}
