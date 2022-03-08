using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMI.Models
{
    public class Jumbo
    {
        [Required(ErrorMessage = "Please Enter Binary Value")]
        [Display(Name = "Binary :-")]
        public float BBI { get; set; }

        [Display(Name = "Answer :-")]
        public int Answer { get; set; }
        /*
                [Required(ErrorMessage = "Please Enter Decimal Value")]
                [Display(Name = "Decimal :-")]
                public float DEC { get; set; }

                [Display(Name = "Answer :-")]
                public int Answer1 { get; set; }*/
    }
}