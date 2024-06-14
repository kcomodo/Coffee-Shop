using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Folders.Models;

namespace CoffeeShopWebsite.Data
{
    public class CoffeeShopWebsiteContext : DbContext
    {
        public CoffeeShopWebsiteContext (DbContextOptions<CoffeeShopWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<POS_Folders.Models.CustomerModel> CustomerModel { get; set; } = default!;
    }
}
