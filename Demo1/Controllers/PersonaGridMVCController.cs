using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;
using Demo1.KendoHelper;


namespace Demo1.Controllers
{
    public class PersonaGridMVCController : Controller    
    {
        Demo1Context db = new Demo1Context();
        public PersonaGridMVCController()
        {

        }

        // GET: /PersonaGridMVC/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetGridData()
        {
            var kendoRequest = new KendoGridQueryModel();
            var query = db.Personas.AsQueryable();            
            var gridData = KendoUiHelper.ReturnGridData<Persona>(kendoRequest, query);
            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Persona dto)
        {
            var dtoNew = db.Personas.Add(dto);
            db.SaveChanges();
            dto.Id = dtoNew.Id;
            return Json(dto);
        }

        [HttpPut]
        public JsonResult Update(Persona dto)
        {
            var data = db.Personas.Attach(dto);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
            return Json(data);
        }

        [HttpDelete]
        public JsonResult Delete(Persona dto)
        {
            var data = db.Personas.Attach(dto);
            db.Personas.Remove(data);
            db.SaveChanges();
            return Json(data);
        }

    }
}