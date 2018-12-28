using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("Client/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // GET Client/GetCustomers
        [HttpGet]
        [Route("GetCustomers")]
        public ActionResult<List<Customer>> GetCustomers()
        {
            var results = _service.GetCustomers();
            if (results == null)
                return BadRequest("No Customer found");
            else
                return results;


        }

        // GET Client/GetCustomerById
        [HttpGet]
        [Route("GetCustomerById")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var result = _service.GetCustomer(id);
            if (result == null)
                return BadRequest(String.Format("Customer not found for Id:{0}",id));
            else
                return result;
        }

        // POST Client/AddCustomer
        [HttpPost]
        [Route("AddCustomer")]
        public ActionResult AddCustomer(Customer newCustomer)
        {
            var result = _service.AddCustomer(newCustomer);
            if (!String.IsNullOrEmpty(result))
                return BadRequest(result);
            else
                return Ok(result);


        }

        // PUT Client/UpdateCustomer
        [HttpPut]
        [Route("UpdateCustomer")]
        public ActionResult UpdateCustomer(Customer updatedCustomer)
        {
            var result = _service.UpdateCustomer(updatedCustomer);
            if (!String.IsNullOrEmpty(result))
                return NotFound(result);
            else
                return Ok(result);
        }

        // DELETE Client/DeleteCustomer
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer( int id)
        {
            var result = _service.DeleteCustomer(id);
            if (!String.IsNullOrEmpty(result))
                return NotFound(result);
            else
                return Ok(result);
        }
    }
}
