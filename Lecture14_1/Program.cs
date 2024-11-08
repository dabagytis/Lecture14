using Lecture14_1.Core.Contracts;
using Lecture14_1.Core.Repo;
using Lecture14_1.Core.Models;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Lecture14_1;

public class Program
{
    public static void Main(string[] args)
    {
        ICustomerRepo customerRepo = new CustomerRepo("Server=localhost;Database=Lecture14;Trusted_Connection=True;TrustServerCertificate=true;");

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new customer");
            Console.WriteLine("2. Update customer information");
            Console.WriteLine("3. Show all customers");
            Console.WriteLine("4. Delete customer");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter customer name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter customer surname:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter customer email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter customer phone number:");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine();

                    Customer newCustomer = new Customer
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        PhoneNumber = phoneNumber
                    };
                    customerRepo.AddCustomer(newCustomer);
                    continue;

                case 2:
                    Console.WriteLine("Enter ID of the customer you wish to update:");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Customer up = customerRepo.GetCustomerById(updateId);
                    Console.WriteLine("Enter customer name:");
                    string uFirstName = Console.ReadLine();
                    Console.WriteLine("Enter customer surname:");
                    string uLastName = Console.ReadLine();
                    Console.WriteLine("Enter customer email:");
                    string uEmail = Console.ReadLine();
                    Console.WriteLine("Enter customer phone number:");
                    string uPhoneNumber = Console.ReadLine();
                    Console.WriteLine();

                    up.FirstName = uFirstName;
                    up.LastName = uLastName;
                    up.Email = uEmail;
                    up.PhoneNumber = uPhoneNumber;

                    customerRepo.UpdateCustomer(up);

                    continue;

                case 3:
                    foreach(Customer a in customerRepo.GetAllCustomers())
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine();
                    continue;

                case 4:
                    Console.WriteLine("Enter ID of the customer you wish to delete:");
                    int deletionId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    customerRepo.DeleteCustomer(deletionId);
                    continue;

                case 5:
                    return;
            }
        }
    }
}