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
            //var rto = ReturnDataPaginationOrderToMaping<Persona>(pagination, query);
            //var rto  = KendoUiHelper.
            //return rto;
            var gridData = KendoUiHelper.ReturnGridData<Persona>(kendoRequest, ref query);
            //var gridData = _observationDao.GetGridData(pagging);

            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        

        //[HttpPost]
        //public JsonResult Create(Persona dto)
        //{
        //    var dtoNew = _observationDao.Create(dto);
        //    dto.Id = dtoNew.Id;
        //    return Json(dto);
        //}

        //[HttpPut]
        //public JsonResult Update(Persona dto)
        //{
        //    var data = _observationDao.Update(dto);
        //    return Json(data);
        //}

        //[HttpDelete]
        //public JsonResult Delete(Persona dto)
        //{
        //    var data = _observationDao.Delete(dto.Id);
        //    return Json(data);
        //}

    }
}