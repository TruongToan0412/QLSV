﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using test3.Models;
using PagedList;
using System.Data.Entity.Validation;
using test3.App_Start;
using System.Net;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace test3.Controllers
{
    public class QLHKController : Controller
    {
        // GET: QLSV
        QuanliSVEntities db = new QuanliSVEntities();
        [Role_User(FunctionID = "Admin_XemDanhSach")]
        public ActionResult DanhSachHocKi(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }
            var hocKi = db.Semesters.ToList();
            return View(hocKi.ToPagedList((int)page, (int)pageSize));
        }


        [Role_User]
        [HttpGet]
        public ActionResult ThemMoiHocKi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiHocKi(Semester hocKi)
        {
            string semesterName = Request["SemesterName"];

            var existingSemester = db.Semesters.FirstOrDefault(s => s.SemesterName == semesterName);

            if (existingSemester != null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Học kì này đã tồn tại.");
            }

            db.Semesters.Add(hocKi);
            db.SaveChanges();
            return RedirectToAction("DanhSachHocKi");
        }
        public ActionResult Xoa(int id)
        {
            QuanliSVEntities db = new QuanliSVEntities();
            var hocKi = db.Semesters.Find(id);
            db.Semesters.Remove(hocKi);
            db.SaveChanges();
            return RedirectToAction("DanhSachHocKi");
        }
        [HttpGet]
        public ActionResult Suathongtin(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("DanhSachHocKi");
            }

            QuanliSVEntities db = new QuanliSVEntities();
            var hocKi = db.Semesters.Find(id);

            if (hocKi == null)
            {
                return RedirectToAction("DanhSachHocKi");
            }
            return View(hocKi);
        }

        [HttpPost]
        public ActionResult Suathongtin(Semester hocKi)
        {
            QuanliSVEntities db = new QuanliSVEntities();
            string semesterName = Request["SemesterName"];

            var existingSemester = db.Semesters.FirstOrDefault(s => s.SemesterName == semesterName);

            if (existingSemester != null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Học kì này đã tồn tại.");
            }
            db.Entry(hocKi).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DanhSachHocKi");
        }
    }
}
