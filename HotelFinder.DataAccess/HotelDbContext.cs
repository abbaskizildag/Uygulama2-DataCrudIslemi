using HotelFinder.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext //DbContext'i ekliyoruz. Bunu nuget ekledikten sonra getiriyoruz.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ilk yapacağımız işlem bu onconfiguring metodunu override etmek.
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-MD8KOD4; Database=HotelDb; Integrated Security=True;");
            //burada database henüz yok migrationda böyle bir db oluşturucak.
        }

        public DbSet<Hotel> Hotels { get; set; } //Hotels ile update,delete gibi komutlara erişmiş olacak. Dbset'in içine girince görüyorsun.

    }
}
