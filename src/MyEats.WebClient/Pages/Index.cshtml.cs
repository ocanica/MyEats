using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyEats.Database.Entities;
using MyEats.WebClient.Contracts;

namespace MyEats.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Customer> Customers { get; set; }

        public IndexModel(IApiClient apiClient, ILogger<IndexModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task OnGet()
        {
            Customers = await _apiClient.GetAllCustomers();
        }
    }
}
