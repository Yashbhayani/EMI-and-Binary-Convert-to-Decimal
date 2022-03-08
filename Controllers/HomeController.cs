using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMI.Models;

namespace EMI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Jumbo asd = new Jumbo();
            return View(asd);
        }

        [HttpPost]
        public ActionResult About(Jumbo asd)
        {
            int r, d = 0;
            for (int i = 0; asd.BBI != 0; ++i) {
                r = (int)(asd.BBI % 10);
                asd.BBI = asd.BBI / 10;
                d = (int)(d + (r) * Math.Pow(2, i));
            }
            asd.Answer = d;
            ViewBag.ID = asd.Answer;
            return View(asd);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Loan Calculator";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(emi model)
        {
           
            List<EmiCalculation> emiCalculations = new List<EmiCalculation>();
            float Emi = ((float)(model.Amount * (((model.Rate / 12) / 100) * Math.Pow((1 + ((model.Rate / 12) / 100)), model.Time) / (Math.Pow((1 + ((model.Rate / 12) / 100)), model.Time) - 1))));
            model.Emi = (float)Math.Round(Emi);

            float TIP = Emi * model.Time;
            model.TIP = (float)Math.Round(TIP);

            float TP = TIP - model.Amount;
            model.TP = (float)Math.Round(TP);

            float rp = model.Amount;
            for (int i = 0; i < model.Time; i++){
            
                DateTime dt = DateTime.Now.AddMonths(i);
                
                EmiCalculation ak = new EmiCalculation();
                ak.IP = rp * (model.Rate / 12) / 100;
                ak.BP = (float)(Math.Round(model.Emi) - ak.IP);
                rp = (float)(Math.Round(rp) - Math.Round(ak.BP));
                ak.RP = rp;
                if (ak.RP <= 0){
                    ak.RP = 0;
                }else if (ak.RP <= 10){
                    ak.RP = 0;
                }

                float AP = (rp * 100) / model.Amount;
                ak.RT = 100 - AP;
                if (ak.RT >= 100) {
                    ak.RT = 100;
                }
                ak.Month = dt.ToString("MMMM, yyyy");
                emiCalculations.Add(ak);
            }
            model.EmiCalculations = emiCalculations;
            return View(model);
        }
    }
}
