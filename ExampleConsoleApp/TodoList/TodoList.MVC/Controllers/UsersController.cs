using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.DataAccess.Context;
using TodoList.DataAccess.Repositories;
using TodoList.Entities;
using TodoList.Entities.Repositories;

namespace TodoList.MVC.Controllers
{
    public class UsersController : Controller
    {

        private IUserRepository userRepo = new UserRepository(new TodoContext());

        // GET: Users
        public ActionResult Index()
        {
            return View(userRepo.GetUsers());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            // User user = db.Users.Find(id);
            User user = userRepo.GetUser(id.GetValueOrDefault());

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                userRepo.AddUser(user);
                userRepo.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepo.GetUser(id.GetValueOrDefault());
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                var userInDB = userRepo.GetUser(user.Id);
                userInDB.FirstName = user.FirstName;
                userInDB.LastName = user.LastName;

                userRepo.Save();

                return RedirectToAction("Index");
            }
            return View(user);
        }
      
    }
}
