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
    public class DeleteModel : PageModel
    {
        private readonly CoffeeShopWebsite.Data.CoffeeShopWebsiteContext _context;

        public DeleteModel(CoffeeShopWebsite.Data.CoffeeShopWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerModel CustomerModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customermodel = await _context.CustomerModel.FirstOrDefaultAsync(m => m.ID == id);

            if (customermodel == null)
            {
                return NotFound();
            }
            else
            {
                CustomerModel = customermodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customermodel = await _context.CustomerModel.FindAsync(id);
            if (customermodel != null)
            {
                CustomerModel = customermodel;
                _context.CustomerModel.Remove(CustomerModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
