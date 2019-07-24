using Amaterasu.Models;
using Amaterasu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Amaterasu.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var cust = _context.Customers.Include(c => c.MembershipType).ToList();

            var customer = new CustomerVM()
            {
                Customers = cust,
            };
            return View(customer);
        }   
        
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormVM()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormVM
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

            return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.Phone = customer.Phone;
                customerInDb.Address = customer.Address;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormVM()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (singleCustomer == null)
            {
                return HttpNotFound();
            }
            else
            {
                Customer customer = singleCustomer;
                return View(customer);
            }
        }
        public ActionResult Random(int? PageIndex, string SortBy)
        {
            if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(SortBy))
            {
                SortBy = "Name";
            }
            return Content(string.Format("PageIndex={0}&SortBy={1}", PageIndex, SortBy));
        }
    }
}