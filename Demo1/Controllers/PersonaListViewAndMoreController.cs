using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;


namespace Demo1.Controllers
{
    public class PersonaListViewAndMoreController : Controller    
    {
        private Demo1Context db = new Demo1Context();

        // GET: /PersonaListViewAndMore/
        public ActionResult Index()
        {
            return View();
        }

        // Get: /PersonaListViewAndMore/JsonDataChart
        public ActionResult KendoDonuts()
        {
            return View();
        }

        // Get: /PersonaListViewAndMore/JsonDataChart
        public JsonResult JsonDataChart()
        {
            int countPersonas = db.Personas.Count();
            var query = from p in db.Personas
                        group p by new { p.Profesion } into g
                        select new ItemChartProfesion
                        {
                            Profesion = g.Key.Profesion,
                            Total = g.Count(),
                        };

            var data = query.ToList();
            data.ForEach(z => z.Porcentaje = Convert.ToDouble(Math.Round(z.Total * countPersonas / 100, 2)));

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}
