using Dapper;
using Lecture14_1.Core.Contracts;
using Lecture14_1.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_1.Core.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly string _connectionString;
        public CustomerRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(Customer customer)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)", customer);
            }
        }

        public void DeleteCustomer(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Customers WHERE Id = @id", new { id });
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allCustomers = connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            return allCustomers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer byId = new Customer();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                byId = connection.QueryFirst<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
            }
            return byId;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE Customers SET FirstName = @FirstName , LastName = @LastName , Email = @Email , PhoneNumber = @PhoneNumber WHERE Id = @Id", customer);
            }
        }
    }
}
