using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eiga.Models;
using Eiga.ViewModels;

namespace Eiga.Controllers
{
    public class CustomerController : Controller
    {
        public class ApplicationDbContext : MyDbContext
        {
        }
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();  
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var membership = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(), //to get the default CustomerId which is '0'. Otherwise, we don't have any Value(have empty string) which throws validation error that CustomerId is required 
                MembershipTypes = membership
            };
            return View("CustomerForm",viewModel);
        }
       public ActionResult  Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewmodel);
        }
        public ActionResult Details(int? id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);

            if (customer != null)
                return View(customer);

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.CustomerId == 0)
                _context.Customer.Add(customer);
            else
            {
                var customerInDb = _context.Customer.Single(c => c.CustomerId == customer.CustomerId);
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.CustomerBirthDate = customer.CustomerBirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}