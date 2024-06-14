using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShopWebsite.Data;
using POS_Folders.Models;

namespace CoffeeShopWebsite.Pages.CRUDFramework
{
    public class EditModel : PageModel
    {
        private readonly CoffeeShopWebsite.Data.CoffeeShopWebsiteContext _context;

        public EditModel(CoffeeShopWebsite.Data.CoffeeShopWebsiteContext context)
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

            var customermodel =  await _context.CustomerModel.FirstOrDefaultAsync(m => m.ID == id);
            if (customermodel == null)
            {
                return NotFound();
            }
            CustomerModel = customermodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(CustomerModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerModelExists(int id)
        {
            return _context.CustomerModel.Any(e => e.ID == id);
        }
    }
}
