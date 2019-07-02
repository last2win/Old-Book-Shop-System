using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;

namespace BookShop.Models
{
    public class BookShopContext : DbContext
    {
        public BookShopContext (DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public DbSet<BookShop.Models.Book> Book { get; set; }

        public DbSet<BookShop.Models.Want> Want { get; set; }

        public DbSet<BookShop.Models.Order> Order { get; set; }
        public DbSet<BookShop.Models.OrderList> OrderList { get; set; }

    }
}
