﻿using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class ManagePostsController : Controller
    {
        // GET: Admin/ManagePosts
        public ActionResult ShowAllPosts()
        {
            return View();
        }
        public ActionResult NewPost()
        {
            return View();
        }
    }
}