using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using POS_Folders.Repository;
using POS_Folders.Models;

namespace CoffeeShopWebsite.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;

        public IndexModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        public CustomerModel Customer { get; private set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Email))
            {
                Customer = _customerRepository.getCustomerByEmail(Email);
            }
        }
    }
}
