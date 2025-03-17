﻿
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
            return _context.Products.OrderByDescending(p => p.Price).Take(count).ToListAsync(); // Already returns Task<List<Product>>
        }
    }
}
