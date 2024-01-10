using Delivery.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Добавление данных в бд
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.NewGuid(),
                    SendersCity = "Москва",
                    SendersAddress = "ул. Водная д. 5, кв. 7",
                    RecipientCity = "Санкт-Петербург",
                    RecipientAddress = "ул. Дыбенко д. 11, кв. 103",
                    CargoWeight = 35,
                    DatePickup = new DateOnly(2024, 4, 23)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    SendersCity = "Петрозаводск",
                    SendersAddress = "ул. Грузчиков д. 1А, кв. 9",
                    RecipientCity = "Челябинск",
                    RecipientAddress = "ул. Смольная д. 22, кв. 11",
                    CargoWeight = 17,
                    DatePickup = new DateOnly(2024, 2, 29)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    SendersCity = "Южно-Сахалинск",
                    SendersAddress = "ул. Первомайская д. 4, кв. 111",
                    RecipientCity = "Хабаровск",
                    RecipientAddress = "ул. Морская д. 66, кв. 6",
                    CargoWeight = 55,
                    DatePickup = new DateOnly(2024, 11, 28)
                });
        }
    }
}
