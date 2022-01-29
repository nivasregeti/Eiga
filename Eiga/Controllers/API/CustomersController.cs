using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eiga.DTOs;
using Eiga.Models;

namespace Eiga.Controllers.API
{
    public class CustomersController : ApiController
    {
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        //GET   /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customer.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.CustomerName.Contains(query));

            var customerDtos = customersQuery.ToList()
                                             .Select(Mapper.Map<Customer, CustomerDTOs>);

            return Ok(customerDtos);
        }

        //Get   /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTOs>(customer));
        }

        //POST  /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTOs customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTOs, Customer>(customerDTO);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDTO.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDTO);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTOs customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customer.SingleOrDefault(c => c.CustomerId == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO, customerInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.CustomerId == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
/*anywhere we return a customer object, we need to map it to a DTO first 
 and also the methods where we modify the customer like create a customer or update customer, we need to map this customer DTO properties back to our customer object.
 Doing all these mapping by hand can be tedious.So, we use Automapper to easily map these objects.*/