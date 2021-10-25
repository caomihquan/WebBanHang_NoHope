﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang_NoHope.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                long id = dao.Insert(about);
                if (id > 0)
                {
                    //SetAlert("Thêm Thành Công ", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Không Thành Công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var about = new AboutDao().ViewDetail(id);
            return View(about);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                var result = dao.Update(about);
                if (result)
                {
                    //SetAlert("Sửa Thành Công ", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Sản Phẩm Không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = new AboutDao().Delete(id);
            if (result)
            {
                return RedirectToAction("Index", "About");
            }
            else
            {
                ModelState.AddModelError("", "Cập Nhật Không Thành Công");
            }
            return View("Index");

        }
    }
}
