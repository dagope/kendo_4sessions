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
    public class PersonaGridWebApi2Controller: Controller    
    {
        // GET: /PersonaGridWebApi2/
        public ActionResult Index()
        {
            return View();
        }
    }
}