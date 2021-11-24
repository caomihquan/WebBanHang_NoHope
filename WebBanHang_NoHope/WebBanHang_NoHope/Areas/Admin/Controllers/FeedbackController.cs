﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang_NoHope.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(page, pageSize);

            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FeedbackDao().Delete(id);
            return RedirectToAction("Index", "FeedBack");
        }
    }
}