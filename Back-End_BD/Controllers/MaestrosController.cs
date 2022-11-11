using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Maestros
        public ActionResult Index()
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                return View(dbMaestros.Maestros.ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                Maestros maestros = dbMaestros.Maestros.Find(id);
                if (maestros == null)
                {
                    return HttpNotFound();
                }
                return View(maestros);
            }

        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Maestros mtro)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                dbMaestros.Maestros.Add(mtro);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Edit(Maestros mtro)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                dbMaestros.Entry(mtro).State = EntityState.Modified;
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int? id)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(Maestros mtro, int? id)
        {
            using (AlumnoDBContext dbMaestros = new AlumnoDBContext())
            {
                Maestros ma = dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault();
                dbMaestros.Maestros.Remove(ma);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }

  
}