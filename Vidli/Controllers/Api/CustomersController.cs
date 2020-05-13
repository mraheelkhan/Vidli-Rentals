using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidli.Dtos;
using Vidli.Models;
using System.Data.Entity;
using Vidli.Models.Roles;

namespace Vidli.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // /api/customers
        // [Authorize(Roles = RoleNames.CanManageCustomers)]
        [AllowAnonymous]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.CustomerName.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<CustomerModel, CustomerDto>);
            /*return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<CustomerModel, CustomerDto>);*/
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        [Authorize(Roles = RoleNames.CanManageCustomers)]
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CustomerModel, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        // public CustomerDto CreateCustomer(CustomerDto customerDto)
        [Authorize(Roles = RoleNames.CanManageCustomers)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, CustomerModel>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        [Authorize(Roles = RoleNames.CanManageCustomers)]
        public void UpdateCustomer(int Id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Mapper.Map<CustomerDto, CustomerModel>(customerdto, customerInDb);
            Mapper.Map(customerdto, customerInDb);
            // customerInDb.CustomerAge = customerdto.CustomerAge;
            // customerInDb.CustomerAddress = customerdto.CustomerAddress;
            // customerInDb.CustomerName = customerdto.CustomerName;
            // customerInDb.IsSubscribedToNewsletter = customerdto.IsSubscribedToNewsletter;
            // customerInDb.MemberShipTypeId = customerdto.MemberShipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        [Authorize(Roles = RoleNames.CanManageCustomers)]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
