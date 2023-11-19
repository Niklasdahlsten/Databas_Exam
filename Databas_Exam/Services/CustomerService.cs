﻿using Databas_Exam.Entities;
using Databas_Exam.Models;
using Databas_Exam.Repositories;

namespace Databas_Exam.Services;

internal class CustomerService
{
    private readonly AddressRepository _addressRepository;
    private readonly CustomerRepository _customerRepository;

    public CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }   

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (!await _customerRepository.ExistsAsync(x => x.Email == form.Email))
        {
            var addressEntity = await _addressRepository.GetAsync(x => x.StreetName  == form.StreetName && x.PostalCode == form.PostalCode);
            if (addressEntity == null)
                addressEntity = await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode,City = form.City});

            CustomerEntity customerEntity = await _customerRepository.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
            if (customerEntity != null)
                return true;

        }
        return false;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers;
    }
}
