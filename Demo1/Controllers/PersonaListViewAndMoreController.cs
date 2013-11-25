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
        // GET: /PersonaListViewAndMore/
        public ActionResult Index()
        {
            return View();
        }
    }
}