using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.dom.Models;

public class CustomerModel
{
    public Guid Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public AddressModel Address { get; set; } = null!;
    
}
