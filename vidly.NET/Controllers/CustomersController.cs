﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.NET.Models;

namespace vidly.NET.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }       
    }
}