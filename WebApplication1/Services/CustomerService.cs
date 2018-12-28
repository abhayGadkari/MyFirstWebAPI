using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Models;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private Dictionary<int, Customer> _customerList;

        public CustomerService()
        {
            _customerList = new Dictionary<int, Customer>();

            _customerList.Add(2, new Customer() { Id = 2, FirstName = "Abhay", LastName = "Gadkari" });
        }


        public List<Customer> GetCustomers()
        {
            return _customerList.Values.ToList();
        }
        public Customer GetCustomer(int id)
        {
            if (_customerList.ContainsKey(id))
                return _customerList[id];
            else
               return null;
        }

        public String AddCustomer(Customer newCustomer)
        {
            if (!_customerList.ContainsKey(newCustomer.Id))
            {
                _customerList.Add(newCustomer.Id, newCustomer);
                return "New customer Added";
            }
            else
            {
                return String.Format("Customer with Id {0} aleady found", newCustomer.Id);
            }
        }
        public String UpdateCustomer(Customer updatedCustomer)
        {
            if (_customerList.ContainsKey(updatedCustomer.Id))
            {
                // update 
                Customer oldCustomer = _customerList[updatedCustomer.Id];

                oldCustomer.FirstName = updatedCustomer.FirstName;
                oldCustomer.LastName = updatedCustomer.LastName;

                return "";
            }
            else
            {
                return String.Format("Customer with Id {0} not found", updatedCustomer.Id);
            }
        }
        public String DeleteCustomer(int id)
        {
            if (_customerList.ContainsKey(id))
            {
                _customerList.Remove(id);
                return "";
            }
            else
            {
                return String.Format("Customer with Id {0} not found", id);
            }
        }
    }
}
