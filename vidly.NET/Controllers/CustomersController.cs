using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.NET.Models;
using vidly.NET.ViewModels;

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

        // GET: Customers/NewCustomer
        public ActionResult NewCustomer()
        {
            var membershipType = _dbContext.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipType
            };

            return View(viewModel);
        }

        //POST:Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

        // GET: Customers/Details/Id
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }       

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}