using Microsoft.AspNetCore.Mvc;
using Shared.Data;
using Shared.Models;

namespace MvcApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // GET: raw/customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync(
            ICustomerRepository customerRepository)
        {
            return await customerRepository
                .AllAsync(HttpContext.RequestAborted);
        }
    }
}