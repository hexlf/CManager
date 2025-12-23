using CManager.dom.Models;

namespace CManager.App.Services;

public interface ICustomerService
{
    bool CreatCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);
    
    IEnumerable<CustomerModel> GetAllCustomers(out bool hasError);
    
    bool DeleteCustomer(Guid id);
}
