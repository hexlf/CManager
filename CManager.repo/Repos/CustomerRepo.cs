using CManager.dom.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CManager.repo.Repos;

public class CustomerRepo : ICustomerRepo
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly JsonSerializerOptions _jsonOptions;

    public CustomerRepo(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);

        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };
    }
    public List<CustomerModel> GetCustomers()
    {
        if (!File.Exists(_filePath))
        {
            return [];
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            var customers = JsonSerializer.Deserialize<List<CustomerModel>>(json, _jsonOptions);
            return customers ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading customer data.: {ex.Message}");
            throw;
        }


    }

    public bool SaveCustomerModel(List<CustomerModel> customers)
    {
        if(customers == null)
            return false;

        try
        {
            var json = JsonSerializer.Serialize(customers, _jsonOptions);

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            File.WriteAllText(_filePath, json);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving customer data.: {ex.Message}");
            return false;
        }


    }
}
