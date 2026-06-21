using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

namespace IntelligentTicketRouter.Api.DataManipulation;

public class CustomerOrderPlugin
{
    private readonly AppDbContext _context;

    public CustomerOrderPlugin(AppDbContext context)
    {
        _context = context;
    }

    [KernelFunction, Description("Retrieves the real order history for a customer using their Email address.")]
    public async Task<List<Order>> GetCustomerOrdersAsync(
        [Description("The email address of the customer submitting the ticket.")] string email)
    {
        return await _context.Orders
            .Where(o => o.CustomerEmail == email)
            .ToListAsync();
    }

}