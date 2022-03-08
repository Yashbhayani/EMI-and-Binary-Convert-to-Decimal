using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMI.Models
{
    public class emi
    {
        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Amount :-")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Rate :-")]
        public float Rate { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Time :-")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Amount Number")]
        [Display(Name = "EMI = ")]
        public float Emi { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Amount Number")]
        [Display(Name = "Total Payment = ")]
        public float TP { get; set; }


        [Required(ErrorMessage = "Please Enter Valid Amount Number")]
        [Display(Name = "Total Interest Payable = ")]
        public float TIP { get; set; }

        public List<EmiCalculation> EmiCalculations { get;set; }

        
    }

    public class EmiCalculation
    {
        public float RP { get; set; }

        public float BP { get; set; }

        public float IP { get; set; }

        public string Month { get; set; }

        public float RT { get; set; }

    }
}