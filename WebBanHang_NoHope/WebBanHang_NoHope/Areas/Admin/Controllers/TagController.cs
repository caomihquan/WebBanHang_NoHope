﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang_NoHope.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TagDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new TagDao().Delete(id);
            return RedirectToAction("Index", "Tag");
        }
    }
}