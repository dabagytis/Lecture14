using Lecture14_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_1.Core.Contracts
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> GetAllCustomers();
    }
}
