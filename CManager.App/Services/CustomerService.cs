using CManager.dom.Models;
using CManager.repo.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.App.Services;

public class CustomerService : ICustomerService
{

    private readonly ICustomerRepo _customerRepo;

    public CustomerService(ICustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city)
    {
        CustomerModel customerModel = new()
        {
            Id = Guid.NewGuid(),
            Firstname = firstName,
            Lastname = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = new AddressModel
            {
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city
            }
        };

        try
        {
            var customers = _customerRepo.GetCustomers();
            customers.Add(customerModel);
            var result = _customerRepo.SaveCustomerModel(customers);
            return result;
        }
        catch (Exception)
        {
            return false;
        }


    }

    public IEnumerable<CustomerModel> GetAllCustomers(out bool hasError)
    {
        hasError = false;
        try
        {
           var customers = _customerRepo.GetCustomers();
            return customers;
        }
        catch (Exception)
        {
            hasError = true;
            return [];
        }
    }

    public bool DeleteCustomer(Guid id)
    {
        try
        {
            var customers = _customerRepo.GetCustomers();
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return false;

            customers.Remove(customer);
            var result = _customerRepo.SaveCustomerModel(customers);
            return result;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting customer: {ex.Message}");
            return false;
        }
    }
}
