using CManager.App.Services;
using CManager.Presentation.ConsoleApp.Controllers;
using CManager.repo.Repos;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerRepo, CustomerRepo>()
    .AddScoped<MenuController>()
    .BuildServiceProvider();

var controller = services.GetRequiredService<MenuController>();
controller.ShowMenu();