using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        String AddCustomer(Customer customer);
        String UpdateCustomer(Customer customer);
        String DeleteCustomer(int id);
    }
}
