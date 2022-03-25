using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Accion Belico" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Rol Accion" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "First Person Shotter" });

            //seed games

            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 1,
                Name = "Call of Duty Vanguard",
                Price = 75.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription =
                    "La narrativa unificada de la campaña para un solo jugador de Vanguard abarca cuatro líneas de frente diferentes de la Segunda Guerra Mundial, centrándose en la Guerra del Pacífico, los frentes occidental y oriental y la campaña del norte de África.",
                CategoryId = 1,
                ImageUrl = "https://www.igyaan.in/wp-content/uploads/2015/10/CoD-2-1000x625.jpg",
                InStock = true,
                IsGameOfTheWeek = true,
                ImageThumbnailUrl = "https://cdn.mos.cms.futurecdn.net/AC2X2VJaV48VcNv2FJiC23-320-80.jpg",
                ImportantInformation = ""
            });

            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 2,
                Name = "God of War",
                Price = 60.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription =
                    "",
                CategoryId = 2,
                ImageUrl = "https://img.8wallpapers.com/uploads/2021/04/ef60ccd081cb4de1b9acddf2-1000x625.jpg",
                InStock = true,
                IsGameOfTheWeek = false,
                ImageThumbnailUrl =
                    "https://us.cdn.eltribuno.com/092021/1631920503361/1366_2000%20(2).jpeg?&cw=320&ch=200",
                ImportantInformation = ""
            });

            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 3,
                Name = "Halo Infinite",
                Price = 55.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription =
                    "El jefe Maestro el gran héroe de la humanidad y personaje principal de la saga se enfrentara a un grupo sanguinario y temible que alguna vez fueron parte del Covenant llamados los Desterrados, estos fueron integrados desde Halo Wars 2 y en las novelas del universo de Halo, ahora debutando como la amenaza principal en Halo Infinite.",
                CategoryId = 3,
                ImageUrl = "https://img.8wallpapers.com/uploads/2019/01/a1da12514cc1496a83be1783-1000x625.jpg",
                InStock = true,
                IsGameOfTheWeek = false,
                ImageThumbnailUrl = "https://us.cdn.eltribuno.com/072020/1596235960841.jpg?&cw=320&ch=200",
                ImportantInformation = ""
            });

            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 4,
                Name = "Dark Souls",
                Price = 70.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription =
                    "Es un videojuego de rol de acción desarrollado por FromSoftware y publicado por Bandai Namco Entertainment.",
                CategoryId = 2,
                ImageUrl = "https://sm.ign.com/ign_in/game/d/dark-souls/dark-souls-iii_19ft.jpg",
                InStock = true,
                IsGameOfTheWeek = false,
                ImageThumbnailUrl = "https://cdn.mos.cms.futurecdn.net/E7RJm3PFysWPWq9sNYCij5-320-80.jpg",
                ImportantInformation = ""
            });

        }

    }

    
}
