using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoffeeShopWebsite.Data;
using POS_Folders.Models;

namespace CoffeeShopWebsite.Pages.CRUDFramework
{
    public class CreateModel : PageModel
    {
        private readonly CoffeeShopWebsite.Data.CoffeeShopWebsiteContext _context;

        public CreateModel(CoffeeShopWebsite.Data.CoffeeShopWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerModel CustomerModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerModel.Add(CustomerModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
