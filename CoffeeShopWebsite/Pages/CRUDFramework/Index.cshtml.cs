using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeShopWebsite.Data;
using POS_Folders.Models;

namespace CoffeeShopWebsite.Pages.CRUDFramework
{
    public class IndexModel : PageModel
    {
        private readonly CoffeeShopWebsite.Data.CoffeeShopWebsiteContext _context;

        public IndexModel(CoffeeShopWebsite.Data.CoffeeShopWebsiteContext context)
        {
            _context = context;
        }

        public IList<CustomerModel> CustomerModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CustomerModel = await _context.CustomerModel.ToListAsync();
        }
    }
}
