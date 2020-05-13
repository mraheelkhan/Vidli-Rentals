﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidli.Models;
using Vidli.ViewModels;
using System.Data.Entity;
namespace Vidli.Controllers
{
    public class CustomerController_backup : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController_backup()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var customers = GetAllCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers.ToList());
        }
        public ActionResult Details(int Id)
        {

            //var customer = GetAllCustomers().SingleOrDefault(c => c.Id == Id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            TempData["PageTitle"] = "New Customer";
            var viewModel = new CustomFormViewModel()
            {
                Customer = new CustomerModel(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerModel customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipType.ToList();
                TempData["PageTitle"] = "New Customer";
                var viewModel = new CustomFormViewModel
                {
                    MembershipType = membershipTypes
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                // if customer is new
                _context.Customers.Add(customer);
            else
            {
                // if it is update requrest
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDb.CustomerName = customer.CustomerName;
                CustomerInDb.CustomerAge = customer.CustomerAge;
                CustomerInDb.CustomerAddress = customer.CustomerAddress;
                CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                CustomerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }
            //_context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            TempData["PageTitle"] = "Edit Customer";
            var viewModel = new CustomFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            return new List<CustomerModel>
            {
                new CustomerModel {
                    Id = 1,
                    CustomerName = "Raheel Khan ",
                    CustomerAddress = "Blue Area Islamabad",
                    CustomerAge = 22
                },
                new CustomerModel {
                    Id = 2,
                    CustomerName = "Hilal Khan ",
                    CustomerAddress = "Ghori Pindi",
                    CustomerAge = 23
                },
                new CustomerModel {
                    Id = 3,
                    CustomerName = "Ahmad Khan ",
                    CustomerAddress = "Nazuk Pindi",
                    CustomerAge = 23
                }
            };
        }


    }
}