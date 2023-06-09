using System.Globalization;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data.Repositories;
using System.IO.Ports;
using System.Net.Http.Headers;
using System.Text;


namespace App.Services.impl;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IHashService _hashService;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IHashService hashService)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _hashService = hashService;
    }

    /// <summary>
    /// Create customer from the CustomerRepository
    /// </summary>
    /// <param name="createCustomer">CreateCustomer</param>
    /// <returns>Type: CustomerResponse</returns>
    public async Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer)
    {
        var salt = _hashService.CreateSalt();
        var hashedFingerprint = await _hashService.Hash(createCustomer.FingerPrint, salt);
        Customer customer = _mapper.Map<Customer>(createCustomer);
        customer.Salt = salt;
        customer.DateAdded = DateTime.Now;
        customer.HashedFingerPrint = hashedFingerprint;
        Customer result = await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerResponse>(result);
    }

    public async Task<CustomerResponse> GetCustomer(int id)
    {
        Customer result = await _customerRepository.GetFirstASync(c => c.Id == id);
        return _mapper.Map<CustomerResponse>(result);
    }

    public async Task<IEnumerable<CustomerResponse>> GetCustomers()
    {
        List<Customer> result = await _customerRepository.GetAllAsync();
        return _mapper.Map<List<CustomerResponse>>(result);
    }

    public async Task<CustomerResponse> UpdateCustomer(CreateCustomer updateCustomer)
    {
        Customer customer = _mapper.Map<Customer>(updateCustomer);
        Customer result = await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerResponse>(result);
    }

    public async Task<CustomerResponse> DeleteCustomer(int id)
    {
        Customer customer = await _customerRepository.GetFirstASync(c => c.Id == id);
        Customer result = await _customerRepository.DeleteAsync(customer);
        return _mapper.Map<CustomerResponse>(result);
    }

    public async Task<bool> VerifyFingerprint(int id, string fingerprint)
    {
        Customer customer = await _customerRepository.GetFirstASync(c => c.Id == id);
        bool verified = await _hashService.Verify(fingerprint, customer.Salt, customer.HashedFingerPrint);
        return verified;
    }


    //For Prototype purposes
    public async Task<bool> VerifyFingerprintArduino(int id)
    {
        Customer customer = await _customerRepository.GetFirstASync(c => c.Id == id);
        SerialPort arduinoPort = new SerialPort("COM3", 115200);
        arduinoPort.Open();
        Thread.Sleep(2000);
        arduinoPort.WriteLine("V");
        arduinoPort.WriteLine(customer.FingerprintIdArduino.ToString());

        while (true)
        {
            string identifier = arduinoPort.ReadLine();
            if (identifier == "Verify\r")
            {
                string success = arduinoPort.ReadLine();
                switch (success)
                {
                    case "1\r":
                        arduinoPort.WriteLine("");
                        arduinoPort.Close();
                        //PrintMessage();
                        return true;
                    case "0\r":
                        arduinoPort.WriteLine("");
                        arduinoPort.Close();
                        return false;
                }
            }
        }
    }
}