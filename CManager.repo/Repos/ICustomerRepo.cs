using CManager.dom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.repo.Repos;

public interface ICustomerRepo
{
    List<CustomerModel> GetCustomers();
    bool SaveCustomerModel(List<CustomerModel> customers);
}
