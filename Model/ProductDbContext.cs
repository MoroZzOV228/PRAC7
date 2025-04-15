using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task7.Model
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }
        #region Конструктор
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public свойства
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Методы
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        
        private Product[] GetProducts() => new Product[]
        {
            new Product{ProductID = 1,
                        ProductName = "Гантелина",
                        ProductDescription = "Когда то была Ангелиной, блины по 50/30/15(кг)",
                        ProductPrice = 5200,
                        ProductUnit = 20},
            new Product{ProductID = 2,
                        ProductName = "Штангелина",
                        ProductDescription = "Когда то была Ириной, блины по 50/30/20(кг)",
                        ProductPrice = 6900,
                        ProductUnit = 18},
            new Product{ProductID = 3,
                        ProductName = "Тренболина",
                        ProductDescription = "Когда то была Протеиной, 500/300/200 (гр)",
                        ProductPrice = 4200,
                        ProductUnit = 20},
            new Product{ProductID = 4,
                        ProductName = "Блинина",
                        ProductDescription = "Когда то была Блондиной, 50/30/20(кг)",
                        ProductPrice = 999,
                        ProductUnit = 10}
        };
        #endregion

    }
}